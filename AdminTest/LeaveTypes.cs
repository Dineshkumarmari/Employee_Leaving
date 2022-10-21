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
//    public class LeaveTypes
//    {
//        [Fact]
//        public void GetById_okResult()
//        {
//            Leave_Type obj = (new Leave_Type
//            {
//                LeaveType_Id = 1,
//                LeaveType = "CL"
//            });
//            List<Leave_Type> Lisobj = new List<Leave_Type>();
//            Lisobj.Add(obj);
//            var mockservice = new Mock<ILeaving>();
//            mockservice.Setup(x => x.GetId(It.IsAny<int>())).Returns(obj);
//            var controller = new LeavingController(mockservice.Object);

//            var okresult = controller.GetId(3);

//            Assert.IsType<OkObjectResult>(okresult);
//        }


//        //[Fact]
//        //public void GetbyId_NotFound()
//        //{
//        //    Leave_Type obj = (new Leave_Type
//        //    {
//        //        LeaveType_Id = 1,
//        //        LeaveType = "CL"
//        //    });
//        //    List<Leave_Type> Lisobj = new List<Leave_Type>();
//        //    var mockService = new Mock<ILeaving>();
//        //    mockService.Setup(x => x.GetId(It.IsAny<int>())).Returns(obj);
//        //    var controller = new LeavingController(mockService.Object);
//        //    var exception = Assert.Throws<Exception>(() => controller.GetId(10));
//        //    Assert.Equal("This Id Can not use in LeaveType", exception.Message);
//        //}

//        [Fact]
//        public void AddLeave_okResult()
//        {
//            Leave_Type obj = (new Leave_Type
//            {
//                LeaveType_Id = 1,
//                LeaveType = "CL"
//            });
//            List<Leave_Type> Listobj = new List<Leave_Type>();
//            Listobj.Add(obj);
//            var mockService = new Mock<ILeaving>();
//            mockService.Setup(x => x.AddType(It.IsAny<Leave_Type>())).Returns(obj);
//            var controller = new LeavingController(mockService.Object);

//            var exception = controller.AddType(obj);

//            Assert.NotNull(exception);
//        }

//        [Fact]
//        public void GetAll_OkResult()
//        {
//            Leave_Type obj = (new Leave_Type
//            {
//                LeaveType_Id = 1,
//                LeaveType = "CL"
//            });
//            List<Leave_Type> Listobj = new List<Leave_Type>();
//            Listobj.Add(obj);
//            var mockservice = new Mock<ILeaving>();
//            mockservice.Setup(x => x.GetAllType()).Returns(Listobj);
//            var controller = new LeavingController(mockservice.Object);

//            var okresult = controller.Getalltypes();

//            Assert.IsType<OkObjectResult>(okresult);
//        }

        
//    }
//}

