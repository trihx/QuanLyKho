var manhom = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('MaNhomHangHoa'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
  
    remote: {
        url: '/api/nhomhanghoa?query=%QUERY',
        wildcard: '%QUERY'
    }
});

var tennhom = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('TenNhomHangHoa'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,

    remote: {
        url: '/api/nhomhanghoa?query=%QUERY',
        wildcard: '%QUERY'
    }
});


function loadTable() {
    //load  hang hoa
    var table = $("#listNhom").DataTable({
        "language": language,
        destroy: true,
        ajax:
        {
            url: "/api/hanghoa",
            dataSrc: '',
            type: 'GET'
        },
        columns: [
            {
                name: "TenNhom",
                data: "NhomHangHoa.TenNhomHangHoa"
            },

            {
                data: "MaHangHoa"
            },
            {
                data: "TenHangHoa"
            },
            {
                data: "Id",
                render: function (data) {

                    return "<button type='button' data-hang-id=" + data + " data-toggle='modal' data-target='#createModal' class='btn btn-success glyphicon glyphicon-edit js-edit'></button>"
                        + "   " + " <button type='button' data-hang-id=" + data + " class='btn btn-danger glyphicon glyphicon-lock js-lock'></button>"
                }
            }
        ],
        rowsGroup: [
            "TenNhom:name", 0, 2
        ]

    });
}


    function loadNhomId(id,vm) {
        $.ajax({
            url: "/api/hanghoa/" + id,
            dataSrc: "",
            type: "GET",
            dataType: "json",

            success: function (response) {

                if (response != null) {

                    vm = response.NhomHangHoa.Id;
                    $("#NhomHangHoa_Id").val(response.NhomHangHoa.Id);
                    $("#MaNhomHangHoa").val(response.NhomHangHoa.MaNhomHangHoa);
                    $("#TenNhomHangHoa").val(response.NhomHangHoa.TenNhomHangHoa);
                    $("#MaHangHoa").val(response.MaHangHoa);
                    $("#TenHangHoa").val(response.TenHangHoa);
                    $("#Id").val(response.Id);
                    
                }
            }
        });
}


function SaveData(vm) {
    
    var dt = new Date().toISOString().substring(0, 10);
    if ($("#Id").val() == 0) {
        $.ajax({
            url: "/api/hanghoa",
            method: "POST",
            data: {

                _isLocked: false,
                MaHangHoa: $("#MaHangHoa").val(),
                TenHangHoa: $("#TenHangHoa").val(),
                NgayTao: dt.toString(),
                NhomHangHoaId: vm
            }
        })  
            .done(function () {
                $("#createModal").modal("toggle");
                loadTable();
            })
            .fail(function (jqXHR) {
                $("#divErrorText").text(jqXHR.responseText);
                $("#divError").show('fade');
        });
    }
    else {
        var nhomhang_id = $("#NhomHangHoa_Id").val();
        $.ajax({
            url: "/api/hanghoa/" + $("#Id").val() + "/1",
            method: "PUT",
            data: {
                MaHangHoa: $("#MaHangHoa").val(),
                TenHangHoa: $("#TenHangHoa").val(),
                NgayCapNhatCuoi: dt.toString(),
                NhomHangHoaId: nhomhang_id,
            }
        })
            .done(function () {
                $("#createModal").modal("toggle");
                loadTable();
            })
            .fail(function (jqXHR) {
                $("#divErrorText").text(jqXHR.responseText);
                $("#divError").show('fade');
            });
    }
    

}

   





