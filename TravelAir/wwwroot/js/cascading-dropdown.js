$(document).ready(function () {
    $('#destination-country').attr('disabled', true);
    $('#destination-city').attr('disabled', true);
    $('#destination-airport').attr('disabled', true);
    $('#origin-country').attr('disabled', true);
    $('#origin-city').attr('disabled', true);
    
    LoadOriginCountries();
    LoadDestinationCountries();

    $('#destination-country').change(function () {
        var countryId = $(this).val();
        if (countryId > 0) {
            LoadDestinationCities(countryId);
        }
        else {
            alert("Select Country");
            $('#destination-city').empty();
            $('#destination-airport').empty();
            $('#destination-city').attr('disabled', true);
            $('#destination-airport').attr('disabled', true);
            $('#destination-city').append('<option>--Select City--</option>');
            $('#destination-airport').append('<option>--Select Airport--</option>');
        }
    });

    $('#destination-city').change(function () {
        var cityId = $(this).val();
        if (cityId > 0) {
            LoadDestinationAirports(cityId);
        }
        else {
            alert("Select Country");
            $('#destination-airport').empty();
            $('#destination-airport').attr('disabled', true);
            $('#destination-airport').append('<option>--Select Airport--</option>');
        }
    });





    $('#origin-country').change(function () {
        var countryId = $(this).val();
        if (countryId > 0) {
            LoadOriginCities(countryId);
        }
        else {
            alert("Select Country");
            $('#origin-city').empty();
            $('#origin-airport').empty();
            $('#origin-city').attr('disabled', true);
            $('#origin-airport').attr('disabled', true);
            $('#origin-city').append('<option>--Select City--</option>');
            $('#origin-airport').append('<option>--Select Airport--</option>')
        }
    });

    $('#origin-city').change(function () {
        var cityId = $(this).val();
        if (cityId > 0) {
            LoadOriginAirports(cityId);
        }
        else {
            alert("Select Country");
            $('#origin-airport').empty();
            $('#origin-airport').attr('disabled', true);
            $('#origin-airport').append('<option>--Select Airport--</option>');
        }
    });

})


function LoadDestinationCountries(){
    $('#destination-country').empty();


    $.ajax({
        url: '/FlightOffer/GetDestinationCountries',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#destination-country').attr('disabled', false);
                $('#destination-country').append('<option>--Select Country--</option>');
                $('#destination-city').append('<option>--Select City--</option>');
                $('#destination-airport').append('<option>--Select Airport--</option>');
                $.each(response, function (i, data) {
                    $('#destination-country').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#destination-country').attr('disabled', true);
                $('#destination-city').attr('disabled', true);
                $('#destination-airport').attr('disabled', true);
                $('#destination-country').append('<option>--No Available Countries--</option>');
                $('#destination-city').append('<option>--No Available Cities--</option>');
                $('#destination-airport').append('<option>--No Available Airports--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    })
}

function LoadDestinationCities(countryId) {
    $('#destination-city').empty();
    $('#destination-airport').empty();
    $('#destination-airport').attr('disabled', true);


    $.ajax({
        url: '/FlightOffer/GetDestinationCities?Id=' + countryId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#destination-city').attr('disabled', false);
                $('#destination-city').append('<option>--Select City--</option>');
                $('#destination-airport').append('<option>--Select Airport--</option>');
                $.each(response, function (i, data) {
                    $('#destination-city').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#destination-city').attr('disabled', true);
                $('#destination-airport').attr('disabled', true);
                $('#destination-city').append('<option>--No Available Cities--</option>');
                $('#destination-airport').append('<option>--No Available Airports--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    })
}

function LoadDestinationAirports(cityId) {
    $('#destination-airport').empty();

    $.ajax({
        url: '/FlightOffer/GetDestinationAirports?Id=' + cityId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#destination-airport').attr('disabled', false);
                $('#destination-airport').append('<option>--Select Airport--</option>');
                $.each(response, function (i, data) {
                    $('#destination-airport').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#destination-airport').attr('disabled', true);
                $('#destination-airport').append('<option>--No Available Airports--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    })
}



function LoadOriginCountries() {
    $('#origin-country').empty();

    $.ajax({
        url: '/FlightOffer/GetOriginCountries',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#origin-country').attr('disabled', false);
                $('#origin-country').append('<option>--Select Country--</option>');
                $('#origin-city').append('<option>--Select City--</option>');
                $('#origin-airport').append('<option>--Select Airport--</option>');
                $.each(response, function (i, data) {
                    $('#origin-country').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#origin-country').attr('disabled', true);
                $('#origin-city').attr('disabled', true);
                $('#origin-airport').attr('disabled', true);
                $('#origin-country').append('<option>--No Available Countries--</option>');
                $('#origin-city').append('<option>--No Available Cities--</option>');
                $('#origin-airport').append('<option>--No Available Airports--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    })
}

function LoadOriginCities(countryId) {
    $('#origin-city').empty();
    $('#origin-airport').empty();
    $('#origin-airport').attr('disabled', true);


    $.ajax({
        url: '/FlightOffer/GetOriginCities?Id=' + countryId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#origin-city').attr('disabled', false);
                $('#origin-city').append('<option>--Select City--</option>');
                $('#origin-airport').append('<option>--Select Airport--</option>');
                $.each(response, function (i, data) {
                    $('#origin-city').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#origin-city').attr('disabled', true);
                $('#origin-airport').attr('disabled', true);
                $('#origin-city').append('<option>--No Available Cities--</option>');
                $('#origin-airport').append('<option>--No Available Airports--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    })
}

function LoadOriginAirports(cityId) {
    $('#origin-airport').empty();

    $.ajax({
        url: '/FlightOffer/GetDestinationAirports?Id=' + cityId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#origin-airport').attr('disabled', false);
                $('#origin-airport').append('<option>--Select Airport--</option>');
                $.each(response, function (i, data) {
                    $('#origin-airport').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#origin-airport').attr('disabled', true);
                $('#origin-airport').append('<option>--No Available Airports--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    })
}
