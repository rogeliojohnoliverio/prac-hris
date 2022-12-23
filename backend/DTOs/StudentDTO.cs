using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class StudentDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<SubjectDTO> Subjects { get; set; } = default!;
        public string? Course { get; set; }
        public int Year { get; set; }
    }
}