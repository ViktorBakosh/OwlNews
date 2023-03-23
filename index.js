function test(qwe) {

  let x = document.getElementById(qwe);
  if (x.style.opacity === '0.5') {
    x.style.opacity = '1';
  } else {
    x.style.opacity = '0.5';
  }
};

$(document).ready(function() {
  $(window).scroll(function() {
    if ($(this).scrollTop() > 20) {
      $('#topBtn').fadeIn();
    } else {
      $('#topBtn').fadeOut();
    }
  });

  $('#topBtn').click(function() {
    $("html, body").animate({
      scrollTop: 0
    }, 800);
    return false;
  });
});
