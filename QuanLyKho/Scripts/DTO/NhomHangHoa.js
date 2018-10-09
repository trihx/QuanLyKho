
function loadTable() {
    //load Nhom hang hoa
    var table = $("#listNhom").DataTable({
        "language": language,
        destroy: true,
        ajax: {
            url: "/api/nhomhanghoa",
            dataSrc: '',
            type: 'GET'
        },
        columns: [
            {
                data: "MaNhomHangHoa"
            },
            {
                data: "TenNhomHangHoa"
            },
            {
                data: "_isLocked"
            },
            {
                data: "Id",
                render: function (data) {

                    return "<button type='button' data-nhom-id=" + data + " data-toggle='modal' data-target='#createModal' class='btn btn-success glyphicon glyphicon-edit js-edit'></button>"
                        +"   " +" <button type='button' data-nhom-id=" + data + " class='btn btn-danger glyphicon glyphicon-lock js-lock'></button>"
                }
            }
        ]

    });

}

function lockGroup(id) {
    $.ajax({
        url: "/api/nhomhanghoa/" + id + "/2",
        method: "PUT",
        data: {
            _isLocked: true
        },
        success: function () {
            alert("Khóa thành công!");
            loadTable();
        }
            
    });
}

function SaveData() {

    if ($("#Id").val() == 0) {
        $.ajax({
            url: "/api/nhomhanghoa",
            method: "POST",
            data: {
                _isLocked: false,
                MaNhomHangHoa: $("#MaNhomHangHoa").val(),
                TenNhomHangHoa: $("#TenNhomHangHoa").val(),
            },

            success: function () {
                $("#createModal").modal("toggle");
                loadTable();
                
            },

            error: function (jqXHR) {
                $("#divErrorText").text(jqXHR.responseText);

                $("#divError").show('fade');
            }
        });
    }
    else {
       
        $.ajax({
            url: "/api/nhomhanghoa/" + $("#Id").val() +"/1",
            method: "PUT",
            data: {
                MaNhomHangHoa: $("#MaNhomHangHoa").val(),
                TenNhomHangHoa: $("#TenNhomHangHoa").val()
            },
            success: function () {
                $("#createModal").modal("toggle");
                loadTable();
                
               
            }
        });
        
    }
    
}

function loadNhomId(id) {
    $.ajax({
        url: "/api/nhomhanghoa/" + id,
        dataSrc: "",
        type: "GET",
        dataType: "json",
        
        success: function (response) {

            if (response != null) {

                $("#MaNhomHangHoa").val(response.MaNhomHangHoa);
                $("#TenNhomHangHoa").val(response.TenNhomHangHoa);
                $("#Id").val(response.Id);
            }
        }
    });
}