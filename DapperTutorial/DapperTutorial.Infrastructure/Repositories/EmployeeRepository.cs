﻿using Dapper;
using DapperTutorial.Core.Entities;
using DapperTutorial.Core.Interfaces;
using DapperTutorial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTutorial.Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        DapperDbContext dbContext;
        public EmployeeRepository()
        {
            dbContext = new DapperDbContext();
        }
        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            IDbConnection conn = dbContext.GetConnection();
            string sql = "Select e.Id, e.FirstName, e.LastName, e.Salary, d.Id, d.DName, d.Loc " +
                "From Employee e Inner Join Department d On e.DeptId = d.Id";
            return conn.Query<Employee, Department, Employee>(sql, (e, d) => { e.Dept = d; return e; }); 
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee obj)
        {
            IDbConnection conn = dbContext.GetConnection();
            return conn.Execute("Insert Into Employee Values(@FirstName, @LastName, @Salary, @DeptId)", obj);
        }

        public int Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
