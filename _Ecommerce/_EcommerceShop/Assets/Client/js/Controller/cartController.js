var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnCheckout').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/CheckLogin',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Checkout/Payment";
                    }
                    else {
                        alert("Vui lòng đăng nhập để tiến hành thanh toán!");
                        window.location.href = "/Login/Login";
                    }
                }
            })
        });
        $('#btnDeleteCart').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        location.reload();
                    }
                }
            })
        });

        $('#btnUpdateCart').off('click').on('click', function () {
            var listProduct = $('#quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        location.reload();
                    }
                }
            })
        });
        $('.btnaddtocart').on('click', function () {
            $.ajax({
                url: '/Cart/AddItem',
                data: { productId: $(this).data('id'), quantity: 1 },
                type: 'POST',
                dataType: 'json',
                success: function (res) {
                    if (res.status == true) {
                    }
                }
            })
        })
        $('.close1').off('click').on('click', function () {
            $.ajax({
                data: { id:$(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        location.reload();
                    }
                }
            })
        });

        $('.input-qty').each(function () {
            var $this = $(this),
                qty = $this.parent().find('.is-form'),
                min = Number($this.attr('min')),
                max = Number($this.attr('max'))
            if (min == 0) {
                var d = 0
            }
            else d = min
            $(qty).on('click', function () {
                if ($(this).hasClass('btnMinus')) {
                    if (d > min) d += -1
                    else if (d <= min + 1) {
                        $.ajax({
                            data: { id: $(this).data('id') },
                            url: '/Cart/Delete',
                            dataType: 'json',
                            type: 'POST',
                            success: function (res) {
                                if (res.status == true) {
                                    location.reload();
                                }
                            }
                        })
                    }
                }
                else if ($(this).hasClass('btnPlus')) {
                    var x = Number($this.val()) + 1
                    if (x <= max) {
                        d += 1;
                        //$.ajax({
                        //    data: { id: $(this).data('id'), quantity: d+1 },
                        //    url: '/Cart/Plus',
                        //    dataType: 'json',
                        //    type: 'POST',
                        //    success: function (res) {
                        //        if (res.status == true) {
                        //            location.reload();
                        //        }
                        //    }
                        //}) 
                    }
                }
                $this.attr('value', d).val(d)
            })
        });
    }
}
cart.init();