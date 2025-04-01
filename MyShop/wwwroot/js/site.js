    // Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//let slideIndex = 0;

//function moveSlide(step) {
//    const slides = document.querySelector(".slides");
//    const totalSlides = slides.children.length;
//    slideIndex = (slideIndex + step + totalSlides) % totalSlides;

//    // Перемещение слайдов
//    const offset = -slideIndex * 100; // Сдвиг по ширине слайда
//    slides.style.transform = `translateX(${offset}%)`;
//}

//// Автоматическая смена слайдов каждые 5 секунд
//setInterval(() => {
//    moveSlide(1);
//}, 5000);
let slideIndex = 0;

function showSlides() {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;

    slides.forEach((slide, index) => {
        slide.style.display = (index === slideIndex) ? 'block' : 'none';
    });
}

function moveSlide(step) {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;

    slideIndex = (slideIndex + step + totalSlides) % totalSlides;
    showSlides();
}

// Инициализация слайдера
document.addEventListener("DOMContentLoaded", () => {
    showSlides();
});
