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

// start slider

let swiperCards = new Swiper('.one', {
	loop: true, 
	spaceBetween: 32,
	grabCursor: true,
	keyboard: {
      enabled: true,
	},

  pagination: {
		el: '.pagination1',
		clickable: true,
		dynamicBullets: true,
  },

  navigation: {
    nextEl: '.next1',
    prevEl: '.prev1',
	},
	
	breakpoints: {
		600: {
			slidesPerView:2,
		},
		968: {
			slidesPerView:3,
		},
	},
});

let swiperCard = new Swiper('.two', {
	loop: true,
	spaceBetween: 32,
	grabCursor: true,
	keyboard: {
      enabled: true,
	},

  pagination: {
		el: '.pagination2',
		clickable: true,
		dynamicBullets: true,
  },

  navigation: {
    nextEl: '.next2',
    prevEl: '.prev2',
	},
	
	breakpoints: {
		600: {
			slidesPerView:2,
		},
		968: {
			slidesPerView:3,
		},
	},
});

// end slider

// Start BMR

// class BMRCalculator {
// 	constructor(weight, height, age, gender, active) {
// 		this.weight = weight;
// 		this.height = height;
// 		this.age = age;
// 		this.gender = gender;
// 		this.active = active;
// 	}
// 	calculateBMR() {
// 		let bmr;

// 		// M: BMR = 10W + 6.25H - 5A + 5
// 		// F: BMR = 10W + 6.25H - 5A - 161

// 		bmr = 10 * this.weight + 6.25 * this.height - 5 * this.age;

// 		if (this.gender === 'male') {
// 			bmr += 5;
// 		} else if (this.gender === 'female'){
// 			bmr -= 161;
// 		}

// 		if (this.active === 'sedentary') {
// 			bmr *= 1.2;
// 		} else if (this.active === 'lightly') {
// 			bmr *= 1.375;
// 		} else if (this.active === 'moderatly') {
// 			bmr *= 1.55;
// 		} else if (this.active === 'very') {
// 			bmr *= 1.725;
// 		} else if (this.active === 'super') {
// 			bmr *= 1.9;
// 		}
// 		return bmr;
// 	}
// 	// getRsult() {
// 	// 	let bmr = this.calculateBMR;
		
// 	// }
// }
// let selectors = {
// 	form: document.getElementById('calculator'),
// 	result: document.getElementById('result'),
// 	bmr: document.getElementById('bmr'),
// };

// let render = (bmr) => {
// 	selectors.bmr.textContent = Math.round(bmr).toLocaleString('en');
// }

// let onFormSubmit = (e) => {
// 	e.preventDefault();

// 	let form = e.target;
	
// 	let weight = Number(form.weight.value);
// 	let height = Number(form.height.value);
// 	let age = Number(form.age.value);
// 	let gender = form.gender.value;
// 	let active = form.active.value;

// 	if (isNaN(weight) || isNaN(height) || isNaN(age)) {
// 		alert('Weight, Height and Age mus be numeric');
// 		return;
// 	}

// 	let calc = new BMRCalculator(weight, height, age, gender, active);

// 	render(calc.calculateBMR());

// 	selectors.result.classList.add('show');
// }

// let onFormReset = (e) => {
// 	selectors.result.classList.remove('show');
// }

// selectors.form.addEventListener('submit', onFormSubmit);
// selectors.form.addEventListener('reset', onFormReset);
// // End BMR

// Start Edit Pricing

let gear = document.querySelectorAll('.fa-gear');

gear.forEach(function (gear) {
	gear.addEventListener('click', function () {
		console.log('clicked');
		let target = gear.getAttribute('data-type');
		let card = document.getElementById(target);
		card.style.bottom = '0';
	});
});

let cancel = document.querySelectorAll('.cancel');

cancel.forEach(function (cancel) {
	cancel.addEventListener('click', function () {
		let target = cancel.getAttribute('data-type');
		let card = document.getElementById(target);
		card.style.bottom = "-100%";
	});
});

// End Edit Pricing

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

window.addEventListener('scroll', revealBox);
revealBoxs();
// End Reveal