namespace backend_bg_v3.Models
{
    public class Solicitud
    {
        public int SolicitudId { get; set; }
        public int DepartamentoId { get; set; }
        public int SolicitanteId { get; set; }
        public string Justificacion { get; set; } = string.Empty;

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "PENDIENTE";

        public decimal ImporteTotal { get; set; }

        public List<SolicitudDetalle> Detalles { get; set; } = new();


    }
}