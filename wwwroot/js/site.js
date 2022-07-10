// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#dataTable').DataTable();
});


showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#CreateNewProjectModal .modal-body').html(res);
            $('#CreateNewProjectModal .modal-title').html(title);
            $('#CreateNewProjectModal').modal('show');
        }
    })

}


showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#DeleteNewProjectModal .modal-body').html(res);
            $('#DeleteNewProjectModal .modal-title').html(title);
            $('#DeleteNewProjectModal').modal('show');
        }
    })

}