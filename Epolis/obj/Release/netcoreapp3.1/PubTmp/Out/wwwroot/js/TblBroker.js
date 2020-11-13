debugger;
$(document).ready(function () {
    $("#tablebroker").DataTable({
        scrollX: true,
        // processing: true, // for show progress bar  
        "serverSide": true, // for process server side  
        "ajax": {
            "url": "/Broker/GetBroker",
            "type": "POST",
            "datatype": "JSON",
            //contentType: 'application/json; charset=utf-8',
            "dataSrc": function (json) {
                debugger;
                console.log(json)
            }
        },
        //"aaData": data,
        "columns": [
            { "data": "id", "autoWidth": true, render: function (data, type, full) { } },
            { "data": "kodebroker", "autoWidth": true},
            { "data": "namabroker", "autoWidth": true},
            { "data": "alamat", "autoWidth": true},
            { "data": "notlp", "autoWidth": true},
            { "data": "nofax", "autoWidth": true},
            { "data": "contactperson", "autoWidth": true },
            { "data": "email", "autoWidth": true},
            { "data": "updatedbyid", "autoWidth": true },
            { "data": "updatedtime", "autoWidth": true},
            { "data": "createdbyid", "autoWidth": true},
            { "data": "createdtime", "autoWidth": true},
            { "data": "isdeleted", "autoWidth": true},
            { "data": "deletedbyid", "autoWidth": true},
            { "data": "deletedtime", "autoWidth": true },
            { "data": "", "autoWidth": true, "defaultContent": "<a href='#' class='btn btn-danger'>Delete</a>" }
            //{
            //    "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=Delete('" + row.id + "'); >Delete</a>"; }
            //},
        ]
    });
});  