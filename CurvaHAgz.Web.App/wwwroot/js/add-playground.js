// Start Menu
function openmenu() {
  document.getElementById('menu').style.right = "0";
}
function closemenu() {
  document.getElementById('menu').style.right = "-235px";
}
// End Menu

// Start Loading
let loading = document.querySelector(".loading");
window.addEventListener("load", function () {
  loading.style.display = "none";
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

// Start Multi-step Form
document.addEventListener('DOMContentLoaded', function() {
  let pages = document.querySelectorAll(".page");
  let nextBtns = document.querySelectorAll(".next-btn, .next-1, .next-2");
  let prevBtns = document.querySelectorAll(".prev-1, .prev-2, .prev-3");
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

      if (i <= index) {
        bullet.classList.add("active");
        label.classList.add("active");
        if (i < index) {
          check.classList.add("active");
        } else {
          check.classList.remove("active");
        }
      } else {
        bullet.classList.remove("active");
        label.classList.remove("active");
        check.classList.remove("active");
      }
    });

    // Update progress lines
    if (index >= 1) {
      document.querySelector(".line-1").classList.add('active');
    } else {
      document.querySelector(".line-1").classList.remove('active');
    }
    
    if (index >= 2) {
      document.querySelector(".line-2").classList.add('active');
    } else {
      document.querySelector(".line-2").classList.remove('active');
    }
    
    if (index >= 3) {
      document.querySelector(".line-3").classList.add('active');
    } else {
      document.querySelector(".line-3").classList.remove('active');
    }
  }

  // Show the first page initially
  showPage(currentPage);

  // Handle next buttons
  nextBtns.forEach(btn => {
    btn.addEventListener("click", () => {
      if (validateCurrentPage(currentPage)) {
        if (currentPage < pages.length - 1) {
          currentPage++;
          showPage(currentPage);
          scrollToTop();
        }
      }
    });
  });

  // Handle prev buttons
  prevBtns.forEach(btn => {
    btn.addEventListener("click", () => {
      if (currentPage > 0) {
        currentPage--;
        showPage(currentPage);
        scrollToTop();
      }
    });
  });

  // Validate form fields
  function validateCurrentPage(pageIndex) {
    let isValid = true;
    let currentPageElement = pages[pageIndex];
    
    // Get all required inputs on the current page
    let requiredInputs = currentPageElement.querySelectorAll('input[required], select[required], textarea[required]');
    
    requiredInputs.forEach(input => {
      if (!input.value.trim()) {
        let validationSpan = input.nextElementSibling;
        if (validationSpan && validationSpan.classList.contains('validation')) {
          validationSpan.textContent = `${input.getAttribute('placeholder')} is required`;
        }
        isValid = false;
      }
    });
    
    return isValid;
  }

  // Scroll to top of form when changing pages
  function scrollToTop() {
    const formContainer = document.querySelector('.form-out');
    if (formContainer) {
      formContainer.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
  }
});
// End Multi-step Form