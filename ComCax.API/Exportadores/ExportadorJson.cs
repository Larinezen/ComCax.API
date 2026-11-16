using ComCax.API.Models;
using System.Text.Json; 

namespace ComCax.API.Exportadores
{
    public class ExportadorJson : IExportadorRelatorio
    {
        public string Exportar(SaldoDiario saldo)
        {
            // Implementação para exportar o saldo em formato JSON
            return JsonSerializer.Serialize(saldo);
        }
    }
}
