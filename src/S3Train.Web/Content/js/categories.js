
$(function () {
    $('.menu').click(function () {
        $('#css-menu').css({
           left:'0'
        });
    });
    $('.close-menu').click(function () {
        $('#css-menu').css({
            left: '-340px'
        });
    });
});