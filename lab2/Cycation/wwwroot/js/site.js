let list = [];
window.onload = () => {
	loadDataFromLocalStorage();
	loadList();
	submitQuote();
};

function loadDataFromLocalStorage() {
	const storageData = localStorage.getItem("quote_list");

	if (!storageData || !JSON.parse(storageData)) {
		return;
	}
	list = JSON.parse(storageData);

	return list;
}

function addToLocalStorage(author, quote) {
	loadDataFromLocalStorage();
	list.push({ author: author, quote: quote });
	rewrite();

	const container = document.querySelector(".list");
	container.appendChild(createQute({ author: author, quote: quote }));
}

function rewrite() {
	localStorage.setItem("quote_list", JSON.stringify(list));
}

function loadList() {
	const container = document.querySelector(".list");
	container.innerHTML = ``;
	list.map((item, key) => {
		container.appendChild(createQute(item, key));
	});
}

function createQute(quote, key) {
	const div = document.createElement("div");
	div.classList.add("item");
	div.innerHTML = `
		<div class="quote">"${quote.quote}"</div>
		<div class="author">${quote.author}</div>

		<nav>
			<div class="edit">Edit</div>
			<div class="delete">Delete</div>
		</nav>
	`;

	div.querySelector(".edit").addEventListener("click", () => {
		console.log(list, key, list[key]);
		const author = prompt("Author:", list[key].author);
		const quote = prompt("Quote:", list[key].quote);

		list[key] = { author: author, quote: quote };
		rewrite();
		loadList();
	});
	div.querySelector(".delete").addEventListener("click", () => {
		list.splice(key, 1);

		rewrite();
		loadList();
	});

	return div;
}

async function submitQuote() {
	const form = document.querySelector("form");
	form.addEventListener("submit", (event) => {
		event.preventDefault();
		addToLocalStorage(form.author.value, form.quote.value);
	});
}
