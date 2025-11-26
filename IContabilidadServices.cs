namespace examen3Contabilidad
{
    public interface IContabilidadService
    {
        Task<decimal> ObtenerSaldoPorCI(int ci);
    }

}
