$(document).ready(function () {
    const dropArea = $('#drop-area');

    dropArea.on('drag dragstart dragend dragover dragenter dragleave drop', function (e) {
        e.preventDefault();
        e.stopPropagation();
    })
        .on('dragover dragenter', function () {
            dropArea.addClass('highlight');
        })
        .on('dragleave dragend drop', function () {
            dropArea.removeClass('highlight');
        })
        .on('drop', function (e) {

            let files = e.originalEvent.dataTransfer.files;

            var formdata = new FormData(); 

            for (i = 0; i < files.length; i++) {
                formdata.append(files[i].name, files[i]);
            }

            sendFiles(formdata);

        });
    function sendFiles(files) {
        console.log(files);
        $.ajax({
            type: 'POST',
            url: 'Home/Index',
            dataType:'multipart/form-data',
            contentType: false,
            processData: false,
            data: files
        }); 
    }
});