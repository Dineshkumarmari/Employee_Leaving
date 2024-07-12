using Employee_Leaving.Controllers;
using Employee_Leaving.Models;
using Employee_Leaving.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit.Sdk;

namespace AdminTest
{
    public class EmployeesTest
    {
        [Fact]
        public void Geteallmployee_okResult()
        {
            Employee obj = (new Employee
            {
                Emp_Id = 1,
                Name = "dinesh",
                Password = "Dinesh@0524",
                Email_Id = "dhineshkumarm1999@gmail.com",
                PhoneNum = "7010388796",
                Gender = "male",
                Age = 22,
                Location = "madurai"
            });
            List<Employee> Lisobj = new List<Employee>();
            Lisobj.Add(obj);
            var mockservice = new Mock<ILeaving>();
            mockservice.Setup(x => x.GetEmployee()).Returns(Lisobj);
            var controller = new LeavingController(mockservice.Object);

            var okresult = controller.Getemployees();

            Assert.IsType<OkObjectResult>(okresult);
        }

        [Fact]
        public void Getallemployee_ReturnNotFound()
        {
            Employee obj = (new Employee
            {
                Emp_Id = 1,
                Name = "dinesh",
                Password = "Dinesh@0524",
                Email_Id = "dhineshkumarm1999@gmail.com",
                PhoneNum = "7010388796",
                Gender = "male",
                Age = 22,
                Location = "madurai"
            });
            List<Employee> Listobj = new List<Employee>();
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.GetEmployee()).Returns(Listobj);
            var controller = new LeavingController(mockService.Object);

            var notfoundResult = controller.Getemployees();

            Assert.IsType<NotFoundResult>(notfoundResult);

        }

        [Fact]
        public void Getbyid_OkResult()
        {
            Employee obj = (new Employee
            {
                Emp_Id = 1,
                Name = "dinesh",
                Password = "Dinesh@0524",
                Email_Id = "dhineshkumarm1999@gmail.com",
                PhoneNum = "7010388796",
                Gender = "male",
                Age = 22,
                Location = "madurai"
            });
            List<Employee> Listobj = new List<Employee>();
            Listobj.Add(obj);
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.GetbyId(It.IsAny<int>())).Returns(obj);
            var controller = new LeavingController(mockService.Object);

            var exception = controller.GetbyId(obj.Emp_Id);

            Assert.IsType<OkObjectResult>(exception);
        }


        [Fact]
        public void Getbyid_NotFound()
        {
            Employee obj = new Employee() { };
            List<Employee> Listobj = new List<Employee>();
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.GetbyId(It.IsAny<int>())).Returns(obj);
            var controller = new LeavingController(mockService.Object);

            var exception = Assert.Throws<Exception>(() => controller.GetbyId(1));

            Assert.NotNull(exception);
        }

        [Fact]
        public void AddEmployee_okResult()
        {
            Message msg = new Message();
            Employee obj = (new Employee
            {
                Emp_Id = 1,
                Name = "dinesh",
                Password = "Dinesh@0524",
                Email_Id = "dhineshkumarm1999@gmail.com",
                PhoneNum = "7010388796",
                Gender = "male",
                Age = 22,
                Location = "madurai"
            });
            List<Employee> Listobj = new List<Employee>();
            Listobj.Add(obj);
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns(msg);
            var controller = new LeavingController(mockService.Object);

            var exception = controller.createmployees(obj);

            Assert.Null(exception);
        }


        [Fact]
        public void UpdateEmployee_OkResult()
        {
            Message msg = new Message();
            Employee obj = (new Employee
            {
                Emp_Id = 1,
                Name = "dinesh",
                Password = "Dinesh@0524",
                Email_Id = "dhineshkumarm1999@gmail.com",
                PhoneNum = "7010388796",
                Gender = "male",
                Age = 22,
                Location = "madurai"
            });
            List<Employee> Listobj = new List<Employee>();
            Listobj.Add(obj);
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.GetbyId(It.IsAny<int>())).Returns(obj);
            mockService.Setup(x => x.UpdateEmp(It.IsAny<Employee>())).Returns(msg);
            var controller = new LeavingController(mockService.Object);

            var exception = controller.update(obj);

            Assert.NotNull(exception);
        }



        [Fact]
        public void UpdateEmployee_NotFoundResult()
        {
            Message msg = new Message();
            Employee obj = new Employee() { };
            List<Employee> Listobj = new List<Employee>();
            Listobj.Add(obj);
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.UpdateEmp(It.IsAny<Employee>())).Returns(msg);
            var controller = new LeavingController(mockService.Object);

            var exception = Assert.Throws<Exception>(() => controller.DeleteEmp(110));

            Assert.Equal("This employee id not registered", exception.Message);
        }


        [Fact]
        public void DeleteEmployee_OkResult()
        {
            Message msg = new Message();
            Employee obj = (new Employee
            {
                Emp_Id = 1,
                Name = "dinesh",
                Password = "Dinesh@0524",
                Email_Id = "dhineshkumarm1999@gmail.com",
                PhoneNum = "7010388796",
                Gender = "male",
                Age = 22,
                Location = "madurai"
            });
            List<Employee> Listobj = new List<Employee>();
            Listobj.Add(obj);
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.GetbyId(It.IsAny<int>())).Returns(obj);
            mockService.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(msg);
            var controller = new LeavingController(mockService.Object);

            var exception = controller.DeleteEmp(1);

            Assert.NotNull(exception);
        }

        [Fact]
        public void DeleteEmployee_NotFound()
        {
            Message msg = new Message();
            Employee obj = new Employee() { };
            List<Employee> Listobj = new List<Employee>();
            var mockService = new Mock<ILeaving>();
            mockService.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(msg);
            var controller = new LeavingController(mockService.Object);

            var exception = Assert.Throws<Exception>(() => controller.DeleteEmp(110));

            Assert.Equal("This employee id not registered", exception.Message);
        }
    }

}

