// Mobile menu toggle
function openmenu() {
    document.getElementById("menu").style.right = "0";
  }

  function closemenu() {
    document.getElementById("menu").style.right = "-200px";
  }

  // Image gallery functionality
  function changeImage(thumbnail, imgSrc) {
    // Update main image
    document.getElementById("main-image").src = imgSrc;

    // Update active thumbnail
    let thumbnails = document.getElementsByClassName("thumbnail");
    for (let i = 0; i < thumbnails.length; i++) {
      thumbnails[i].classList.remove("active");
    }
    thumbnail.classList.add("active");
  }

  // Booking form calculations
  document.addEventListener("DOMContentLoaded", function () {
    // Variables
    const basePrice = 60;
    let hoursCount = document.getElementById("hours-count");
    let totalPrice = document.getElementById("total-price");
    let durationSelect = document.getElementById("duration");

    // Update price calculation
    durationSelect.addEventListener("change", function () {
      let duration = parseInt(this.value);
      let price = basePrice * duration;

      hoursCount.textContent = duration;
      totalPrice.textContent = "$" + price;
    });

    // Set current date as minimum date for booking
    let today = new Date();
    let dd = String(today.getDate()).padStart(2, "0");
    let mm = String(today.getMonth() + 1).padStart(2, "0");
    let yyyy = today.getFullYear();

    let minDate = yyyy + "-" + mm + "-" + dd;
    document.getElementById("booking-date").setAttribute("min", minDate);

    // Handle form submission
    document
      .getElementById("booking-form")
      .addEventListener("submit", function (e) {
        e.preventDefault();

        // Here you would normally send the form data to the server
        // For now, show a success message
        alert(
          "Booking successful! You will receive a confirmation email shortly."
        );
        this.reset();
      });
  });

  // Calendar Navigation
  document.addEventListener("DOMContentLoaded", function () {
    let currentDate = new Date();
    let currentMonth = currentDate.getMonth();
    let currentYear = currentDate.getFullYear();

    const monthNames = [
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December",
    ];

    function updateCalendarHeader() {
      document.getElementById(
        "current-month"
      ).textContent = `${monthNames[currentMonth]} ${currentYear}`;
    }

    document
      .getElementById("prev-month")
      .addEventListener("click", function () {
        currentMonth--;
        if (currentMonth < 0) {
          currentMonth = 11;
          currentYear--;
        }
        updateCalendarHeader();
        // Here you would update the calendar days as well
      });

    document
      .getElementById("next-month")
      .addEventListener("click", function () {
        currentMonth++;
        if (currentMonth > 11) {
          currentMonth = 0;
          currentYear++;
        }
        updateCalendarHeader();
        // Here you would update the calendar days as well
      });
  });

  // Reveal animations on scroll
  function reveal() {
    var reveals = document.querySelectorAll(".reveal");

    for (var i = 0; i < reveals.length; i++) {
      var windowHeight = window.innerHeight;
      var elementTop = reveals[i].getBoundingClientRect().top;
      var elementVisible = 150;

      if (elementTop < windowHeight - elementVisible) {
        reveals[i].classList.add("active");
      }
    }
  }

  window.addEventListener("scroll", reveal);

  // Loading animation
  window.addEventListener("load", function () {
    setTimeout(function () {
      document.querySelector(".loading").style.display = "none";
    }, 1000);
  });

  // Load More Reviews
  document
    .querySelector(".load-more-reviews")
    .addEventListener("click", function () {
      // Here you would load more reviews from the server
      this.textContent = "Loading...";
      setTimeout(() => {
        this.textContent = "No More Reviews";
        this.disabled = true;
      }, 1000);
    });

  // To handle URL parameters and fill in playground data
document.addEventListener("DOMContentLoaded", function () {
    // Get playground ID from URL if present
    const urlParams = new URLSearchParams(window.location.search);
    const playgroundId = urlParams.get("id");

    // Get the element
    const playgroundNameElem = document.getElementById("playground-name");

    // Only set the title if the element exists
    if (playgroundNameElem) {
        document.title = playgroundNameElem.textContent + " | Curva Hagz";
    }
});




  // Scroll to top button
const scrollBtn = document.querySelector(".scroll");

window.addEventListener("scroll", function () {
  if (this.scrollY >= 500) {
    scrollBtn.classList.add("show");
  } else {
    scrollBtn.classList.remove("show");
  }
});

scrollBtn.addEventListener("click", function () {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
});

// Animation on Scroll
function reveal() {
  const reveals = document.querySelectorAll(".reveal");
  
  for (let i = 0; i < reveals.length; i++) {
    const windowHeight = window.innerHeight;
    const elementTop = reveals[i].getBoundingClientRect().top;
    const elementVisible = 150;
    
    if (elementTop < windowHeight - elementVisible) {
      reveals[i].classList.add("active");
    } else {
      reveals[i].classList.remove("active");
    }
  }
}

window.addEventListener("scroll", reveal);

// To check the scroll position on page load
reveal();