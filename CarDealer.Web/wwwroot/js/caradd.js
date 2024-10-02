const carModels = {
    bmw: ["3 Series", "5 Series", "7 Series"],
    mercedes: ["C Series", "E Series", "S Series"],
    audi: ["A3", "A4", "A6", "Q3", "Q5", "Q7"],
    landrover: ["Range Rover", "Range Rover Sport", "Range Rover Velar"],
    volkswagen: ["Polo", "Golf", "Passat", "Tiguan", "Touareg"],
    volvo:["S60","S90","XC90"]

};

function updateModels() {
    const brandSelect = document.getElementById("carSelect");
    const modelSelect = document.getElementById("carModelSelect");
    const selectedBrand = brandSelect.value;

    // Clear model dropdown
    modelSelect.innerHTML = '<option value="" selected disabled>Model Name</option>';

    if (selectedBrand && carModels[selectedBrand]) {
        // Add models based on selected brand
        carModels[selectedBrand].forEach(function (model) {
            let option = document.createElement("option");
            option.value = model.toLowerCase();
            option.text = model;
            modelSelect.appendChild(option);
        });
    }
}
