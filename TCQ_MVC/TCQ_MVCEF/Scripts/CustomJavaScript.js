$(function () {
    $("#btn_Submit").mouseover(function () {
        $("#btn_Submit").css("backgroundColor", "red");
    });
    $("#btn_Submit").mouseout(function () {
        $("#btn_Submit").css("backgroundColor", "grey");
    });
});

$(function () {
    $("#btnSubmit").click(function () {
        var Number = $("#txtNumber").val();

        var result = Number % 2;

        if (result == 0)
            alert("Number is even");
        else
            alert("Number is odd");
    });
});