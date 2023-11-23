using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.EmployeeManagement.Query;

namespace UPS.EmployeeManagement.Command
{
    public class EmployeeCommandService : IEmployeeCommand
    {
        private readonly string _baseUrl;
        private readonly string _token;

        public EmployeeCommandService(string baseUrl, string token)
        {
            _baseUrl = baseUrl;
            _token = token;
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
            return client;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            using HttpClient client = GetClient();

            var response = await client.PutAsync($"{_baseUrl}/users/{employee.Id}", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(employee)));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("User not saved");
            }

        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            using HttpClient client = GetClient();

            var response = await client.DeleteAsync($"{_baseUrl}/users/{employeeId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("User not deleted");
            }
        }
    }
}
