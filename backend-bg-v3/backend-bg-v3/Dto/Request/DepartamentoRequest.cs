using System.ComponentModel.DataAnnotations;

namespace backend_bg_v3.Dto.Request
{
    public class DepartamentoRequest
    {
        [Required]
        [StringLength(60)]
        public string Nombre { get; set; } = string.Empty;
        public int? ResponsableId { get; set; }
        public bool Estado { get; set; } = true;
    }
}