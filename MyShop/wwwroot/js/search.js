async function performSearch(query) {
    const resultsContainer = document.getElementById("searchResults");

    if (query.trim() === "") {
        resultsContainer.style.display = "none";
        resultsContainer.innerHTML = "";
        return;
    }

    try {
        const response = await fetch(`/api/Search?query=${encodeURIComponent(query)}`);
        const data = await response.json();

        if (data.results && data.results.length > 0) {
            resultsContainer.style.display = "block";
            resultsContainer.innerHTML = data.results
                .map(result => `<a href="${result.pagePath}">${result.keyword}</a>`)
                .join("");
        } else {
            resultsContainer.style.display = "block";
            resultsContainer.innerHTML = "<p>Ничего не найдено</p>";
        }
    } catch (error) {
        console.error("Ошибка при выполнении поиска:", error);
        resultsContainer.style.display = "none";
    }
}
