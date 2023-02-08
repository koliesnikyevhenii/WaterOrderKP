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