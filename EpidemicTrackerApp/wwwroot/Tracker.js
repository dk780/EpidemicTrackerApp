{
    function cured() {
        document.getElementById("demo").innerHTML = "CURED PATIENTS LIST";
        fetch("http://localhost:59408/api/TreatmentRecords/GetCuredPatients")
            .then(response => response.json())
            .then(json => {
                let li = `<tr>
                        <th>Patient Name</th>
                        <th>AadharID</th>
                        <th>PContact</th>
                        <th>Hospital Name</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Admitted Date</th>
                        <th>Prescription</th>
                        <th>Relieving Date</th>
                        <th>IsFatal</th>
                        <th>Currentstage</th>



                        </tr>`;
                json.forEach(patient => {
                    li += `<tr> 
            <td>${patient.patientName} </td> 
            <td>${patient.aadharID}</td> 
            <td>${patient.pContact}</td>  
            <td>${patient.hospitalName}</td>  
            <td>${patient.city}</td>  
            <td>${patient.state}</td>  
            <td>${patient.admittedDate}</td>  
            <td>${patient.prescription}</td>  
            <td>${patient.relievingDate}</td>  
            <td>${patient.isFatal}</td>  
            <td>${patient.currentstage}</td>  

        </tr>`;
                });
                document.getElementById("patients").innerHTML = li;
            });
    }

    function noncured() {
        document.getElementById("demo").innerHTML = "NON-CURED PATIENTS LIST";
        fetch("http://localhost:59408/api/TreatmentRecords/GetUnCuredPatients")
            .then(response => response.json())
            .then(json => {
                let li = `<tr>
                        <th>Patient Name</th>
                        <th>AadharID</th>
                        <th>PContact</th>
                        <th>Hospital Name</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Admitted Date</th>
                        <th>Prescription</th>
                        <th>Relieving Date</th>
                        <th>IsFatal</th>
                        <th>Currentstage</th>



                        </tr>`;
                json.forEach(patient => {
                    li += `<tr> 
            <td>${patient.patientName} </td> 
            <td>${patient.aadharID}</td> 
            <td>${patient.pContact}</td>  
            <td>${patient.hospitalName}</td>  
            <td>${patient.city}</td>  
            <td>${patient.state}</td>  
            <td>${patient.admittedDate}</td>  
            <td>${patient.prescription}</td>  
            <td>${patient.relievingDate}</td>  
            <td>${patient.isFatal}</td>  
            <td>${patient.currentstage}</td>  

        </tr>`;
                });
                document.getElementById("patients").innerHTML = li;
            });
    }

    function deceased() {
        document.getElementById("demo").innerHTML = "DECEASED PATIENTS LIST";
        fetch("http://localhost:59408/api/TreatmentRecords/GetDeceased")
            .then(response => response.json())
            .then(json => {
                let li = `<tr>
                        <th>Patient Name</th>
                        <th>AadharID</th>
                        <th>PContact</th>
                        <th>Hospital Name</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Admitted Date</th>
                        <th>Prescription</th>
                        <th>Relieving Date</th>
                        <th>IsFatal</th>
                        <th>Currentstage</th>



                        </tr>`;
                json.forEach(patient => {
                    li += `<tr> 
            <td>${patient.patientName} </td> 
            <td>${patient.aadharID}</td> 
            <td>${patient.pContact}</td>  
            <td>${patient.hospitalName}</td>  
            <td>${patient.city}</td>  
            <td>${patient.state}</td>  
            <td>${patient.admittedDate}</td>  
            <td>${patient.prescription}</td>  
            <td>${patient.relievingDate}</td>  
            <td>${patient.isFatal}</td>  
            <td>${patient.currentstage}</td>  

        </tr>`;
                });
                document.getElementById("patients").innerHTML = li;
            });
    }
}