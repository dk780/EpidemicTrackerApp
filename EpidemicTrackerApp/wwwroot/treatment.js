const uri = 'http://localhost:59408/api/TreatmentRecords';
function TreatmentDetails() {
    const addNameTextbox = document.getElementById('patientname');
    const addAgeTextbox = document.getElementById('page');
    const addGenderSelectbox = document.getElementById('gender');
    const addEmailTextbox = document.getElementById('pemail');
    const addAadharIDTextbox = document.getElementById('aadharid');
    const addContactTextbox = document.getElementById('patientcontact');
    const addAddressTypeTextbox = document.getElementById('addresstype');
    const addStreetTextbox = document.getElementById('street');
    const addAreaTextbox = document.getElementById('area');
    const addCityTextbox = document.getElementById('city');
    const addStateTextbox = document.getElementById('state');
    const addCountryTextbox = document.getElementById('country');
    const addZipCodeTextbox = document.getElementById('zipcode');
    const addOccupationNameTextbox = document.getElementById('occupationname');
    const addOccupationTypeTextbox = document.getElementById('occupationtype');
    const addOrganisationNameTextbox = document.getElementById('organisationname');
    const addOrganisationTypeTextbox = document.getElementById('organisationtype');
    const addOrg_AddressTypeTextbox = document.getElementById('addresstype');
    const addOrg_StreetTextbox = document.getElementById('street');
    const addvAreaTextbox = document.getElementById('area');
    const addOrg_CityTextbox = document.getElementById('city');
    const addOrg_StateTextbox = document.getElementById('state');
    const addOrg_CountryTextbox = document.getElementById('country');
    const addOrg_ZipCodeTextbox = document.getElementById('zipcode');
    const addHospitalNameTextbox = document.getElementById('hospitalname');
    const addHospitalContactTextbox = document.getElementById('contact');
    const addHos_AddressTypeTextbox = document.getElementById('addresstype');
    const addHos_StreetTextbox = document.getElementById('street');
    const addHos_AreaTextbox = document.getElementById('area');
    const addHos_CityTextbox = document.getElementById('city');
    const addHos_StateTextbox = document.getElementById('state');
    const addHos_CountryTextbox = document.getElementById('country');
    const addHos_ZipCodeTextbox = document.getElementById('zipcode');
    const addDiseaseNameTextbox = document.getElementById('diseasename');
    const addDiseaseTypeTextbox = document.getElementById('diseasetype');
    const addAdmittedDateTextbox = document.getElementById('admitdate');
    const addPrescriptionTextbox = document.getElementById('prescription');
    const addRelievingDateTextbox = document.getElementById('relievingdate');
    const addIsFatalTextbox = document.getElementById('isfatal');
    const addCurrentstageTextbox = document.getElementById('currentstage');




    const data =
    {
        patientName: addNameTextbox.value.trim(),
        pAge: parseInt(addAgeTextbox.value),
        pGender: addGenderSelectbox.value.trim(),
        pEmail: addEmailTextbox.value.trim(),
        aadharID: addAadharIDTextbox.value.trim(),
        pContact: parseFloat(addContactTextbox.value),
        addressType: addAddressTypeTextbox.value.trim(),
        streetNo: parseInt(addStreetTextbox.value),
        area: addAreaTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
        state: addStateTextbox.value.trim(),
        country: addCountryTextbox.value.trim(),
        zipCode: parseInt(addZipCodeTextbox.value),
        occupationName: addOccupationNameTextbox.value.trim(),
        occupationType: addOccupationTypeTextbox.value.trim(),
        organisationName: addOrganisationNameTextbox.value.trim(),
        organisationType: addOrganisationTypeTextbox.value.trim(),
        org_AddressType: addOrg_AddressTypeTextbox.value.trim(),
        org_StreetNo: parseInt(addOrg_StreetTextbox.value),
        org_Area: addOrg_AreaTextbox.value.trim(),
        org_City: addOrg_CityTextbox.value.trim(),
        org_State: addOrg_StateTextbox.value.trim(),
        org_Country: addOrg_CountryTextbox.value.trim(),
        org_ZipCode: parseInt(addOrg_ZipCodeTextbox.value),
        hospitalName: addHospitalNameTextbox.value.trim(),
        contact: addHospitalContactTextbox.value.trim(),
        hos_AddressType: addHos_AddressTypeTextbox.value.trim(),
        hos_StreetNo: parseInt(addHos_StreetTextbox.value),
        hos_Area: addHos_AreaTextbox.value.trim(),
        hos_City: addHos_CityTextbox.value.trim(),
        hos_State: addHos_StateTextbox.value.trim(),
        hos_Country: addHos_CountryTextbox.value.trim(),
        hos_ZipCode: parseInt(addHos_ZipCodeTextbox.value),
        diseaseName: addDiseaseNameTextbox.value.trim(),
        diseaseType: addDiseaseTypeTextbox.value.trim(),
        admittedDate: addAdmittedDateTextbox.value.trim(),
        prescription: addPrescriptionTextbox.value.trim(),
        relievingDate: addRelievingDateTextbox.value.trim(),
        isFatal: addIsFatalTextbox.value.trim(),
        currentstage: addCurrentstageTextbox.value.trim()
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