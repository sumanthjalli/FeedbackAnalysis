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




    function renderQuestions(data) {

        data.forEach(function(item, index) {
            feedbackHtml += feedbackCmplTmpl({
                feedbackItem: {
                    qText: item.questionDescription,
                    questionId: item.questionId,
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
                productId: productId,
                questionId: $(val).data('qstnid'),
                response: {
                    val: $(val).find('input[type=radio]:checked').val(),
                    text: $(val).find('textarea').val()
                }
            }
            data.push(currentItem);
        });


        currentItem = {
            productId: productId,
            questionId: "others",
            response: {
                val: null,
                text: $('#txtOthers').val()
            }
        };

        data.push(currentItem);

        // $.ajax({
        //     type: "POST",
        //     url: url,
        //     data: data,
        //     contentType: "application/json;",
        //     success: successFun,
        // });

    });

    function successFun() {

    }
}