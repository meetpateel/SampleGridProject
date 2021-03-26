
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

[].forEach.call(document.getElementsByClassName('mvc-grid'), function (element) {
    new MvcGrid(element);
});

$(document).ready(function () {
    $('#Edit-Product-DialogBox').dialog({
        autoOpen: false,
        height: 450,
        width: 425,
        resizable: true,
        model: true
    });
    function openEditDetailsDialog() {
        $('#Edit-Product-DialogBox').dialog('open');
    }
    $("#container").on("click", "#EditBox", function () {
        $('#monitorId').val($(this).closest("tr").children("td:eq(1)").text());
        $('#monitorName').val($(this).closest("tr").children("td:eq(2)").text());
        $('#monitorDescription').val($(this).closest("tr").children("td:eq(3)").text());
        $('#monitorPrice').val($(this).closest("tr").children("td:eq(4)").text());
        $('#monitorQuantity').val($(this).closest("tr").children("td:eq(5)").text());


        openEditDetailsDialog();
    });
    $("#AddApplication").click(function () {
        $('#MonitorDetailForm').trigger('reset');
        $('#Edit-Product-DialogBox').dialog('open');
    })
});
