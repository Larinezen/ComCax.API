using ComCax.API.Models;

namespace ComCax.API.Exportadores
{
    public interface IExportadorRelatorio
    {
        string Exportar(SaldoDiario saldo);
    }
}
