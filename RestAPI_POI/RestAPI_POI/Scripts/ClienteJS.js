$(document).ready(function () {

    getdatosdeinicio();
});

function getdatosdeinicio() {
    Request("json", "application/json; charset=utf-8", "../api/clientes/GetclientesAll",
        "GET", false, null, 5000, function (data) {
            if (data !== null) {
                if (data.length > 0) {
                    $('#clientestable').DataTable({
                        data: data,
                        columns: [
                            { "data": "nombre1", title: "Nombre 1" },
                            { "data": "nombre2", title: "Nombre 2" },
                            { "data": "apellido1", title: "Apellido 1" },
                            { "data": "apellido2", title: "Apellido 2" },
                            { "data": "documento", title: "Documento" }
                        ]
                    });
                }
            } 
        });
}

function guardar() {

    var obj = {
        "id_cliente": 0,
        "nombre1": document.getElementById("nombre1").value,
        "nombre2": document.getElementById("nombre2").value,
        "apellido1": document.getElementById("apellido1").value,
        "apellido2": document.getElementById("apellido2").value,
        "documento": document.getElementById("documento").value,
        "id_TipoDocumento": 4
    };

    Request("json", "application/json; charset=utf-8", "../api/clientes/Postclientes",
        "POST", true, obj, 5000, function (data) {
            location.reload();
        });

    
}

function Request($dataType, $contentType, $url, $type, $dataJsonstringify, $data, $timeOut, function_return) {
    $.ajax({
        dataType: $dataType,
        contentType: $contentType,
        url: $url,
        type: $type,
        data: $dataJsonstringify === true ? JSON.stringify($data) : $data,
        success: function (_data) { function_return(_data); }
    });
}