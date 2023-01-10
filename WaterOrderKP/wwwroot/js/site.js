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


    $.ajax({
        url: '/order/index?isAjax=true&orderBy=countbottle&desc='+isArrowDown,
       // data: itemsData,
        success: function (result) {
            $('#indexTable').html(result);
        },
        beforeSend: function () {
            $('.lds-roller').show();
        },
        complete: function () {
            $('.lds-roller').hide();
        }
    });

    // get response

    // update block on page
}