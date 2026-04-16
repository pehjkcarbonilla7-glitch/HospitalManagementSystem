const api = "http://localhost:5160/api";

loadCounts();

async function loadCounts() {
    let p = await fetch(api + "/Patient");
    let patients = await p.json();

    let d = await fetch(api + "/Doctor");
    let doctors = await d.json();

    document.getElementById("patientCount").innerText = patients.length;
    document.getElementById("doctorCount").innerText = doctors.length;
}