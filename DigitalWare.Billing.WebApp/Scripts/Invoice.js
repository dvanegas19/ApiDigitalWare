/// <reference path="jquery-3.3.1.intellisense.js" />

var listInvoiceDetail = [];
var listProduct = [];
var total = 0;


$(document).ready(function () {
    LoadList();

    $("#Product").change(function () {
        $("#ProductId").val($("#Product").val());
        $.each(listProduct, function (key, item) {
            if (item.IdProduct.toString() == $('#Product').val()) {             
                $("#valor").val(item.Price.toString())
            }
        });
       
    });
});


function loadData(data) {
            var html = '';
    $.each(data, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ProductId + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td>' + item.Unit + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
}

function LoadList() {
    $.ajax({
        url: "/Invoice/ListClient",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result.Data, function () {
                $("#Client").append($("<option>").val(this.IdClient).text(this.Names + " " + this.LastName));
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    $.ajax({
        url: "/Invoice/ListProduct",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result.Data, function () {
                $("#Product").append($("<option>").val(this.IdProduct).text(this.Description));
            });
            listProduct = result.Data;
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// EVENTOS
function btnSaveInvoice() {
    var objInvoice = {
        Client: { IdClient: $("#Client").val() },
        Unit: $('#Unidades').val(),
        Total: $('#Total').val(),
        Iva: $('#Iva').val()
    };
    saveInvoice(objInvoice);
}

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }


    $.each(listProduct, function (key, item) {
        if (item.IdProduct.toString() == $('#Product').val()) {
            total += (item.Price * $('#Unidades').val()) ; 
        }
    });
    $("#Total").val(total);
    var proObj = {
        ProductId: $('#Product').val(),
        Description: $('#Product option:selected').text(),
        Product: { IdProduct: $('#Product').val() },
        Unit: $('#Unidades').val()
    };
    listInvoiceDetail.push(proObj);
    loadData(listInvoiceDetail);
    $('#ProductId').val('');
    $('#Product').val('');
    $('#Unidades').val('');
    $('#valor').val('');
    
    
}

function saveInvoice(objInvoice) {

    if (!validateFactura())
        return false;

    $.ajax({
        url: "/Invoice/SaveInvoice" ,
        type: 'POST',
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: JSON.stringify({ invoice: objInvoice }),
        success: function (result) {
            var list = [];
            $.each(listInvoiceDetail, function (key, item) {
                var proObj = {
                    Product: { IdProduct: item.ProductId },
                    Unit: item.Unit,
                    IdInvoice: result.Data,
                    IVA: $("#Iva").val()
                };
                list.push(proObj);               
            });
            saveInvoiceDetail(list);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function saveInvoiceDetail(objListDetail) {

    $.ajax({
        url: "/Invoice/SaveInvoiceDetail",
        type: 'POST',
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: JSON.stringify({ invoiceDetail: objListDetail}),
        success: function (result) {
            if (result.StatusCode == 200) {

                alert("Factura generada con exito por valor de $" + calcularIva().toString()+ " Iva incluido");
                clearTextBox();
                $('.tbody').html('');
                $('#Client').val('');
            } else {
                alert("Problemas al guardar la factura");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function clearTextBox() {
    $('#Total').val("");
    $('#Unidades').val("");
    $('#Product').val();
    $('#Unidades').val('');
    listInvoiceDetail = [];
    total = 0;
}

function validate() {
    var isValid = true;
    if ($('#Product').val().trim() == "") {
        $('#Product').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Product').css('border-color', 'lightgrey');
    }
    if ($('#Unidades').val().trim() == "") {
        $('#Unidades').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Unidades').css('border-color', 'lightgrey');
    }
    
    return isValid;
}

function validateFactura() {
    var isValid = true;
    if ($('#Client').val() == "Seleccione un Cliente" || $('#Client').val() == "" || $("#Client").val() == null) {
        $('#Client').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Client').css('border-color', 'lightgrey');
    }
    if ($('#Total').val().trim() == "") {
        $('#Total').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Total').css('border-color', 'lightgrey');
    }

    return isValid;
}

function calcularIva() {
    var totalIva = (total * parseFloat($('#Iva').val())) / 100;
    return totalIva + total;
}