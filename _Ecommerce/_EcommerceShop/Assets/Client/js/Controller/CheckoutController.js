

var checkout = {
    init: function () {
        checkout.regEvents();
    },
    regEvents: function () {
        $('#btnNewaddress').off('click').on('click', function () {
            $('#shipping').removeClass('hidden');
        });
        $('#btnCOD').off('click').on('click', function () {
            $.ajax({
                url: '/Checkout/ShipCOD',
                type: 'POST',
                dataType: 'json',
                success: function (res) {
                    if (res.status == true) {
                        alert("Bạn đã đặt hàng thành công!!"),
                        window.location.href = '/'
                    }
                }
            })
        });
        
    }
}
checkout.init();