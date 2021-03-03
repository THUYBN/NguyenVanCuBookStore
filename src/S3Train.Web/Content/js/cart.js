//$(document).ready(function () {
//    cal();
   
//    });
//    $(".quantity").change(function () {
//        //cal();
//        $.ajax({
//            data: { Id: $(this).data("id"), NewQuan: $(this).val() },
//            url: "/Cart/UpdateQuantity",
//            type: "POST",
//            success: function (data) {
//                cal();
//            }
//        });
//    });

//    function cal() {
//        var among = 0;
//        var totalQty = 0;
//        var total = 0;
//        $(".cart-item-info").each(function () {
//            var price = $(".price");
//            var quantity = $(".quantity");

//            var priceVal = $(this).find(price).val();
//            var quantityVal = parseInt($(this).find(quantity).val());
//            total = priceVal * quantityVal;
//            totalQty = totalQty + quantityVal;

//            among += total;
//        });


//        $("#card-among").html(among);
//        $(".final").html(among + 5);
//        $("#sum-total").html(total);
//        $("#totalQty").html(totalQty);
//    };

//    $('.close1').on('click', function () {
//        var _this = $(this);
//        //console.log(val().total);
//        var r = confirm("Are you sure you want to leave this product?");
//        if (r == true) {

//            $.ajax({
//                data: { Id: $(this).data("prod-id") },
//                url: "/Cart/removeItem",
//                type: "POST",
//                success: function (data) {
//                    //delete product item in cart
//                    _this.parent().remove();
//                    cal();

//                    if (data.length == 0) {
//                        $("#cart-wrapper").css("display", "none")
//                        $("#cart-wrapper-empty").css("display", "block")
//                    }
//                    else {
//                        $("#cart-wrapper").css("display", "block")
//                        $("#cart-wrapper-empty").css("display", "none")
//                    }
//                }

//            });
//        }

//    });