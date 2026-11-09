namespace backend_bg_v3.Models
{
    public class SolicitudDetalle
    {
        public int SolicitudDetalleId { get; set; }

        public int SolicitudId { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
