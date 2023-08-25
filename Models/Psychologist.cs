using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PjJefersonSouza.Models
{
    public class Psychologist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Crp requerido.")]
        [Display(Name = "Crp")]
        public string? Crp { get; set; }

        [Required(ErrorMessage = "especialidade requerido.")]
        [Display(Name = "Especialidade")]
        public string? Specialty { get; set; }

    }
}


