namespace examen3Contabilidad
{
    public class PagoDTO
    {
        public int Codigo { get; set; }
        public int FacturaCodigo { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPagado { get; set; }
    }

}
