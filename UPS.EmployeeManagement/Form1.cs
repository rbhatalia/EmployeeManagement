using System.Windows.Forms;
using Newtonsoft.Json;
using UPS.EmployeeManagement.Command;
using UPS.EmployeeManagement.Logging;
using UPS.EmployeeManagement.Query;

namespace UPS.EmployeeManagement
{
    public partial class Form1 : Form
    {
        private readonly ILogger _logger;   
        private readonly IEmployeeCommand _employeeCommand;
        private readonly IEmployeeQuery _employeeQuery;

        public Form1(IEmployeeCommand employeeCommand, IEmployeeQuery employeeQuery)
        {
            InitializeComponent();

            _employeeCommand = employeeCommand;
            _employeeQuery = employeeQuery;

            FetchAndDisplayEmployees();

            SetupCellEdit();
        }

        private void SetupCellEdit() {
            try
            {

                dgListEmployees.CellEndEdit += async (sender, e) =>
                {
                    var employee = (Employee)dgListEmployees.Rows[e.RowIndex].DataBoundItem;
                    await UpdateEmployee(employee);
                };

                // Cancel edit on escape key  
                dgListEmployees.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        dgListEmployees.CancelEdit();
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task FetchAndDisplayEmployees()
        {
            try
            {
                var employees = await _employeeQuery.GetEmployeesAsync();
                dgListEmployees.DataSource = employees;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                await _employeeCommand.UpdateEmployeeAsync(employee);
                MessageBox.Show("User was edited successfully", "Success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchUser.Text))
                {
                    var employees = await _employeeQuery.SearchEmployeesAsync(txtSearchUser.Text);
                    dgListEmployees.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("Please enter user to filter");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
            
        }

        public async void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearchUser.Text = string.Empty;

                await FetchAndDisplayEmployees();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgListEmployees.SelectedRows.Count > 0)
                {
                    var employee = dgListEmployees.SelectedRows[0].DataBoundItem as Employee;

                    await _employeeCommand.DeleteEmployeeAsync(employee!.Id);

                    await FetchAndDisplayEmployees();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }          

        }
    }
}

