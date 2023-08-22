$(document).ready(function () {

    $("#origin-city-search").select2({
        allowClear: true
    });
    $('#origin-city-search').prepend('<option selected=""></option>').select2({ placeholder: "--City Of Origin--" });

    $("#destination-city-search").select2({
        allowClear: true
    });
    $('#destination-city-search').prepend('<option selected=""></option>').select2({ placeholder: "--Destination City--" });

    $("#class-search").select2({
        allowClear: true

    });
    $('#class-search').prepend('<option selected=""></option>').select2({ placeholder: "--Class--" });

  

    $('#class-search').select2({
        dropdownCssClass: 'no-search'
    });



});

