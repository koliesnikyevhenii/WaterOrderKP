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

function makeOrder() {

    if ($("#makeOrderComment") != null && $("#makeOrderComment").val() != "") {
       
        // send request ;
        $('.modal-footer .btn-secondary').click()

        $('#indexTable input:checked').each(function(e) {
            console.log($(this).attr("id"));
            // strs;
            //TODO: make in one line
            // SEND post jqury ajax request to u end point
            //$.ajax({
            //    type: "POST",
            //    url: url,     //url it's
            //    data: {"ordersIds" : strs },
            //    success: success,
            //    dataType: dataType
            //});
        });

        return;
    }
    $("#make-ord-error").text("Missed comment");
    // fill text 
}