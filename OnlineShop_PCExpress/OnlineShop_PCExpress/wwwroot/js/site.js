// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AjaxPozivi() {
    $("a[ajax-poziv='da']").click(function (e) {
        e.preventDefault();

        var url = $(this).attr("href");
        var rez = $(this).attr("ajax-rezultat");

        $.get(url, function (data, status) {
            $("#" + rez).html(data);
        })

        
    });

    $("form[ajax-poziv='da'").submit(function (e) {
        e.preventDefault();

        var url = $(this).attr("action");
        var rez = $(this).attr("ajax-rezultat");
        var form = $(this);

        $.ajax({
            type: "POST",
            url: url,
            data: form.serialize(),
            success: function (data) {
                $("#" + rez).html(data);
            }
        })
    });
}

$(document).ready(function () {
    AjaxPozivi();
})

$(document).ajaxComplete(function () {
    AjaxPozivi();
})