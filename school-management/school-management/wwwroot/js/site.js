// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const setAppThemeFromLocalStorage = () => {
    const theme = localStorage.getItem('theme')
    const body = document.getElementsByTagName('body')[0]
    body.className = theme
    const mainContent = document.getElementById('mainContent')
    mainContent.style.display = 'block'
}

const setThemeToLocalStorage = (theme) => {
    localStorage.setItem('theme', theme);
    setAppThemeFromLocalStorage();
}

const setIconThemeListeners = () => {
    const primaryThemeIcon = document.getElementById('primaryThemeIcon')
    const darkThemeIcon = document.getElementById('darkThemeIcon')
    const contrastThemeIcon = document.getElementById('contrastThemeIcon')
    primaryThemeIcon.addEventListener('click', () => {
        setThemeToLocalStorage('primary')
    })
    darkThemeIcon.addEventListener('click', ()=>{
        setThemeToLocalStorage('dark')
    })
    contrastThemeIcon.addEventListener('click', ()=>{
        setThemeToLocalStorage('contrast')
    })
}

document.onreadystatechange = function (e) {
    if (document.readyState === 'interactive') {
        setAppThemeFromLocalStorage()
    }
};

window.onload = function () {
    setIconThemeListeners()
    console.log('Essa')
};
