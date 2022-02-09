$(document).ready(function () {
    
    let loader = $(".loader");
   

    if (userName != null) {
        $.ajax({
            url: "/Home/GetOrder",
            type: "POST",
            data: { userName: userName },
            success: function (data) {

                $(".orderCount").attr("data-notify", data.length);
                let countFin = data.length < 3 ? data.length : 3;
                if (data.length > 0) {
                    GetUserCard(data, countFin, "More Items");
                }
                console.log(data[0]);
            }
            
        })
    }
    
    $(document).on({
        ajaxStart: function () {
            loader.removeClass("d-none");
        },

        ajaxStop: function () {
            loader.addClass("d-none");
        }
    })
})


function GetUserCard(orderedProduct,count,itemText) {
    
    
    let totalPriceForProduct = 0;
    for (var i = 0; i < orderedProduct.length; i++) {
        totalPriceForProduct += orderedProduct[i].Count * orderedProduct[i].ProductPrice;
    }
    let headerCard = $("#head");

    let ul = $("<ul class='header-cart-wrapitem w-full'></ul>");
    for (var i = 0; i < count; i++) {
        
        let li = $("<li class='header-cart-item flex-w flex-t m-b-12'></li>");
        let divImg = $("<div class='header-cart-item-img'></div>");
        
        let img = $("<img src='/images/"+ orderedProduct[i].ProductName+".jpg'>");
        divImg.append(img);
        
        let divItem = $("<div class='header-cart-item-txt p-t-8'></div>");

        let itemText = $("<a href='#' class='header-cart-item-name m-b-18 hov-cl1 trans-04'>" + orderedProduct[i].ProductName + "</a>");
        let itemPrice = $("<span class='header-cart-item-info'>"+orderedProduct[i].Count+" x "+ orderedProduct[i].ProductPrice + "</span>");
        divItem.append(itemText);
        divItem.append(itemPrice);

        li.append(divImg);
        li.append(divItem);

        ul.append(li);
    }

    let total = $("<div class='w-full'></div>");

    let totalPrice = $("<div class='header-cart-total w-full p-tb-40'>Total: AMD " + totalPriceForProduct + "</div>");

    let totalButton = $("<div class='header-cart-buttons flex-w w-full'></div>");
    let totalButtonHref = $("<a href='shoping-cart.html' class='flex-c-m stext-101 cl0 size-107 bg3 bor2 hov-btn3 p-lr-15 trans-04 m-b-10'>Check Out</a>");
    let totalButtonMore = $("<a href='#' id='loadMoreItems' class='flex-c-m stext-101 cl0 size-107 bg3 bor2 hov-btn3 p-lr-15 trans-04 m-b-10'>"+itemText+"</a>");
    totalButton.append(totalButtonHref);
    totalButton.append(totalButtonMore);

    total.append(totalPrice);
    total.append(totalButton);

    headerCard.append(ul);
    headerCard.append(total);

    
    $(totalButtonMore).click(function () {

        let y = $(this).text();
        let countFin = orderedProduct.length < 3 ? orderedProduct.length : 3;
        
        if (y == "More Items")
        {
            headerCard.empty();
            GetUserCard(orderedProduct, orderedProduct.length, "Less Items");
           
        }
        else {
            headerCard.empty();
            GetUserCard(orderedProduct, countFin, "More Items");
           
        }
        
    })
}