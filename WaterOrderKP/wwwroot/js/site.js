function sortBottles() {
    var element = document.getElementById('arrow-element');
    var isArrowDown = element.classList.contains('arrow-down');

    if (isArrowDown) {
        
        element.classList.remove("arrow-down");
        element.classList.add("arrow-up");
    }
    else {
        element.classList.remove("arrow-up");
        element.classList.add("arrow-down");
    }
}