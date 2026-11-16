using ComCax.API.Models;
using System.Globalization;

namespace ComCax.API.Exportadores
{
    public class ExportadorCsv : IExportadorRelatorio
    {
        public string Exportar(SaldoDiario saldo)
        {
            // Implementação para exportar o saldo em formato CSV
            var cultura = CultureInfo.InvariantCulture; // Define a cultura para formatação de números
            var cabecalho = "Data;TotalEntradas;TotalSaidas;Saldo";

            var dados = $"{saldo.Data.ToString("yyyy-MM-dd")};" +
                        $"{saldo.TotalEntradas.ToString(cultura)};" +
                        $"{saldo.TotalSaidas.ToString(cultura)};" +
                        $"{saldo.Saldo.ToString(cultura)}";

            return $"{cabecalho}\n{dados}";
        }
    }
}
