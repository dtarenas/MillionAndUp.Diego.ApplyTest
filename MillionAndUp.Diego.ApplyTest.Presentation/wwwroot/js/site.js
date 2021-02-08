/********************
 * Custom Javascript
 * ******************/

async function setListenerForAnchors() {
    const $listings = document.querySelectorAll(".listing");
    $listings.forEach(listing => {
        listing.addEventListener('click', renderResult);
    });
}

function goToRenderSection() {
    const $renderResult = document.querySelector("#render-result");
    if ($renderResult) {
        const offsetTop = $renderResult.offsetTop + 500;
        scroll({
            top: offsetTop,
            behavior: "smooth"
        });
    }
}

async function renderResult(e) {
    e.preventDefault();
    clearRenderSection();
    var renderSection = document.querySelector("#render-result");
    const templateLoading = document.querySelector("#template-loading").content;
    const loadingClone = templateLoading.cloneNode(true);
    renderSection.appendChild(loadingClone);

    goToRenderSection();
    const controller = e.currentTarget.getAttribute("href");
    const request = await fetch(`/${controller}`);
    if (request.ok) {
        setTimeout(async () => {
            const resultContent = await request.text();
            renderSection.innerHTML = resultContent;
            goToRenderSection();
        }, 500);
    } else {
        const templateError = document.querySelector("#template-error").content;
        renderSection.innerHTML = "";
        const errorClone = templateError.cloneNode(true);
        renderSection.appendChild(errorClone);
    }
}

function clearRenderSection() {
    document.querySelector("#render-result").innerHTML = '';
}