$(function myfunction() {

    var w = $('.thumb-upload').attr('width');
    var h = $('.thumb-upload').attr('height');

    var folder = $('.imageinput-button .object-context').val();
    var subfolder = $('.imageinput-button .upload-context').val();

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
    $('#imageupload').fileupload({
        url: handlerUrl,
        dataType: 'json',
        disableImageResize: false,
        imageMaxWidth: w,
        imageMaxHeight: h,
        imageCrop: true,
        done: function (e, data) {
            var file = data.result.files[0];
            $('.thumb-upload').attr("src", file.url);
            $('#Thumbnail').attr("value", file.url);
        }
    });
});