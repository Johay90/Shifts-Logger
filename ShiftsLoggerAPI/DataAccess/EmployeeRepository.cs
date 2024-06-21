﻿using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using ShiftsLoggerAPI.Interfaces;

namespace ShiftsLoggerAPI.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private ShiftLoggerContext _context;

        public EmployeeRepository(ShiftLoggerContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees
                .Include(e => e.Shifts)
                .First(e => e.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees
                .Include(e => e.Shifts)
                .ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }


    }
}
