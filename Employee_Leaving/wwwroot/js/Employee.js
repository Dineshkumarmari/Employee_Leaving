
$(document).ready(function () {
    $('#Employeeform').submit(function (e) {
        e.preventDefault();
        var valdata = $("#Employeeform").serialize(); $.ajax({
            url: "/Home/AddEmployees",
            type: "POST",
            dataType: 'json',
            data: new FormData(Employeeform),
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: valdata,
            success: function (response) {
                if (response.success == true)
                {
                   window.location.href = "/Home/EmployeeDetails"
                }
                else {
                    alert(response.message);
                    location.reload();
                }
            }, error: function () {
                alert("error");
            }

        });

    });
});



function deleteEmployee(Emp_Id) {
    let result = confirm("Are you sure you want to delete?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/Home/DeleteEmployee?Emp_Id=' + Emp_Id,
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
