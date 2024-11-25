using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace ProgramCRUD.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input Name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please input NIP!")]
        public string? NIP { get; set; }

        [Required(ErrorMessage = "Please input Telephone!")]
        public string? Telephone { get; set; }
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please input Address!")]
        public string? Address { get; set; }
        public DateOnly Birthdate { get; set; }
    }
}
