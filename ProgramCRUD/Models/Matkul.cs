using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace ProgramCRUD.Models
{
    public class Matkul
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KodeMataKuliah { get; set; }

        [Required]
        public string NamaMataKuliah { get; set; }

        [Required]
        public string DosenPengampu { get; set; }
    }
}
