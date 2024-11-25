using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramCRUD.Models
{
    public class Dosen
    {
        [Key]
        [Column(TypeName = "char(10)")]
        public string? DosenID { get; set; }

        [Required(ErrorMessage = "Please input Name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please input NIP!")]
        public string? NIP { get; set; }

        [Required(ErrorMessage = "Please input Telephone!")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Please select Gender!")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please input Address!")]
        public string? Address { get; set; }

        public bool Active { get; set; } = true;
    }
}
