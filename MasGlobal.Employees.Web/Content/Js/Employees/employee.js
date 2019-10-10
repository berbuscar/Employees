function ConsularEmpleados() {
    var inputIdEmployee = $("#inputIdEmployee");
    var $buttonConsultar = $("#btnGetInfoEmployee");
    var urlConsulta = $buttonConsultar.data("datos");
    $('#loadingmessage').show(); 

    //sleep(3000);

    $.ajax({
        async: false,
        cache: false,
        type: "POST",
        dataType: "json",
        url: urlConsulta,
        data: { "IdEmployee": inputIdEmployee.val() },
        success: function (response) {
            var datatable = $('#tableListEmployees').DataTable();
            datatable.clear();
            datatable.rows.add(response);
            datatable.draw();
            
        },
        error: function (error) {
            var errorMessage = error.statusText;
            alert(errorMessage);
        },
        complete: function (data) {
            $('#loadingmessage').hide();
        }
    });
}

function sleep(delay) {
    var start = new Date().getTime();
    while (new Date().getTime() < start + delay);
}

function registrarEventos() {
    $('#btnGetInfoEmployee').on('click', ConsularEmpleados);
}

function inicializar() {
    configurarTabla();
}

function configurarTabla() {
    $('#tableListEmployees').DataTable({
        "searching": false,
        "paging": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        },
        "columnDefs": [
            { "title": "Id", "targets": 0 },
            { "title": "Name", "targets": 1 },
            { "title": "Contract Type Name", "targets": 2 },
            { "title": "Role Id", "targets": 3 },
            { "title": "Role Name", "targets": 4 },
            { "title": "Role Description", "targets": 5 },
            { "title": "HourlySalary", "targets": 6 },
            { "title": "Monthly Salary", "targets": 7 },
            { "title": "Annual Salary", "targets": 8 }
        ],
        columns: [
            { "data": "Id" },
            { "data": "Name" },
            { "data": "ContractTypeName" },
            { "data": "RoleId" },
            { "data": "RoleName" },
            { "data": "RoleDescription" },
            { "data": "HourlySalary" },
            { "data": "MonthlySalary" },
            { "data": "AnnualSalary" }
        ]
    });

}

$(function () {
    inicializar();
    registrarEventos();
});