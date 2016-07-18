$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "WebMethods.aspx/GetTypes",
        data: JSON.stringify({ "addSelect": true }),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if($('#cmbVehicleType option').length == 0){
                $.each(JSON.parse(msg.d), function (i, item) {
                    $('#cmbVehicleType').append($("<option></option>").val(item.id).html(item.name));

                
                });
                $('#cmbManufacturer').empty();
                $('#cmbModel').empty();
                $('#cmbEngine').empty();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        }
    });
    $('#cmbVehicleType').change(GetManufacturers);
    $('#cmbManufacturer').change(GetModels);
    $('#cmbModel').change(GetEngines);
    $('#cmbEngine').change(GetEngine);
})

function GetManufacturers() {
    var typeID = $('#cmbVehicleType').val();
    if (typeID != 'Odaberi') {
        $('#findVehiclePleaseWait').show();
        $.ajax({
            type: "POST",
            url: "WebMethods.aspx/GetManufacturers",
            data: JSON.stringify({ "addSelect": true, "type": typeID }),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#cmbManufacturer').empty();
                $.each(JSON.parse(msg.d), function (i, item) {
                    $('#cmbManufacturer').append($("<option></option>").val(item.id).html(item.name));
                });
                $('#findVehiclePleaseWait').hide();
            }

        });
        
    }
    else {
        $('#cmbManufacturer').empty();
    }
    $('#cmbModel').empty();
    $('#cmbEngine').empty();
}

function GetModels() {
    var manufacturer = $('#cmbManufacturer').val();
    var type = $('#cmbVehicleType').val();
    if (manufacturer != 'Odaberi') {
        $('#findVehiclePleaseWait').show();
        $.ajax({
            type: "POST",
            url: "WebMethods.aspx/GetModels",
            data: JSON.stringify({ "addSelect": true, "manufacturer": manufacturer, "type": type }),
            contentType: "application/json;chrset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#cmbModel').empty();
                $.each(JSON.parse(msg.d), function (i, item) {
                    $('#cmbModel').append($("<option></option>").val(item.id).html(item.name));
                });
                $('#findVehiclePleaseWait').hide();
            }
        });
        
    }
    else {
        $('#cmbModel').empty();
    }
    $('#cmbEngine').empty();
}

function GetEngines()
{
    var modelID = $('#cmbModel').val();
    if (modelID != 'Odaberi') {
        $('#findVehiclePleaseWait').show();
        $.ajax({
            type: "POST",
            url: "WebMethods.aspx/GetEngines",
            data: JSON.stringify({ "addSelect": true, "modelUrl": modelID, "manufacturerUrl": $('#cmbManufacturer').val() }),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#cmbEngine').empty();
                $.each(JSON.parse(msg.d), function (i, item) {
                    $('#cmbEngine').append($("<option></option>").val(item.id).html((item.name == 'Odaberi') ? item.name : item.name + ' ' + item.power + ' kw'));
                });
                $('#findVehiclePleaseWait').hide();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.responseText);
            }
        });
    }
    else {
        $('#cmbEngine').empty();
    }
}

function GetEngine()
{
    var engineUrl = $('#cmbEngine').val();
    window.location = "/vozila/" + $('#cmbVehicleType').val() + "/" + $('#cmbManufacturer').val() + "/" + $('#cmbModel').val() + "/" + $('#cmbEngine').val();
}