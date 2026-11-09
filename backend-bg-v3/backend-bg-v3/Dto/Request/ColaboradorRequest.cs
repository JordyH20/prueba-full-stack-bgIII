using backend_bg_v3.Models;
using System.ComponentModel.DataAnnotations;

namespace backend_bg_v3.Dto.Request
{
    public class ColaboradorRequest
    {
        [Required]
        [StringLength(10)]
        public string Identificacion { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int DepartamentoId { get; set; }
    }
}
