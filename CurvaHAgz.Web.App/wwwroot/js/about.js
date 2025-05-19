// Start Menu
function openmenu() {
  document.getElementById('menu').style.right = "0";
}
function closemenu() {
  document.getElementById('menu').style.right = "-235px";
}
// End Menu

// Start Scroll
let span = document.querySelector('.scroll');
window.onscroll = function () {
	this.scrollY >= 700 ? span.classList.add('show') : span.classList.remove('show');
}
span.onclick = function () {
	window.scrollTo({
		top: 0,
	})
}
// End Scroll

// Start Loading
let loading = document.querySelector(".loading");
window.addEventListener("load", function () {
  loading.style.display = "none";
})
// End Loading

// Start Reveal
let reveal = document.querySelectorAll('.reveal');

let revealBoxs = () => {
	let bottom = (window.innerHeight / 5) * 4;
	reveal.forEach((el) => {
		let top = el.getBoundingClientRect().top;
		if (top < bottom) el.classList.add('show');
		else el.classList.remove('show');
	})
}

window.addEventListener('scroll', revealBoxs);
revealBoxs();
// End Reveal