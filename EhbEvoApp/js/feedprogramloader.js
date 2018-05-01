$(document).ready(function () {
    var selectedDeptID = $('#Department option:selected').val();
    var selectedProgramID = $('#Program').attr('previousId');
    $.get('/Feed/ProgramPartial/' + selectedDeptID + "?programId=" + selectedProgramID, function (data) {
        $('#Program').html(data);
    });
    $('#Department').on('change', function () {
        var selectedDeptID = $('#Department option:selected').val();
        var selectedProgramID = $('#Program').attr('previousId');
        $.get('/Feed/ProgramPartial/' + selectedDeptID + "?programId=" + selectedProgramID, function (data) {
            $('#Program').html(data);
        });
    });
});
