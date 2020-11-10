$(document).ready(function () {
    $('#tabla').DataTable({
        "paging": true,
         "ordering": false,
        "info": true,
        "search": false,
         "language": {
             "url": "//cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
        }
    });
});