//using Employee_Leaving.Controllers;
//using Employee_Leaving.Models;
//using Employee_Leaving.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AdminTest
//{
//    public  class ActionResult
//    {
//        [Fact]
//        public void Accept_okResult()
//        {
//            Leave obj = (new Leave
//            {
//                LeaveType_Id = 1,
//                Emp_Id = 1,
//                StartingDate = DateTime.Now,
//                EndingDate = DateTime.Now,
//                TotalNoDays = 5,
//            });
//            List<Leave> Lisobj = new List<Leave>();
//            var mockservice = new Mock<ILeaving>();
//            mockservice.Setup(x => x.Getbyid(It.IsAny<int>())).Returns(obj);
//            mockservice.Setup(x => x.AcceptLeave(It.IsAny<int>())).Returns(obj);
//            var controller = new LeavingController(mockservice.Object);

//            var okresult = controller.AcceptLeave(3);

//            Assert.IsType<OkObjectResult>(okresult);
//        }

//        [Fact]
//        public void Accept_NotFoundResult()
//        {
//            Leave obj = (new Leave
//            {
//                Leave_Id = 1,
//                Emp_Id = 1,
//                LeaveType_Id = 1,
//                StartingDate = DateTime.Now,
//                EndingDate = DateTime.Now,
//                TotalNoDays = 5,
//            });
//            List<Leave> Listobj = new List<Leave>();
//            Listobj.Add(obj);
//            var mockService = new Mock<ILeaving>();
//            mockService.Setup(x => x.AcceptLeave(It.IsAny<int>())).Returns(obj);
//            var controller = new LeavingController(mockService.Object);

//            var exception = Assert.Throws<Exception>(() => controller.AcceptLeave(1));

//            Assert.Equal("This Emp_Id can not registered", exception.Message);

//        }

//        [Fact]
//        public void Reject_okResult()
//        {
//            Leave obj = (new Leave
//            {
//                LeaveType_Id = 1,
//                Emp_Id = 1,
//                StartingDate = DateTime.Now,
//                EndingDate = DateTime.Now,
//                TotalNoDays = 5,
//            });
//            List<Leave> Lisobj = new List<Leave>();
//            var mockservice = new Mock<ILeaving>();
//            mockservice.Setup(x => x.Getbyid(It.IsAny<int>())).Returns(obj);
//            mockservice.Setup(x => x.RejectLeave(It.IsAny<int>())).Returns(obj);
//            var controller = new LeavingController(mockservice.Object);

//            var okresult = controller.RejectLeave(3);

//            Assert.IsType<OkObjectResult>(okresult);
//        }


//        [Fact]
//        public void Reject_NotFoundResult()
//        {
//            Leave obj = (new Leave
//            {
//                Leave_Id = 1,
//                Emp_Id = 1,
//                LeaveType_Id = 1,
//                StartingDate = DateTime.Now,
//                EndingDate = DateTime.Now,
//                TotalNoDays = 5,
//            });
//            List<Leave> Listobj = new List<Leave>();
//            Listobj.Add(obj);
//            var mockService = new Mock<ILeaving>();
//            mockService.Setup(x => x.RejectLeave(It.IsAny<int>())).Returns(obj);
//            var controller = new LeavingController(mockService.Object);

//            var exception = Assert.Throws<Exception>(() => controller.RejectLeave(1));

//            Assert.Equal("This Emp_Id can not registered", exception.Message);

//        }
//    }
//}
