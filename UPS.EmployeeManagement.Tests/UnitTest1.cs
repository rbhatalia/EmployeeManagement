using Moq;
using System.Windows.Forms;
using UPS.EmployeeManagement.Command;
using UPS.EmployeeManagement.Query;

namespace UPS.EmployeeManagement.Tests
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public async Task FetchAndDisplayEmployees_CallsService()
        {
            
            var mockEmployeeService = new Mock<IEmployeeQuery>();
            var mockEmployeeCommand = new Mock<IEmployeeCommand>();
            mockEmployeeService.Setup(x => x.GetEmployeesAsync())
                .ReturnsAsync(new List<Employee>());

            var form = new Form1(mockEmployeeCommand.Object, mockEmployeeService.Object);

            await form.FetchAndDisplayEmployees();

            mockEmployeeService.Verify(x =>
                x.GetEmployeesAsync(), Times.Once());
        }

        [TestMethod]
        public async Task UpdateEmployee_CallsService()
        {
            var employee = new Employee();

            var mockEmployeeService = new Mock<IEmployeeQuery>();
            var mockEmployeeCommand = new Mock<IEmployeeCommand>();

            mockEmployeeCommand.Setup(x =>
               x.UpdateEmployeeAsync(employee))
               .Returns(Task.CompletedTask)
               .Verifiable();

            var form = new Form1(mockEmployeeCommand.Object, mockEmployeeService.Object);
 
            await form.UpdateEmployee(employee);

            mockEmployeeService.Verify();
        }

        [TestMethod]
        public async Task DeleteEmployee_RemovesSelectedEmployee()
        {
            // Arrange
            var employee1 = new Employee { Id = 1, Name = "Rohit" };
            var employee2 = new Employee { Id = 2, Name = "Bhatalia" };

            var employees = new List<Employee> { employee1, employee2 };

            var dataGridView = new DataGridView();
            dataGridView.DataSource = employees;

            dataGridView.Rows[0].Selected = true;

            var mockEmployeeService = new Mock<IEmployeeQuery>();
            var employeeCommand = new Mock<IEmployeeCommand>();
            employeeCommand.Setup(x => x.DeleteEmployeeAsync(1))
                .Returns(Task.CompletedTask);

            var form = new Form1(employeeCommand.Object, mockEmployeeService.Object);
            form.dgListEmployees = dataGridView;

            form.btnDelete_Click(null, EventArgs.Empty);
                        
            employeeCommand.Verify(x => x.DeleteEmployeeAsync(1), Times.Once());
            Assert.AreEqual(1, dataGridView.Rows.Count);
            Assert.AreEqual(employee2, dataGridView.Rows[0].DataBoundItem);
        }
    }
}