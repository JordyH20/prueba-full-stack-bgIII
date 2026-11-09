namespace backend_bg_v3.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }
        public string Identficacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; } 
    }
}

