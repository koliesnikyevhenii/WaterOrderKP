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

$("#autocompleteCountry").autocomplete({
    
    source: function (request, response) {
        jQuery.get("/Order/CountryHW", {
            term: request.term
        }, function (data) {
            response(data);
        })
    },

    select: function (event, ui) {
        jQuery.get("/Order/getcapital?country=" + ui.item.value, {
            
        }, function (data) {
            debugger;
            $('#homeworkTable').html(data);
        })
    }
});