using Castle.Core.Resource;
using Employee_Leaving.Controllers;
using Employee_Leaving.Models;
using Employee_Leaving.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTest
{
    public class EmployeeTest
    {
        [Fact]
        public void GetbyId_okResult()
        {
            Leave obj = (new Leave
            {
                LeaveType_Id = 1,
                Emp_Id = 1,
                StartingDate = DateTime.Now,
                EndingDate = DateTime.Now,
                TotalNoDays = 5,
            });
            List<Leave> Lisobj = new List<Leave>();
            var mockservice = new Mock<ILeaving>();
            mockservice.Setup(x => x.Getbyid(It.IsAny<int>())).Returns(obj);
            var controller = new LeavingController(mockservice.Object);

            var okresult = controller.Get(3);

            Assert.IsType<OkObjectResult>(okresult);
        }


        [Fact]
        public void AddLeave_okResult()
        {
            Message msg = new Message();
            Leave obj = (new Leave
            {
                Leave_Id = 1,
                Emp_Id = 1,
                LeaveType_Id = 1,
                StartingDate = DateTime.Now,
                EndingDate = DateTime.Now,
                TotalNoDays = 5,
            });

            List<Leave> Listobj = new List<Leave>();
            Listobj.Add(obj);
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.AddLeave(It.IsAny<Leave>())).Returns(msg);
            var controller = new LeavingController(mockService.Object);

            var exception = controller.Add(obj);

            Assert.NotNull(exception);
        }


        [Fact]
        public void GetAll_OkResult()
        {
            Leave obj = (new Leave
            {
                LeaveType_Id = 1,
                Emp_Id = 1,
                StartingDate = DateTime.Now,
                EndingDate = DateTime.Now,
                TotalNoDays = 5,

            });
            List<Leave> Lisobj = new List<Leave>();
            Lisobj.Add(obj);
            var mockservice = new Mock<ILeaving>();
            mockservice.Setup(x => x.GetAll()).Returns(Lisobj);
            var controller = new LeavingController(mockservice.Object);

            var okresult = controller.Getall();

            Assert.IsType<OkObjectResult>(okresult);
        }

        [Fact]
        public void Getall_ReturnNotFound()
        {
            Leave obj = (new Leave
            {
                LeaveType_Id = 1,
                Emp_Id = 1,
                StartingDate = DateTime.Now,
                EndingDate = DateTime.Now,
                TotalNoDays = 5,

            });
            List<Leave> Lisobj = new List<Leave>();
            var mockservice = new Mock<ILeaving>();
            mockservice.Setup(x => x.GetAll()).Returns(Lisobj);
            var controller = new LeavingController(mockservice.Object);

            var notfoundResult = controller.Getall();

            Assert.IsType<NotFoundResult>(notfoundResult);

        }
    }
}

