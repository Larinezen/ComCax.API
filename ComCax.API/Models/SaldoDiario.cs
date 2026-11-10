
namespace ComCax.API.Models
{
    public class SaldoDiario 
    {

        public DateTime Data { get; private set; }
        public decimal TotalEntradas { get; private set; }
        public decimal TotalSaidas { get; private set; }
        public decimal Saldo { get; private set; }
        // Recebe lista de lançamentos
        //Calcula entradas, saidas e saldo 

        public SaldoDiario(DateTime data, List<Lancamento> lancamentos)
        {
            Data = data; // Inicializa a data do saldo diário (data que chegou no parâmetro data, ou seja, o dia que alguém pediu para consultar, com a hora zerada.)
            foreach (var lancamento in lancamentos) // Itera sobre cada lançamento na lista
            {
                if (lancamento.DataLancamento.Date == data.Date) // Verifica se o lançamento é do mesmo dia da data fornecida na consulta.
                {
                    var efeito = lancamento.CalcularEfeitoNoSaldo(); // Chama o método para calcular o efeito no saldo
                    if (efeito > 0) // Se o efeito for positivo, é uma entrada
                    {
                        TotalEntradas += efeito;
                    }
                    else
                    {
                        TotalSaidas += -efeito; // Converte para positivo
                    }
                }
            }
            Saldo = TotalEntradas - TotalSaidas;    // Calcula o saldo final do dia
        }

    }
}
