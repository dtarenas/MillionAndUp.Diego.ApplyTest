namespace MillionAndUp.Diego.ApplyTest.Presentation.Areas.Manage.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Editorials Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Area("Manage")]
    public class EditorialsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IGenericRepository<EditorialEntity> _editorialRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorialsController"/> class.
        /// </summary>
        /// <param name="editorialRepository">The editorial repository.</param>
        public EditorialsController(IGenericRepository<EditorialEntity> editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        // GET: Manage/Editorials
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _editorialRepository.Get().ToListAsync());
        }

        // GET: Manage/Editorials/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Details View</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialEntity = await _editorialRepository.Get()
                .FirstOrDefaultAsync(m => m.EditorialId == id);
            if (editorialEntity == null)
            {
                return NotFound();
            }

            return View(editorialEntity);
        }

        // GET: Manage/Editorials/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Create View</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/Editorials/Create
        /// <summary>
        /// Creates the specified editorial entity.
        /// </summary>
        /// <param name="editorialEntity">The editorial entity.</param>
        /// <returns>Crearte Result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditorialEntity editorialEntity)
        {
            if (ModelState.IsValid)
            {
                await _editorialRepository.AddAsync(editorialEntity);
                await _editorialRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editorialEntity);
        }

        // GET: Manage/Editorials/Edit/5
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

            var editorialEntity = await _editorialRepository.Get().FirstOrDefaultAsync(x => x.EditorialId == id);
            if (editorialEntity == null)
            {
                return NotFound();
            }
            return View(editorialEntity);
        }

        // POST: Manage/Editorials/Edit/
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="editorialEntity">The editorial entity.</param>
        /// <returns>Edit Result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditorialEntity editorialEntity)
        {
            if (id != editorialEntity.EditorialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _editorialRepository.Update(editorialEntity);
                    await _editorialRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialEntityExists(editorialEntity.EditorialId))
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
            return View(editorialEntity);
        }

        // GET: Manage/Editorials/Delete/5
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

            var editorialEntity = await _editorialRepository.Get()
                .FirstOrDefaultAsync(m => m.EditorialId == id);
            if (editorialEntity == null)
            {
                return NotFound();
            }

            return View(editorialEntity);
        }

        // POST: Manage/Editorials/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Deletes Result</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _editorialRepository.RemoveAsync(id);
            await _editorialRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Editorials the entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Control</returns>
        private bool EditorialEntityExists(int id)
        {
            return _editorialRepository.Get().Any(e => e.EditorialId == id);
        }
    }
}
