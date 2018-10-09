var language = {
    "search": "Tìm kiếm",
    "sLengthMenu": "Hiển thị _MENU_ dòng",
    "paginate": {
        "previous": "Trang trước",
        "next": "Trang kế"
    }
}

function clear() {
    $("input[type=text]").each(function () {
        $(this).val("");
    });
}

function hideErrorDiv() {
    $("#linkClose").click(function () {
        $("#divError").hide("fade");
    });
}

