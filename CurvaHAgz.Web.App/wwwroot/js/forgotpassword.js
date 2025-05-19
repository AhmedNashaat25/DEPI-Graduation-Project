// Forgot Password JavaScript
// This script extends the existing signup.js with added functionality for the forgot password page

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

// Form validation
document.addEventListener('DOMContentLoaded', function() {
  const form = document.querySelector('form');
  const emailInput = document.getElementById('reset-email');
  const validationSpan = document.querySelector('.validation');
  
  if (form) {
    form.addEventListener('submit', function(e) {
      if (!validateEmail(emailInput.value)) {
        e.preventDefault();
        validationSpan.textContent = 'Please enter a valid email address';
      }
    });
  }
  
  // Email validation helper function
  function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }
  
  // Clear validation message when user starts typing
  if (emailInput) {
    emailInput.addEventListener('input', function() {
      validationSpan.textContent = '';
    });
  }
});

// Success/Error message animation
document.addEventListener('DOMContentLoaded', function() {
  const message = document.querySelector('.message');
  
  if (message) {
    // Add entrance animation class
    message.classList.add('show');
    
    // Auto-hide message after 5 seconds
    setTimeout(function() {
      message.style.opacity = '0';
      setTimeout(function() {
        message.style.display = 'none';
      }, 600);
    }, 5000);
  }
});