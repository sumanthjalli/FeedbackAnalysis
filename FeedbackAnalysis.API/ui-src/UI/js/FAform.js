var curremtDomain = 'http://localhost:57194',
    productId;
$(document).ready(DOMLoaded);

function DOMLoaded() {
    let params = (new URL(document.location)).searchParams;
    let name = params.get("product");
    productId = params.get("id");
    $('#productName').text(name);

    var feedbackCmplTmpl = _.template($("#tmpl-feedback-form").html()),
        feedbackForm = $('#feedbackForm'),
        feedbackHtml = '';


    $.ajax({
        url: curremtDomain + "/api/Products/GetProductQuestions?productId=" + productId + "&v=" + Date.now(),
        type: "get",
        dataType: "json",
        success: function(response) {
            renderQuestions(response);
        },
        error: function(xhr, status) {
            alert("error");
        }
    });

    $('.fa-star').click(function(e) {
        var currentEle = $(e.currentTarget),
            rating = currentEle.data('star');

        $('.fa-star').removeClass('checkedStar');
        $('.fa-star').each(function(i, val) {
            if ($(val).data('star') <= rating) {
                $(val).addClass('checkedStar');
            }
        });
        $('#rating').val(rating);
    });




    function renderQuestions(data) {

        data.forEach(function(item, index) {
            feedbackHtml += feedbackCmplTmpl({
                feedbackItem: {
                    qText: item.questionDescription,
                    feedBackCategoryId: item.feedBackCategoryId,
                    productId: item.productId,
                    questionType: item.questionType
                }
            });
        });
        feedbackForm.html(feedbackHtml);

        $('.feedbackOption').click(function(e) {
            var eleTarget = e.currentTarget,
                eleName = e.currentTarget.name;
            if (eleTarget.value === "1") {
                $('#' + eleName).parent('div').addClass('hide').removeClass('show');
            } else if (eleTarget.value === "0") {
                $('#' + eleName).parent('div').addClass('show').removeClass('hide');
            }
        });
    }



    $('#feedbackPost').click(function() {
        var url = '',
            data = [],
            currentItem;

        formElel = $('div[name="formItem"]');
        formElel.each(function(i, val) {
            currentItem = {
                ProductId: productId,
                FeedBackCategoryId: $(val).data('qstnid'),
                FeedBackIndex: $(val).find('input[type=radio]:checked').val(),
                FeedBackDesc: $(val).find('textarea').val(),
                StarRating: parseInt($('#rating').val())
            }
            data.push(currentItem);
        });

        currentItem = {
            ProductId: productId,
            FeedBackCategoryId: 6,
            FeedBackIndex: 0,
            FeedBackDesc: $('#txtOthers').val(),
            StarRating: parseInt($('#rating').val())
        };

        data.push(currentItem);

        $.ajax({
            type: "POST",
            url: curremtDomain + "/api/Feedback/SaveFeedback?v=" + Date.now(),
            data: { '': data },
            success: successFun
        });

    });

    function successFun() {}



}