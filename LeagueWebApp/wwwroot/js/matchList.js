var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/profile/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "championName", "width": "25%" },
            { "data": "kills", "width": "25%" },
            { "data": "deaths", "width": "25%" },
            { "data": "assists", "width": "25%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    })
}