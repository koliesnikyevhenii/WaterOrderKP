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
        var comment = $("#makeOrderComment").val();
        // send request ;
        $('.modal-footer .btn-secondary').click()

        $('#indexTable input:checked').each(function (e) {
            var strs = ($(this).attr("id"))
            
            $.ajax({
                type: "POST",
                url: '/order/makeorder',
                data: { "ordersIds": strs, "comment": comment },
                dataType: "application/json",
                success: function (data) {
                    console.log(`success`);
                },
                error: function (data) {
                    console.error(`make order errror`);
                }

            });
        });

        return;
    }
    $("#make-ord-error").text("Missed comment");
    // fill text 
}