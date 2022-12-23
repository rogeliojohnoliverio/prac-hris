using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Students
{
    public class StudentsRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

        public StudentsRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<StudentDTO>> GetAll()
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Students
                  .Include(s => s.Subjects)
                  .ThenInclude(i => i.Instructor)
                  .ToListAsync();
            }
        }
        public async Task<StudentDTO?> GetById(Guid studentId)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Students
                  .Include(s => s.Subjects)
                  .ThenInclude(i => i.Instructor)
                  .FirstOrDefaultAsync(c => c.Id == studentId);
            }
        }
        public async Task<StudentDTO> Create(StudentDTO student)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                context.Students.Add(student);
                await context.SaveChangesAsync();

                return student;
            }
        }
        public async Task<StudentDTO> Update(Guid id, StudentDTO student)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                context.Students.Update(student);
                await context.SaveChangesAsync();
                return student;
            }
        }
        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                context.Students.Remove(new StudentDTO
                {
                    Id = id
                });
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}