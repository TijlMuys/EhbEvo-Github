$(document).ready(function () {
    $('#departmentsdropdown').on('change', function () {
        var selectedID = $('#departmentsdropdown option:selected').val();
        $.get('/Account/RegisterPartial/' + selectedID, function (data) {
            console.log(data);
            $('#partialprogramselect').html(data);
        });
    });
});
