const api = "http://localhost:5160/api";

// SWITCH SECTIONS
function show(section) {
    document.querySelectorAll('.section').forEach(s => s.style.display = "none");
    document.getElementById(section).style.display = "block";
}

/* ================= PATIENT ================= */
async function addPatient() {
    await fetch(api + "/Patient", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("pName").value,
            age: parseInt(document.getElementById("pAge").value),
            gender: document.getElementById("pGender").value
        })
    });

    alert("Patient Added");
}

/* ================= DOCTOR ================= */
async function addDoctor() {
    await fetch(api + "/Doctor", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("dName").value,
            specialization: document.getElementById("dSpec").value,
            phone: document.getElementById("dPhone").value
        })
    });

    alert("Doctor Added");
}

/* ================= APPOINTMENT ================= */
async function addAppointment() {
    await fetch(api + "/Appointment", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            patientId: parseInt(document.getElementById("aPatientId").value),
            doctorId: parseInt(document.getElementById("aDoctorId").value),
            appointmentDate: document.getElementById("aDate").value,
            status: "Pending"
        })
    });

    alert("Appointment Added");
}