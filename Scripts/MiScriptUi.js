

$("#checkin").datepicker({

    dateFormat: "dd-mm-yy" //no va....
});
$("#checkout").datepicker({

    dateFormat: "dd-mm-yy"
});

var array = ["miami", "new york", "florida"];


$("#location").keypress(function () {
    //alert("pulsando");-->no va hostiaaaa
    $(this).autocomplete({

        source: array
    });

});