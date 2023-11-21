using Microsoft.AspNetCore.Mvc;
using UnitTestCase.Controllers;
using UnitTestCase.Models;
using UnitTestCase.Services;

namespace UnitTestCaseDemo.Test
{
    public class EmployeeControllerTest
    {
        EmployeeController _controller;
        IEmployeeService _service;

        public EmployeeControllerTest()
        {
            _service = new EmployeeService();
            _controller = new EmployeeController(_service);
        }

        [Fact]
        public void GetAll_Employee_Success()
        {
            var result = _controller.Get();
            var resultType = result as OkObjectResult;
            var resultList = resultType.Value as List<Employee>;

            Assert.NotNull(result);
            Assert.IsType<List<Employee>>(resultType.Value);
            Assert.Equal(3, resultList.Count);

        }
        [Fact]
        public void GetById_Employee_Success() 
        {
            int valid_empid = 101;
            int invalid_empid = 110;

            var errorResult = _controller.Get(invalid_empid);
            var successResult = _controller.Get(valid_empid);
            var successModel = successResult as OkObjectResult;
            var fetchedEmp = successModel.Value as Employee;

            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundResult>(errorResult);
            Assert.Equal(101, fetchedEmp.Id);

        }
        [Fact]
        public void Add_Employee_Success()
        {
            Employee employee = new Employee() {
                Id = 105,
                Name = "Test",
                PhoneNo = "1234567890",
                EmailId = "asdasd@asdasd.com"
            };
            var response = _controller.Post(employee);

             Assert.IsType<CreatedAtActionResult>(response);

             var createdEmp = response as CreatedAtActionResult;
             Assert.IsType<Employee>(createdEmp.Value);

             var employeeItem = createdEmp.Value as Employee;

             Assert.Equal("Test", employeeItem.Name);
             Assert.Equal("1234567890", employeeItem.PhoneNo);
             Assert.Equal("asdasd@asdasd.com", employeeItem.EmailId);

        }
        [Fact]
        public void Delete_Employee_Success()
        {
            int valid_empid = 101;
            int invalid_empid = 110;
            var erroResult = _controller.Delete(invalid_empid);
            var successResult = _controller.Delete(valid_empid);

            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundObjectResult>(erroResult);
        }
    }
}