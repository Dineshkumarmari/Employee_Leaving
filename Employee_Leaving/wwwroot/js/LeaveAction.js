
function acceptcall(empId,Cid) {
    let result = confirm("Are you sure you want to Accepted?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/Home/Accept?id=' + empId +'&Cid='+Cid,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response.success == true) {
                    location.reload();
                }
                else {
                    alert(response.message);
                }
            },
            error: function () {
                alert("error");
            }
        });
    }
}

function rejectedcall(empId, Cid) {
    let result = confirm("Are you sure you want to Rejected?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/Home/Reject?id=' + empId + '&Cid=' + Cid,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response.success == true) {
                    location.reload();
                }
                else {
                    alert(response.message);
                }
            },
            error: function () {
                alert("error");
            }
        });
    }
}
       