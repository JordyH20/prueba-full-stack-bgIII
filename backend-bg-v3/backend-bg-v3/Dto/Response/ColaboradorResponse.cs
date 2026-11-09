using System.ComponentModel.DataAnnotations;

namespace backend_bg_v3.Dto.Response
{
    public class ColaboradorResponse
    {
        public int ColaboradorId { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int DepartamentoId { get; set; }
    }
}
