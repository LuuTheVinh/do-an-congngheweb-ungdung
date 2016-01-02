$(function myfunction() {

    var folder = $('.fileinput-button .object-context').val();
    var subfolder = $('.fileinput-button .upload-context').val();

    // Upload, get or delete files with the built-in Server side file handler. 
    if (folder == undefined || subfolder == undefined) {
        if (folder != undefined)
            handlerUrl = "/Backload/FileHandler?objectContext=" + folder;
        else if (subfolder != undefined)
            handlerUrl = "/Backload/FileHandler?objectContext=" + subfolder;
        else
            handlerUrl = "/Backload/FileHandler";
    }
    else {
        handlerUrl = "/Backload/FileHandler?" + "objectContext=" + folder + "&uploadContext=" + subfolder;
    }

    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload({
        url: handlerUrl,
        dataType: 'json',
        done: function (e, data) {
            var file = data.result.files[0];
            $('.status-text').text(file.extra.originalName);
            $('.fileinput-button').addClass('success-button');
            $('#URL').attr("value", file.url);
        },
        progress: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('.progress .progress-bar').css(
                'width',
                progress + '%'
            );
        }
    });
});