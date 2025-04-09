using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeManager.Services;
using EmployeeManager; // để dùng EmployeeContext
using EmployeeManager.Data;
namespace EmployeeManager.Tests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        [TestMethod]
        public void AddEmployee_WithValidData_ShouldReturnSuccess()
        {
            // Tạo context giả (In-Memory hoặc context thật tùy theo nhu cầu)
            var context = new EmployeeContext(); // nếu EmployeeContext chưa có constructor không tham số thì mình sẽ mock
            var service = new EmployeeService(context);

            // Act
            bool result = service.AddEmployee("Khánh", "Bảo vệ", "Đang làm", "Bãi A");

            // Assert
            Assert.IsTrue(result);
        }
    }
}
