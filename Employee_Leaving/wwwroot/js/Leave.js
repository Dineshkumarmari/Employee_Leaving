
$(document).ready(function () {
    $('#Leaveform').submit(function (e) {
        e.preventDefault();
        debugger;
        var valdata = $("#Leaveform").serialize();
        $.ajax({
            url: "/Home/Leave",
            type: "POST",
            dataType: 'json',
            data: new FormData(Leaveform),
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: valdata,
            success: function (response) {
                if (response.success == true) {
                    location.reload();
                }
                else {
                    alert(response.message);
                    location.reload();
                }
            },
            error: function () {
                alert("error");
            }

        });
    });
});


function deleteLeave(Emp_Id) {
    let result = confirm("Are you sure you want to delete?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/Home/DeleteLeave?Emp_Id=' + Emp_Id,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                console.log(response);
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
};


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


function getdays() {
    if ($('#StartingDate').val() && $('#EndingDate').val()) {
        const diffInMs = new Date($('#EndingDate').val()) - new Date($('#StartingDate').val())
        const diffInDays = diffInMs / (1000 * 60 * 60 * 24);
        $('#TotalNoDays').val(diffInDays);
        $('#days').text(diffInDays);
    }
}

