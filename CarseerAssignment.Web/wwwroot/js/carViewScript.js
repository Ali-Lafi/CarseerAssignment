$(document).ready(function () {
    const dropdown = $('#makeId');
    const selectedMakeInput = $('#selectedMake');
    const alertPlaceholder = $('#alertPlaceholder');
    let allMakes = [];

    function showAlert(message, type) {
        if (!message) {
            alertPlaceholder.html('').hide(); 
            return;
        }

        const alertHtml = `
            <div class="alert alert-${type} alert-dismissible fade show" role="alert">
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        `;
        alertPlaceholder.html(alertHtml).show();
    }

    function fetchCarMakes() {
        $.ajax({
            url: '/Car/GetCarMakes',
            type: 'GET',
            success: function (data) {
                allMakes = data;
                loadMakes(0, 50);
            },
            error: function () {
                showAlert('Failed to load car makes.', 'danger');
            }
        });
    }

    function loadMakes(start, count) {
        const makesToLoad = allMakes.slice(start, start + count);
        makesToLoad.forEach(make => {
            dropdown.append(`<option value="${make.makeId}">${make.makeName}</option>`);
        });
    }

    fetchCarMakes();

    dropdown.on('scroll', function () {
        if ($('#makeSearch').val().trim() !== '') return;

        const scrollTop = dropdown.prop('scrollTop');
        const scrollHeight = dropdown.prop('scrollHeight');
        const clientHeight = dropdown.prop('clientHeight');

        if (scrollTop + clientHeight >= scrollHeight) {
            if (dropdown.children().length < allMakes.length) {
                const nextBatchStart = dropdown.children().length;
                loadMakes(nextBatchStart, 50);
            }
        }
    });

    dropdown.on('change', function () {
        const selectedText = dropdown.find('option:selected').text();
        selectedMakeInput.val(selectedText);
    });

    function resetDropdown() {
        if ($('#makeSearch').val().trim() === '') return;
        $('#makeSearch').val('');
        dropdown.empty();
        loadMakes(0, 50);
    }

    $('#makeSearch').on('input', function () {
        const searchTerm = $(this).val().toLowerCase();
        if (searchTerm.trim() === '') {
            resetDropdown();
            return;
        }

        const filteredMakes = allMakes.filter(make =>
            make.makeName.toLowerCase().includes(searchTerm)
        );

        dropdown.empty();
        filteredMakes.forEach(make => {
            dropdown.append(`<option value="${make.makeId}">${make.makeName}</option>`);
        });
    });

    $('#clearSearch').on('click', function () {
        resetDropdown();
    });

    $('#submitButton').click(function () {
        const makeId = dropdown.val();
        const year = $('#year').val();

        if (!makeId || !year) {
            showAlert('Please select a make and enter a valid year.', 'warning');
            return;
        }

        $.ajax({
            url: `/Car/GetVehicleTypes?makeId=${makeId}`,
            type: 'GET',
            success: function (data) {
                const vehicleTypesBody = $('#vehicleTypes tbody');
                vehicleTypesBody.empty();
                if (data.length > 0) {
                    $('#vehicleTypesResultsContainer').show();
                    data.forEach(type => {
                        vehicleTypesBody.append(
                            `<tr><td>${type.vehicleTypeName}</td></tr>`
                        );
                    });
                } else {
                    $('#vehicleTypesResultsContainer').hide();
                }

                showAlert('', ''); 
            },
            error: function () {
                showAlert('Failed to load vehicle types.', 'danger');
            }
        });

        $.ajax({
            url: `/Car/GetModels?makeId=${makeId}&year=${year}`,
            type: 'GET',
            success: function (data) {
                const carModelsBody = $('#carModels tbody');
                carModelsBody.empty();
                if (data.length > 0) {
                    $('#carModelsResultsContainer').show();
                    data.forEach(model => {
                        carModelsBody.append(
                            `<tr><td>${model.modelName}</td></tr>`
                        );
                    });

                    showAlert('', ''); 
                } else {
                    $('#carModelsResultsContainer').hide();
                }
            },
            error: function () {
                showAlert('Failed to load car models.', 'danger');
            }
        });
    });
});
