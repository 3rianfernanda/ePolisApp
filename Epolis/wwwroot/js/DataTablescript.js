$(document).ready(function () {
    $('#table').DataTable({
        scrollX: true,
        //"paging": false,
        "ordering": false,
        //"searching": false
    });
});

//debugger;
//$(document).ready(function () {
//    $("#tablebroker").DataTable({
//        scrollX: true,
//        "processing": true, // for show progress bar  
//        "serverSide": true, // for process server side  
//        "ajax": {
//            "url": "/Broker/GetBroker",
//            "type": "POST",
//            "datatype": "JSON",
//            "dataSrc": function (json) {
//                debugger;
//                console.log(json)
//            }
//        },
//        "columnDefs": [{
//            "targets": [10],
//            "visible": false,
//            "searchable": false
//        }],
//        "columns": [
//            { "data": "id", "autoWidth": true, "defaultContent":"" },
//            { "data": "kodebroker", "autoWidth": true },
//            { "data": "namabroker", "autoWidth": true },
//            { "data": "alamat","autoWidth": true },
//            { "data": "notlp", "autoWidth": true },
//            { "data": "nofax", "autoWidth": true },
//            { "data": "contactperson",  "autoWidth": true },
//            { "data": "email", "autoWidth": true },
//            { "data": "updatedbyid","autoWidth": true },
//            { "data": "updatedtime", "autoWidth": true },
//            { "data": "createdbyid", "autoWidth": true },
//            { "data": "createdtime", "autoWidth": true },
//            { "data": "isdeleted", "autoWidth": true },
//            { "data": "deletedbyid", "autoWidth": true },
//            { "data": "deletedtime", "autoWidth": true },
//            {
//                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=Delete('" + row.id + "'); >Delete</a>"; }
//            },
//        ]
//    });
//});  
//$(document).ready(function () {
//    $('#tablebroker').DataTable({
//        data: data,
//        scrollX: true,
//        processing: true, // for show progress bar  
//        serverSide: true, // for process server side  
//        ajax: {
//            url: '/Broker/GetBroker',
//            type: 'POST',
//            datatype: 'JSON',
//            dataSrc: '',
//            columns: [
//                { data: 'ID' },
//                { data: 'KODEBROKER' },
//                { data: 'NAMABROKER' },
//                { data: 'ALAMAT' },
//                { data: 'NOTLP' },
//                { data: 'CONTACTPERSON' },
//                { data: 'EMAIL' },
//                { data: 'UPDATEDBYID' },
//                { data: 'UPDATEDBYTIME' },
//                { data: 'CREATEDBYID' },
//                { data: 'CREATEDBYTIME' },
//                { data: 'CREATEDBYID' },
//                { data: 'ISDELETED' },
//                { data: 'DELETEDBYID' },
//                { data: 'DELETEDBYTIME' },
//            ]
//        }
//    });
//})
