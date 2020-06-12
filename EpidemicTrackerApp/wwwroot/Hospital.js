$(document).ready(function () {

    $('#btnLoadHospitals').click(function () {
        $.ajax({
            url: 'http://localhost:59408/api/Hospitals',
            method: 'GET',
            headers: {
                
            },
            success: function (data) {
                $('#divData').removeClass('hidden');
                $('#tblBody').empty();
                $.each(data, function (index, value) {
                    var row = $('<tr><td>' + value.hospitalId + '</td><td>'
                        + value.hospitalName + '</td><td>'
                        + value.contact + '</td><td>'
                        + value.streetNo + '</td><td>'
                        + value.area + '</td><td>'
                        + value.city + '</td><td>'
                        + value.state + '</td><td>'
                        + value.country + '</td><td>'
                        + value.zipCode + '</td>');
                    $('#tblData').append(row);
                });
            },
            error: function (jQXHR) {
                if (jQXHR.status == "401") {
                    $('#errorModal').modal('show');
                }
                else {
                    $('#divErrorText').text(jqXHR.responseText);
                    $('#divError').show('fade');
                }
            }
        });
    });
});

//$(document).ready(function () {


//    // Save the new Hospital details
//    $('#btnAdd').click(function () {
//        $.ajax({
//            url: 'http://localhost:59408/api/Hospitals',
//            method: 'POST',
//            data: {
//                hospitalName: $('#txtName').val().toString,
//                contact: $('#txtContact').val().toString,
//                streetNo: $('#Street').val(),
//                area: $('#txtArea').val().toString,
//                city: $('#txtCity').val().toString,
//                state: $('#txtState').val().toString,
//                country: $('#txtCountry').val().toString,
//                zipCode: $('#ZipCode').val()
//            },
//            success: function () {
//                $('#successModal').modal('show');
//            },
//            error: function (jqXHR) {
//                $('#divErrorText').text(jqXHR.responseText);
//                $('#divError').show('fade');
//            }
//        });
//    });
//});

const uri = 'http://localhost:59408/api/Hospitals';
function addHospitalDetail() {
    const addNameTextbox = document.getElementById('Hname');
    const addPhoneTextbox = document.getElementById('Hnumber');
    const addStreetTextbox = document.getElementById('street');
    const addAreaTextbox = document.getElementById('area');
    const addCityTextbox = document.getElementById('city');
    const addStateTextbox = document.getElementById('state');
    const addCountryTextbox = document.getElementById('country');
    const addZipCodeTextbox = document.getElementById('zip_code');

    const data =
    {
        hospitalName: addNameTextbox.value.trim(),
        contact: addPhoneTextbox.value.trim(),
        streetNo: parseInt(addStreetTextbox.value),
        area: addAreaTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
        state: addStateTextbox.value.trim(),
        country: addCountryTextbox.value.trim(),
        zipCode: parseInt(addZipCodeTextbox.value)
    };
    fetch(uri,
        {
            method: 'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        //.then(response => response.json())
        .then((data) => {
            console.log(data);

        })

        .catch(error => console.error('Unable to add data.', error));

}