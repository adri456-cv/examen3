namespace examen3Contabilidad
{
    public class FacturaDTO
    {
        public int Codigo { get; set; }
        public int ClienteCi { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Pagada { get; set; }

       
    }
}
