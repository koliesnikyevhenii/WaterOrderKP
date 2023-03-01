function sortBottles(phoneNumber) {

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

    console.log(phoneNumber)
    var phone = phoneNumber != null ? phoneNumber : "";

    var actionUrl = '/order/index?isAjax=true&phoneNumber=' + phone  + '&orderBy=countbottle&desc=' + isArrowDown;
    console.log(actionUrl);

    $.ajax({
        url: actionUrl,
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
        var comments = $("#makeOrderComment").val();
        // send request ;
        $('.modal-footer .btn-secondary').click()

        $('#indexTable input:checked').each(function (e) {
            var strs = ($(this).attr("id"))

            var request = {
                ordersIds: strs,
                comment: comments
            };           
       

            console.log(request);

            $.ajax({
                type: "POST",
                url: '/order/makeorder',
                data: JSON.stringify(request),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                headers: {                  
                    'Content-Type': 'application/json'
                },
                success: function (data) {
                    $('#indexTable').html(result);
                },
                error: function (data) {
                    console.error('make order errror');
                }
            });
        });

        return;
    }

    $("#make-ord-error").text("Missed comment");
    // fill text 
}
function renderOrder(ids)
{
    $.ajax({

        url: '/order/rejectorder?id='+ids,
        success: function (data) {
            $('#indexTable').html(result);
        },
        error: function (data) {
            console.error('make order errror');
        }
    });


}