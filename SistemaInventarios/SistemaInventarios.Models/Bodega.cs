using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarios.Models
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [MaxLength(60, ErrorMessage = "No mas de 60 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Indique una descripción")]
        [MaxLength(400, ErrorMessage = "Mucho texto we")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Indique el estado")]
        [Display(Name = "Estado")]
        public bool State { get; set; }
    }
}
