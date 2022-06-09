using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext context;
        public EmployeeRepository(MyContext context)
        {
            this.context = context;
        }

        public int Delete(string NIK)
        { 
            var entity = context.Employees.Find(NIK);
            context.Remove(entity);
            return context.SaveChanges();
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees.ToList();
        }

        public Employee Get(string NIK)
        {
            return context.Employees.Find(NIK);
        }

        public Employee GetFName(string FirstName)
        {
            Employee emp = (from a in context.Employees
                            where a.FirstName == FirstName
                            select a).FirstOrDefault();
            return emp;
        }

        public int Insert(Employee employee)
        {

                context.Employees.Add(employee);
                var result = context.SaveChanges();
                return result;
         
        }
        public int Update(Employee employee)
        {
                context.Entry(employee).State = EntityState.Modified;
                var result = context.SaveChanges();
                return result;
        }
    }
}
