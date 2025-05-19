// Loading Animation
window.addEventListener("load", function () {
  setTimeout(function () {
    document.querySelector(".loading").style.display = "none";
  }, 1000);
});

// Responsive Menu
function openmenu() {
  document.getElementById("menu").style.right = "0";
}

function closemenu() {
  document.getElementById("menu").style.right = "-200px";
}

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

// Sticky navbar
const header = document.getElementById("header");
let lastScrollY = window.scrollY;

window.addEventListener("scroll", function() {
  if (lastScrollY < window.scrollY) {
    header.style.top = "-60px";
  } else {
    header.style.top = "0";
  }
  
  lastScrollY = window.scrollY;
});

// Search and Filter Functionality
document.addEventListener('DOMContentLoaded', function() {
  const searchInput = document.getElementById('search-input');
  const filterLocation = document.getElementById('filter-location');
  const filterType = document.getElementById('filter-type');
  const playgroundCards = document.querySelectorAll('.playground-card');
  
  // Search functionality
  searchInput?.addEventListener('input', filterPlaygrounds);
  
  // Filter by location
  filterLocation?.addEventListener('change', filterPlaygrounds);
  
  // Filter by type
  filterType?.addEventListener('change', filterPlaygrounds);
  
  function filterPlaygrounds() {
    const searchTerm = searchInput?.value.toLowerCase() || '';
    const selectedLocation = filterLocation?.value.toLowerCase() || '';
    const selectedType = filterType?.value.toLowerCase() || '';
    
    playgroundCards.forEach(card => {
      const title = card.querySelector('h3').textContent.toLowerCase();
      const location = card.querySelector('.location').textContent.toLowerCase();
      const type = card.querySelector('.details span:last-child').textContent.toLowerCase();
      
      const matchesSearch = title.includes(searchTerm);
      const matchesLocation = selectedLocation === '' || location.includes(selectedLocation);
      const matchesType = selectedType === '' || type.includes(selectedType);
      
      if (matchesSearch && matchesLocation && matchesType) {
        card.style.display = 'block';
      } else {
        card.style.display = 'none';
      }
    });
  }
  
  // Pagination
  const paginationButtons = document.querySelectorAll('.pagination button');
  
  paginationButtons.forEach(button => {
    button.addEventListener('click', function() {
      // Remove active class from all buttons
      paginationButtons.forEach(btn => btn.classList.remove('active'));
      
      // Add active class to clicked button
      this.classList.add('active');
      
      // Here you would implement the logic to show different pages
      // For now, just simulating with an alert
      if (!this.classList.contains('active')) {
        alert('Loading page ' + this.textContent);
      }
    });
  });
});

// Profile Dashboard Functionality
document.addEventListener('DOMContentLoaded', function() {
  // Check if we're on the profile page
  const profileTabs = document.querySelectorAll('.profile-tabs button');
  
  if (profileTabs.length > 0) {
    profileTabs.forEach(tab => {
      tab.addEventListener('click', function() {
        // Remove active class from all tabs
        profileTabs.forEach(t => t.classList.remove('active'));
        
        // Add active class to clicked tab
        this.classList.add('active');
        
        // Here you would load different content based on the tab
        // For demonstration, just showing the tab name
        document.querySelector('.dashboard-title').textContent = this.textContent;
      });
    });
  }
  
  // Profile Navigation
  const profileNavButtons = document.querySelectorAll('.profile-navigation button');
  
  if (profileNavButtons.length > 0) {
    profileNavButtons.forEach(button => {
      button.addEventListener('click', function() {
        // Remove active class from all buttons
        profileNavButtons.forEach(btn => btn.classList.remove('active'));
        
        // Add active class to clicked button
        this.classList.add('active');
        
        // Here you would load different sections based on the navigation
        // For demonstration, just showing the section name
        document.querySelector('.dashboard-title').textContent = this.textContent;
      });
    });
  }
  
  // Playground Booking Actions
  const actionButtons = document.querySelectorAll('.dashboard-table .actions button');
  
  if (actionButtons.length > 0) {
    actionButtons.forEach(button => {
      button.addEventListener('click', function() {
        const action = this.classList.contains('edit') ? 'edit' : 'cancel';
        const row = this.closest('tr');
        const playground = row.querySelector('td:nth-child(2)').textContent;
        
        if (action === 'edit') {
          alert('Editing booking for ' + playground);
        } else {
          if (confirm('Are you sure you want to cancel your booking for ' + playground + '?')) {
            alert('Booking cancelled for ' + playground);
            // Here you would typically make an API call to update the booking status
            row.querySelector('.status').textContent = 'Cancelled';
            row.querySelector('.status').className = 'status cancelled';
          }
        }
      });
    });
  }
});

// Playground Details - Completing the cut-off section
document.addEventListener('DOMContentLoaded', function() {
  // Check if we're on the playground details page
  const playgroundDetails = document.querySelector('.playground-details');
  
  if (playgroundDetails) {
    // Image gallery functionality
    const mainImage = document.querySelector('.main-image img');
    const thumbnails = document.querySelectorAll('.thumbnail img');
    
    thumbnails.forEach(thumbnail => {
      thumbnail.addEventListener('click', function() {
        // Update main image source
        const src = this.getAttribute('src');
        mainImage.setAttribute('src', src);
        
        // Update active thumbnail
        thumbnails.forEach(thumb => thumb.classList.remove('active'));
        this.classList.add('active');
      });
    });
    
    // Booking form validation
    const bookingForm = document.getElementById('booking-form');
    
    if (bookingForm) {
      bookingForm.addEventListener('submit', function(e) {
        e.preventDefault();
        
        const dateInput = document.getElementById('booking-date');
        const timeInput = document.getElementById('booking-time');
        const durationInput = document.getElementById('booking-duration');
        
        // Simple validation
        if (!dateInput.value) {
          alert('Please select a date');
          return;
        }
        
        if (!timeInput.value) {
          alert('Please select a time');
          return;
        }
        
        if (!durationInput.value) {
          alert('Please select a duration');
          return;
        }
        
        // Check if date is not in the past
        const selectedDate = new Date(dateInput.value);
        const today = new Date();
        today.setHours(0, 0, 0, 0);
        
        if (selectedDate < today) {
          alert('Please select a date in the future');
          return;
        }
        
        // If validation passes, submit form or show confirmation
        alert('Booking submitted successfully!');
        // Here you would typically make an API call to create the booking
      });
    }
    
    // Reviews section functionality
    const reviewForm = document.getElementById('review-form');
    const reviewsList = document.querySelector('.reviews-list');
    
    if (reviewForm) {
      reviewForm.addEventListener('submit', function(e) {
        e.preventDefault();
        
        const ratingInput = document.getElementById('review-rating');
        const commentInput = document.getElementById('review-comment');
        
        // Simple validation
        if (!ratingInput.value) {
          alert('Please select a rating');
          return;
        }
        
        if (!commentInput.value) {
          alert('Please write a comment');
          return;
        }
        
        // If validation passes, add review to the list
        const newReview = document.createElement('div');
        newReview.className = 'review-item';
        
        const currentDate = new Date();
        const formattedDate = currentDate.toLocaleDateString('en-US', {
          year: 'numeric',
          month: 'long', 
          day: 'numeric'
        });
        
        newReview.innerHTML = `
          <div class="review-header">
            <div class="review-user">
              <div class="user-avatar">
                <i class="fas fa-user"></i>
              </div>
              <div class="user-info">
                <h4>You</h4>
                <p>${formattedDate}</p>
              </div>
            </div>
            <div class="review-rating">
              ${'<i class="fas fa-star"></i>'.repeat(ratingInput.value)}
              ${'<i class="far fa-star"></i>'.repeat(5 - ratingInput.value)}
            </div>
          </div>
          <div class="review-content">
            <p>${commentInput.value}</p>
          </div>
        `;
        
        // Add the new review to the top of the list
        reviewsList.insertBefore(newReview, reviewsList.firstChild);
        
        // Reset the form
        reviewForm.reset();
        
        // Show confirmation
        alert('Review submitted successfully!');
        // Here you would typically make an API call to save the review
      });
    }
  }
  
  // Playground cards click event - for navigating to details page
  const playgroundCards = document.querySelectorAll('.playground-card');
  
  playgroundCards.forEach(card => {
    card.addEventListener('click', function() {
      const playgroundId = this.getAttribute('data-id');
      const playgroundTitle = this.querySelector('h3').textContent;
      
      // For demonstration, just showing an alert
      // In a real app, you would navigate to the details page
      alert(`Navigating to details page for: ${playgroundTitle}`);
      // window.location.href = `playground-details.html?id=${playgroundId}`;
    });
  });
  
  // Book Now button functionality
  const bookNowButtons = document.querySelectorAll('.book-now');
  
  bookNowButtons.forEach(button => {
    button.addEventListener('click', function(e) {
      e.stopPropagation(); // Prevent triggering the card click event
      
      const card = this.closest('.playground-card');
      const playgroundId = card.getAttribute('data-id');
      const playgroundTitle = card.querySelector('h3').textContent;
      
      // For demonstration, just showing an alert
      // In a real app, you would navigate to the booking page
      alert(`Navigating to booking page for: ${playgroundTitle}`);
      // window.location.href = `booking.html?id=${playgroundId}`;
    });
  });
  
  // Newsletter subscription form
  const newsletterForm = document.querySelector('.footer .newsletter form');
  
  if (newsletterForm) {
    newsletterForm.addEventListener('submit', function(e) {
      e.preventDefault();
      
      const emailInput = this.querySelector('input[type="email"]');
      
      if (!emailInput.value) {
        alert('Please enter your email address');
        return;
      }
      
      // Simple email validation
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      
      if (!emailRegex.test(emailInput.value)) {
        alert('Please enter a valid email address');
        return;
      }
      
      // If validation passes, show confirmation
      alert('Thank you for subscribing to our newsletter!');
      emailInput.value = '';
      // Here you would typically make an API call to save the email
    });
  }
  
  // Initialize current date in the header
  const timeElement = document.querySelector('.header .time span');
  
  if (timeElement) {
    const currentDate = new Date();
    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    timeElement.textContent = currentDate.toLocaleDateString('en-US', options);
  }
});

// Modal functionality for login/signup
document.addEventListener('DOMContentLoaded', function() {
  // Open modal buttons
  const loginButton = document.querySelector('.login-button');
  const signupButton = document.querySelector('.signup-button');
  const modalOverlay = document.querySelector('.modal-overlay');
  const loginModal = document.querySelector('.login-modal');
  const signupModal = document.querySelector('.signup-modal');
  const closeButtons = document.querySelectorAll('.close-modal');
  
  // Check if elements exist before adding event listeners
  if (loginButton) {
    loginButton.addEventListener('click', function() {
      modalOverlay.style.display = 'flex';
      loginModal.style.display = 'block';
      signupModal.style.display = 'none';
    });
  }
  
  if (signupButton) {
    signupButton.addEventListener('click', function() {
      modalOverlay.style.display = 'flex';
      loginModal.style.display = 'none';
      signupModal.style.display = 'block';
    });
  }
  
  // Close buttons
  closeButtons.forEach(button => {
    button.addEventListener('click', function() {
      modalOverlay.style.display = 'none';
    });
  });
  
  // Close modal when clicking outside
  if (modalOverlay) {
    modalOverlay.addEventListener('click', function(e) {
      if (e.target === modalOverlay) {
        modalOverlay.style.display = 'none';
      }
    });
  }
  
  // Modal form submissions
  const loginForm = document.getElementById('login-form');
  const signupForm = document.getElementById('signup-form');
  
  if (loginForm) {
    loginForm.addEventListener('submit', function(e) {
      e.preventDefault();
      
      const email = document.getElementById('login-email').value;
      const password = document.getElementById('login-password').value;
      
      // Simple validation
      if (!email || !password) {
        alert('Please fill in all fields');
        return;
      }
      
      // Here you would typically make an API call to authenticate the user
      alert('Login successful!');
      modalOverlay.style.display = 'none';
      // Simulate successful login
      updateUserInterface(true);
    });
  }
  
  if (signupForm) {
    signupForm.addEventListener('submit', function(e) {
      e.preventDefault();
      
      const name = document.getElementById('signup-name').value;
      const email = document.getElementById('signup-email').value;
      const password = document.getElementById('signup-password').value;
      const confirmPassword = document.getElementById('signup-confirm-password').value;
      
      // Simple validation
      if (!name || !email || !password || !confirmPassword) {
        alert('Please fill in all fields');
        return;
      }
      
      if (password !== confirmPassword) {
        alert('Passwords do not match');
        return;
      }
      
      // Here you would typically make an API call to create the user account
      alert('Account created successfully!');
      modalOverlay.style.display = 'none';
      // Simulate successful signup
      updateUserInterface(true);
    });
  }
  
  // Function to update UI based on authentication status
  function updateUserInterface(isLoggedIn) {
    const authButtons = document.querySelector('.auth-buttons');
    const userProfile = document.querySelector('.user-profile-menu');
    
    if (isLoggedIn) {
      if (authButtons) authButtons.style.display = 'none';
      if (userProfile) userProfile.style.display = 'flex';
    } else {
      if (authButtons) authButtons.style.display = 'flex';
      if (userProfile) userProfile.style.display = 'none';
    }
  }
  
  // Check for saved login state (in a real app, this would be a token check)
  const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
  updateUserInterface(isLoggedIn);
});