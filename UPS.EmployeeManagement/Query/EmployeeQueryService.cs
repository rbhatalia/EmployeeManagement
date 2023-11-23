using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.EmployeeManagement.Query
{
    public class EmployeeQueryService : IEmployeeQuery
    {
        private readonly string _baseUrl;
        private readonly string _token;

        public EmployeeQueryService(string baseUrl, string token)
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

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();

            using HttpClient client = GetClient();

            var response = await client.GetAsync($"{_baseUrl}/users");

            if (response.IsSuccessStatusCode)
            {
                employees = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync())!;
            }

            return employees!;
        }

        public async Task<List<Employee>> SearchEmployeesAsync(string searchTerm)
        {
            List<Employee> employees = new List<Employee>();

            using HttpClient client = GetClient();

            var response = await client.GetAsync($"{_baseUrl}/users?name={searchTerm}");

            if (response.IsSuccessStatusCode)
            {
                employees = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync())!;
            }

            return employees!;
        }
    }
}
