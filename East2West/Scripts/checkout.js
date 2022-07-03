$(document).ready(function () {
    function parseJsonDate(jsonDateString) {
        return moment(jsonDateString).format("DD-MM-YYYY").toUpperCase();
    }

    $('#selected_id').on('change', function (e) {
        var idTourDetail = String($('#selected_id option:selected').val());
        var idTour = $(this).attr("data-id");
        $.ajax({
            url: "/ClientTour/GetDetails?id=" + idTour + "&tourDetailId=" + idTourDetail,
            type: "GET",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                $('#detailPrice').val("Price: " + response.price + "$");
                $('#detailPriceHidden').val(response.price);
                $('#detailSeat').val("Available seat: " + response.seat);
                $('#selected_tour').html(idTourDetail);
                $('#startDay').val("Departure Day: " + parseJsonDate(response.startDay));
                $('#maxSeat').val(response.seat);
                var target = $("#person").data("target");
                $("#person").val(1);
                $(target).html($("#person").val());
                $('#total_amount').html($("#person").val() + "x $" + $('#detailPriceHidden').val());
                $('#total_cost').html(parseFloat($('#detailPriceHidden').val()) * parseFloat($("#person").val()));
            }
        });
    });
    $("#person").on('change', function (e) {
        var target = $(this).data("target");
        $(target).html($(this).val());
        $('#total_amount').html($("#person").val() + "x $" + $('#detailPriceHidden').val());
        $('#total_cost').html(parseFloat($('#detailPriceHidden').val()) * parseFloat($("#person").val()));
    });

    $('#submit_button').on('click', function (e) {
        e.preventDefault();
        var idTourDetail = String($('#selected_id option:selected').val())
        var unitPrice = $('#detailPriceHidden').val();
        var quantity = $("#person").val();
        $.ajax({
            url: "/Order/CreateTourOrder?tourDetailId=" + idTourDetail + "&unitPrice=" + unitPrice + "&quantity=" + quantity,
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                if (response.status == 1) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Order success',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    window.location.href = "/User/ShowInformation?id=" + $('#userId').val();
                }

                else {
                    window.location.href = "/User/Login";
                }
            }
        });
    });
});