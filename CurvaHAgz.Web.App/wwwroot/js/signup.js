// Start Menu
function openmenu() {
  document.getElementById('menu').style.right = "0";
}
function closemenu() {
  document.getElementById('menu').style.right = "-235px";
}
// End Menu

// Start Show Password

let eyeIcons = document.querySelectorAll('[id^="eye"]');
let passwordInputs = document.querySelectorAll('[id^="pass"]');

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

 let pages = document.querySelectorAll(".page");
  let nextBtns = document.querySelectorAll(".next-btn, .next-1");
  let prevBtns = document.querySelectorAll(".prev-1, .prev-2");
  let steps = document.querySelectorAll(".progress-bar .step");
  let lines = document.querySelectorAll(".progress-bar span");
  let currentPage = 0;

  function showPage(index) {
    // Show only the current page
    pages.forEach((page, i) => {
      page.style.display = i === index ? "block" : "none";
    });

    // Update progress bar steps
    steps.forEach((step, i) => {
      let bullet = step.querySelector(".bullet");
      let label = step.querySelector("p");
      let check = step.querySelector(".check");

      if (i < index) {
        bullet.classList.add("active");
        label.classList.add("active");
        check.classList.add("active");
      } else if (i === index) {
        bullet.classList.add("active");
        label.classList.add("active");
        check.classList.remove("active");
      } else {
        bullet.classList.remove("active");
        label.classList.remove("active");
        check.classList.remove("active");
        }
    
    if (i - 2 < index) {
        document.querySelector(".line-1").classList.add('active');
    } else {
        document.querySelector(".line-1").classList.remove('active');
    }
    if (i - 1 < index) {
        document.querySelector(".line-2").classList.add('active');
    } else {
        document.querySelector(".line-2").classList.remove('active');
    }
    });
}

  // Show the first page initially
  showPage(currentPage);

  // Handle next buttons
  nextBtns.forEach(btn => {
    btn.addEventListener("click", () => {
      if (currentPage < pages.length - 1) {
        currentPage++;
        showPage(currentPage);
      }
    });
  });

  // Handle prev buttons
  prevBtns.forEach(btn => {
    btn.addEventListener("click", () => {
      if (currentPage > 0) {
        currentPage--;
        showPage(currentPage);
      }
    });
  });

  