function test(qwe) {

  let x = document.getElementById(qwe);
  if (x.style.opacity === '0.5') {
    x.style.opacity = '1';
  } else {
    x.style.opacity = '0.5';
  }
};