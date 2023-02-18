$("#water-autocomplete").autocomplete({
    source: function (request, response) {
        console.log(request);

        jQuery.get("/Order/OrdersPhone", {
            term: request.term
        }, function (data) {
            response(data);
        })
    },

    select: function (event, ui) {  
        debugger;
        sortBottles(ui.item.value)
    }
});

$("#country-autocomplete").autocomplete({
    source: function (request, response) {
        //console.log(request);

        jQuery.get("/Home/CountryCity", {
            term: request.term
        }, function (data) {
            response(data);
        })
    },

    select: function (event, ui) {
        console.log(ui.item.value)
        //jQuery.get("/Home/getcapital?country=" + ui.item.value, {},
        //    function (data) {
        //        debugger;
        //        $('#Getcapital').html(data);
        //    })


        jQuery.get("/Home/getcapital2?country=" + ui.item.value, {},
            function (data) {
                console.log(data);
                $('#Getcapital').text(data.country + ":" + data.city);
            })


        //console.log(ui.item.value)
        //sortBottles(ui.item.value)
    }
});