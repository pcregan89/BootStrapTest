//Star rating functions
$(function () {
    $('input.check').on('change', function () {
        alert('Rating: ' + $(this).val());
    });
    $('#programmatically-set').click(function () {
        $('#programmatically-rating').rating('rate', $('#programmatically-value').val());
    });
    $('#programmatically-get').click(function () {
        alert($('#programmatically-rating').rating('rate'));
    });
    $('.rating-tooltip').rating({
        extendSymbol: function (rate) {
            $(this).tooltip({
                container: 'body',
                placement: 'bottom',
                title: 'Rate ' + rate + ' stars'
            });
        }
    });
    $('.rating-tooltip-manual').rating({
        extendSymbol: function () {
            var title;
            $(this).tooltip({
                container: 'body',
                placement: 'bottom',
                trigger: 'manual',
                title: function () {
                    return title;
                }
            });
            $(this).on('rating.rateenter', function (e, rate) {
                title = rate;
                $(this).tooltip('show');
                $(this).css('cursor', 'pointer');
            })
            .on('rating.rateleave', function () {
                $(this).tooltip('hide');
            });
        }
    });
    $('.rating').each(function () {
        $('<span class="label label-default"></span>')
          .text($(this).val() || ' ')
          .insertAfter(this);
    });
    $('.rating').on('change', function () {
        $(this).next('.label').text($(this).val());
    });
});

//clear button functions
$('.fa-minus-circle').click(function () {
    $(this).parent().children().next('.rating-tooltip-manual').rating('rate', 0);
});
$('.fa-minus-circle').mouseenter(function () {
    $(this).css('color', 'maroon');
    $(this).css('cursor', 'pointer');
});
$('.fa-minus-circle').mouseleave(function () {
    $(this).css('color', 'red');
});

//Toggle help questions
$('.help-question').click(function () {

    //$("p:visible").hide("slow");

    $(this).next().toggle('slow');
    $('i', this).toggleClass('fa-chevron-right fa-chevron-down');

    return false;
});