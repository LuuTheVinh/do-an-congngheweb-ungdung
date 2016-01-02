$(function () {
    'use strict';

    var type = $("#file-type").val();

    if (type == undefined) {
        type = "musics";
    }
    else if (type == "videos") {
    }

    // We use the upload handler integrated into Backload:
    // In this example we set an objectContect (id) in the url query (or as form parameter).
    // You can use a user id as objectContext give users only access to their own uploads.
    var url = '/Backload/FileHandler?objectContext=files&uploadContext=' + type;

    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload({
        url: url
    });

    // Load existing files:
    $.ajax({
        url: url,
        dataType: 'json',
        context: $('#fileupload')[0]
    }).done(function (result) {
        $(this).fileupload('option', 'done')
            .call(this, $.Event('done'), { result: result });
    });
});