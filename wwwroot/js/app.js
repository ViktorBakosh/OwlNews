$(document).ready(function() {
    $(window).scroll(function() {
      if ($(this).scrollTop() > 20) {
        $('#toTopBtn').fadeIn();
      } else {
        $('#toTopBtn').fadeOut();
      }
    });
  
    $('#toTopBtn').click(function() {
      $("html, body").animate({
        scrollTop: 0
      }, 800);
      return false;
    });
  });

