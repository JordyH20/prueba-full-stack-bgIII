namespace backend_bg_v3.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int? ResponsableId { get; set; } 
        public Colaborador? Responsable { get; set; }
    }
}



