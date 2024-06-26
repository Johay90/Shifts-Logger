﻿using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using ShiftsLoggerAPI.Interfaces;

namespace ShiftsLoggerAPI.DataAccess
{
    public class ShiftRepository(ShiftLoggerContext context) : IShiftRepository, IDisposable
    {
        private readonly ShiftLoggerContext _context = context;

        public void Create(Shift shift)
        {
            _context.Add(shift);
            _context.SaveChanges();
        }

        public void Delete(Shift shift)
        {
            _context.Remove(shift);
            _context.SaveChanges();
        }

        public List<Shift> GetAll()
        {
            return [.. _context.Shifts.Include(x => x.Employee)];
        }

        public Shift GetById(int id)
        {
            return _context.Shifts.Include(x => x.Employee).Where(x => x.Id == id).FirstOrDefault()!;
        }

        public void Update(Shift shift)
        {
            _context.Attach(shift);
            _context.Entry(shift).State = EntityState.Modified;
            _context.Update(shift);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
}
