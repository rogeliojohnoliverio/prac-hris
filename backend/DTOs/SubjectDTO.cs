using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class SubjectDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid InstructorId { get; set; }
        public InstructorDTO? Instructor { get; set; } = default!;
        public ICollection<StudentDTO> Students { get; set; } = default!;
    }
}