$(document).ready(function () {
    // Book tour
    function parseJsonDate(jsonDateString) {
        return moment(jsonDateString).format("DD-MM-YYYY").toUpperCase();
    }

    function checkDate() {
        var startDate = new Date($('#startDate').val());
        var endDate = new Date($('#endDate').val());
        var pricePerDay = $('#pricePerDay').text();
        if (startDate < endDate) {
            var range = (endDate - startDate) / (24 * 60 * 60 * 1000);
            $('#bookDays').text(range);
            $('#totalAmount').text(range + 'x ' + pricePerDay);
            $('#totalCost').text($('#bookDays').text() * pricePerDay);
            var errorMessage = document.getElementById('error_message');
            errorMessage.style.display = "none";
        } else {
            var errorMessage = document.getElementById('error_message');
            errorMessage.style.display = "";
            $('#totalAmount').text('1x ' + pricePerDay)
            $('#totalCost').text(pricePerDay)
        }
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
            url: "/OrderTour/CreateTourOrder?tourDetailId=" + idTourDetail + "&unitPrice=" + unitPrice + "&quantity=" + quantity,
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                if (response.status == 1) {
                    Swal.fire({
                        icon: 'success',
                        title: response.message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    window.location.href = "/User/ShowInformation?id=" + $('#userId').val();
                }

                else {
                    Swal.fire({
                        icon: 'error',
                        title: response.message,
                        showConfirmButton: false,
                        timer: 4000
                    })
                    window.location.href = "/User/Login";
                }
            }
        });
    });

    // Book Car
    $('#endDate').on('change', function (e) {
        checkDate();
    });
    $('#startDate').on('change', function (e) {
        checkDate();
    });

    $('#book_car').on('click', function (e) {
        e.preventDefault();
        var startDateString = $('#startDate').val();
        var endDateString = $('#endDate').val();
        var pricePerDay = $('#pricePerDay').text();
        var startDate = new Date($('#startDate').val());
        var endDate = new Date($('#endDate').val());
        if (startDate >= endDate) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please select the date again !',
            })
        } else {
            var carId = $('#carId').val();
            $.ajax({
                url: "/OrderCar/CreateCarOrder?carId=" + carId + "&startDay=" + startDateString + "&endDay=" + endDateString + "&pricePerDay=" + pricePerDay,
                type: "POST",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    if (response.status == 1) {
                        Swal.fire({
                            icon: 'success',
                            title: response.message,
                            showConfirmButton: false,
                            timer: 1500
                        })
                        window.location.href = "/User/ShowInformation?id=" + $('#userId').val();
                    }

                    else if (response.status == -1) {
                        Swal.fire({
                            icon: 'error',
                            title: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        })
                        window.location.href = "/User/Login";
                    }
                    else if (response.status == 0) {
                        Swal.fire({
                            icon: 'warning',
                            title: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        })
                    }
                }
            });
        }
    });

    $('.cancelButton').on('click', function (e) {
        Swal.fire({
            title: 'Are you sure want to cancel this service?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, cancel it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var orderId = $(this).data("id");
                $.ajax({
                    url: "/OrderTour/CancelPayment?id=" + orderId,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    success: function (response) {
                        if (response.status == 1) {
                            Swal.fire({
                                icon: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            })
                            window.location.href = "/User/ShowInformation?id=" + $('#userId').val();
                        }
                    }
                });
            }
        })
    })

    $('.refundButton').on('click', function (e) {
        e.preventDefault;
        Swal.fire({
            title: 'Are you sure want to refund this service?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, refund it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var orderId = $(this).data("id");
                $.ajax({
                    url: "/OrderTour/RefundPayment?id=" + orderId,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    success: function (response) {
                        if (response.status == 1) {
                            Swal.fire({
                                icon: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            })
                            window.location.href = "/User/ShowInformation?id=" + $('#userId').val();
                        }
                    }
                });
            }
        })
    })
});