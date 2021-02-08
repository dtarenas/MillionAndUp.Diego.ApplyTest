namespace MillionAndUp.Diego.ApplyTest.Presentation.Areas.Manage.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Books Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Area("Manage")]
    public class BooksController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IGenericRepository<BookEntity> _booksRepo;

        /// <summary>
        /// The editorials repo
        /// </summary>
        private readonly IGenericRepository<EditorialEntity> _editorialsRepo;

        /// <summary>
        /// The authors repo
        /// </summary>
        private readonly IGenericRepository<AuthorEntity> _authorsRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController" /> class.
        /// </summary>
        /// <param name="booksRepo">The context.</param>
        /// <param name="editorialsRepo">The editorials repo.</param>
        /// <param name="authorsRepo">The authors repo.</param>
        public BooksController(IGenericRepository<BookEntity> booksRepo, IGenericRepository<EditorialEntity> editorialsRepo, IGenericRepository<AuthorEntity> authorsRepo)
        {
            this._booksRepo = booksRepo;
            this._editorialsRepo = editorialsRepo;
            this._authorsRepo = authorsRepo;
        }

        // GET: Manage/Books
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            var bookshopDbContext = this._booksRepo.Get().Include(b => b.FkAuthor).Include(b => b.FkEditorial);
            return View(await bookshopDbContext.ToListAsync());
        }

        // GET: Manage/Books/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEntity = await this._booksRepo.Get()
                .Include(b => b.FkAuthor)
                .Include(b => b.FkEditorial)
                .FirstOrDefaultAsync(m => m.ISBN == id);

            if (bookEntity == null)
            {
                return NotFound();
            }

            return View(bookEntity);
        }

        // GET: Manage/Books/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Create View</returns>
        public IActionResult Create()
        {
            ViewData["FkAuthorId"] = new SelectList(this._authorsRepo.Get(), "AuthorId", "FullName");
            ViewData["FkEditorialId"] = new SelectList(this._editorialsRepo.Get(), "EditorialId", "NameWithHeadquarter");
            return View();
        }

        // POST: Manage/Books/Create
        /// <summary>
        /// Creates the specified book entity.
        /// </summary>
        /// <param name="bookEntity">The book entity.</param>
        /// <returns>Create Result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookEntity bookEntity)
        {
            if (ModelState.IsValid)
            {
                await this._booksRepo.AddAsync(bookEntity);
                await this._booksRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FkAuthorId"] = new SelectList(this._authorsRepo.Get(), "AuthorId", "FullName", bookEntity.FkAuthorId);
            ViewData["FkEditorialId"] = new SelectList(this._editorialsRepo.Get(), "EditorialId", "NameWithHeadquarter", bookEntity.FkEditorialId);
            return View(bookEntity);
        }

        // GET: Manage/Books/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Edit View</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEntity = await this._booksRepo.Get().FirstOrDefaultAsync(x => x.ISBN == id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            ViewData["FkAuthorId"] = new SelectList(this._authorsRepo.Get(), "AuthorId", "FullName", bookEntity.FkAuthorId);
            ViewData["FkEditorialId"] = new SelectList(this._editorialsRepo.Get(), "EditorialId", "NameWithHeadquarter", bookEntity.FkEditorialId);
            return View(bookEntity);
        }

        // POST: Manage/Books/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookEntity">The book entity.</param>
        /// <returns>Edit Result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookEntity bookEntity)
        {
            if (id != bookEntity.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._booksRepo.Update(bookEntity);
                    await this._booksRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookEntityExists(bookEntity.ISBN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["FkAuthorId"] = new SelectList(this._authorsRepo.Get(), "AuthorId", "FullName", bookEntity.FkAuthorId);
            ViewData["FkEditorialId"] = new SelectList(this._editorialsRepo.Get(), "EditorialId", "NameWithHeadquarter", bookEntity.FkEditorialId);
            return View(bookEntity);
        }

        // GET: Manage/Books/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete View</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEntity = await this._booksRepo.Get()
                .Include(b => b.FkAuthor)
                .Include(b => b.FkEditorial)
                .FirstOrDefaultAsync(m => m.ISBN == id);

            if (bookEntity == null)
            {
                return NotFound();
            }

            return View(bookEntity);
        }

        // POST: Manage/Books/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete Confirm</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await this._booksRepo.RemoveAsync(id);
                await this._booksRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Books the entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Bool control</returns>
        private bool BookEntityExists(int id)
        {
            return this._booksRepo.Get().Any(e => e.ISBN == id);
        }
    }
}
