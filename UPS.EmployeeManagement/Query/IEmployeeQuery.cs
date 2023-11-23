using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.EmployeeManagement.Query
{
    public interface IEmployeeQuery
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<List<Employee>> SearchEmployeesAsync(string searchTerm);
    }
}
