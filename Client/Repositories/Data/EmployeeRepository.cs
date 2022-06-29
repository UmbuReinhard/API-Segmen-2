using API.Models;
using API.ViewModel;
using Client.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;



        public EmployeeRepository(Address address, string request = "Employee/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }



        public async Task<Object> GetAllRegis()
        {
            Object obj;
            using (var repo = await httpClient.GetAsync(request + "GetAll/"))
            {
                string apiRepo = await repo.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeObject(apiRepo);
            }
            return obj;
        }



        public async Task<Object> InsertEmployee(RegisterEmployeeVM obj)
        {
            Object objectEMP;

            /*httpClient.PostAsync(address.link + request, content).Result;*/
            StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var repo = httpClient.PostAsync(request + "Register/", content).Result;

            string apiRepo = await repo.Content.ReadAsStringAsync();

       
            if (!String.IsNullOrEmpty(apiRepo))
            {
                objectEMP = JsonConvert.DeserializeObject(apiRepo);
            }
            else
            {
                objectEMP = null;
            }

            return objectEMP;

            /*using (var repo = await httpClient.PostAsync(request + "Register/"))
            {
                string apiRepo = await repo.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject(apiRepo);
            }
            return entities;*/
        }

    }
}
