// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const setAppThemeFromLocalStorage = () => {
    const theme = localStorage.getItem('theme') ? localStorage.getItem('theme') : 'primary'
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

const baseUserModel = {
    email: '',
    password: '',
    role: ''
}

const setCurrenUser = (user) => {
    localStorage.setItem('user', JSON.stringify(user));
}


const getCurrentUser = () => {
    const user = localStorage.getItem('user');
    if (user && user.length > 0) {
        const parsedUser = JSON.parse(user)
        if (parsedUser && parsedUser.email.length > 0) return parsedUser;
        else return baseUserModel;
    }
    
    else return baseUserModel;
}

const getUserRole = () => {
    const user = getCurrentUser()
    return user.role
}

const logout = () => {
    localStorage.setItem('user', baseUserModel);
}

const getRegisteredUserList = () => {
    const users = localStorage.getItem('registeredUsers')
    if (users && users.length > 0) {
        const parsedUsers = JSON.parse(users)
        return parsedUsers
    } else return []
}

const isUserRegistered = (user) => {
    const users = getRegisteredUserList()
    return users.find(val=>val.email === user.email)
}

const registerNewUSer = (user) => {
    const users = getRegisteredUserList()
    if (isUserRegistered(user)) {
    } else {
        users.push(user);
        localStorage.setItem('registeredUsers', JSON.stringify(users))
    }
}



const hideButtonsWithoutPerm = () => {
    const linkTeachers = document.getElementById('linkTeachers');
    const linkStudents = document.getElementById('linkStudents');
    const linkParents = document.getElementById('linkParents');
    const linkGrades = document.getElementById('linkGrades');
    const linkClasses = document.getElementById('linkClasses');
    const linkSubjects = document.getElementById('linkSubjects');

    const userRole = getUserRole();


    if (userRole !== 'admin') {
        linkTeachers.style.display = 'none'
        linkStudents.style.display = 'none'
        linkParents.style.display = 'none'
        linkGrades.style.display = 'none'
        linkClasses.style.display = 'none'
        linkSubjects.style.display = 'none'
    }

    if (userRole === 'student') {
        linkTeachers.style.display = 'block'
        linkStudents.style.display = 'block'
        linkGrades.style.display = 'block'
    }

    if (userRole === 'teacher') {
        linkTeachers.style.display = 'block'
        linkStudents.style.display = 'block'
        linkClasses.style.display = 'block'
        linkSubjects.style.display = 'block'
        linkGrades.style.display = 'block'
    }

}

document.onreadystatechange = function (e) {
    if (document.readyState === 'interactive') {
        hideButtonsWithoutPerm()
        setAppThemeFromLocalStorage()
    }
};

window.onload = function () {
    setIconThemeListeners()
/*    setCurrenUser({
        email: 'test@test.pl',
        password: '123',
        role: 'admin'
    });*/
    registerNewUSer({
        email: 'test1@test.pl',
        password: '123',
        role: 'admin'
    })
    
};
