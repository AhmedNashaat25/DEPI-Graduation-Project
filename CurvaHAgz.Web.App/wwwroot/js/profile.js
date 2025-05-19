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

// Start Filter
let filter = document.querySelectorAll(".filter li");
let boxs = Array.from(document.querySelectorAll(".box"));
let type = Array.from(document.querySelectorAll(".type"));

filter.forEach((li) => {
  li.addEventListener("click", remove_active);
  li.addEventListener("click", delete_box);
});

function remove_active(){
  filter.forEach((li) => {
    li.classList.remove("active");
    this.classList.add("active");
	});
}

function delete_box(){
  boxs.forEach((table) => {
    table.style.display = "none";
  });
  document.querySelectorAll(this.dataset.type).forEach((el) => {
    el.style.display = "block";
	})
}
// End Filter

// Start Show Password

let eyeIcons = document.querySelectorAll('[id^="eye-"]');
let passwordInputs = document.querySelectorAll('[id^="password-"]');

function togglePasswordVisibility(eyeElements, passwordInputs) {
    eyeElements.forEach(function(eyeElement, index) {
        eyeElement.addEventListener('click', function () {
            if (passwordInputs[index].type === 'password') {
                passwordInputs[index].type = 'text';
                eyeElement.classList.remove('fa-eye-slash');
                eyeElement.classList.add('fa-eye');
            } else {
                passwordInputs[index].type = 'password';
                eyeElement.classList.remove('fa-eye');
                eyeElement.classList.add('fa-eye-slash');
            }
        });
    });
}

togglePasswordVisibility(eyeIcons, passwordInputs);


// End Show Password

// Start Taps
let edit = document.querySelectorAll("td button");
let tab = document.querySelectorAll(".tab");
let parent = document.querySelector(".edit_tabs");
let btns = document.querySelectorAll(".btns .button");
let blur = document.querySelector(".blur");
let body = document.querySelector("body");

function apper_tab(){
  document.querySelector(`.${this.dataset.tab}`).style.display = "block";
  parent.style.display = "block";
  blur.style.filter = "brightness(30%)";
  body.style.overflow = "hidden";
};

function delete_tab(){
  document.querySelector(`.${this.dataset.close}`).style.display = "none";
  parent.style.display = "none";
  blur.style.filter = "brightness(100%)";
  body.style.overflow = "initial";
};

edit.forEach((button) => {
  button.addEventListener("click", apper_tab);
});

btns.forEach((button) => {
  button.addEventListener("click", delete_tab);
});


function fchange() {
  document.getElementById('change').click();
  document.getElementById('submit').style.display = "block";
  blur.style.filter = "brightness(30%)";
}
function fdelete() {
  document.getElementById('delete-tab').click();
  document.getElementById('delete').style.display = "block";
  blur.style.filter = "brightness(30%)";
}
function deleteacc() {
  document.getElementById('delete-account').click();
  document.getElementById('delete-account').style.display = "block";
  blur.style.filter = "brightness(30%)";
}
// End Taps

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

