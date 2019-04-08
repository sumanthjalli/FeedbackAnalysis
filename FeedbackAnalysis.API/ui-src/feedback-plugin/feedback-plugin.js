$(document).ready(DOMLoaded);

function DOMLoaded() {
    $.ajax({
        url: "http://feedback.rp.com/feedback-plugin.html?v=" + Date.now(),
        type: "get",
        crossDomain: true,
        dataType: "html",
        success: function(response) {
            $('body').append('<div id="feedback-section"></div>');
            $('#feedback-section').html(response);
            $(document).on('click', "#feedback-plugin", redirectToFeedback);
        },
        error: function(xhr, status) {
            alert("error");
        }
    });
}

function redirectToFeedback() {
    let params = (new URL(document.location)).searchParams;
            let name = params.get("product");
            let productid = params.get("id");
    window.open('http://feedbackForm.rp.com/?product='+ name + '&id=' + productid, '_blank');
}