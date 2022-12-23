using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using backend.Services.Students;

namespace backend.Schema
{
    public class Query
    {
        private readonly StudentsRepository _studentsRepository;
        public Query(StudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            IEnumerable<StudentDTO> studentDTOs = await _studentsRepository.GetAll();
            return studentDTOs;
        }
        public async Task<StudentDTO?> GetStudentById(Guid studentId)
        {
            StudentDTO? student = await _studentsRepository.GetById(studentId);
            return student;
        }
    }
}