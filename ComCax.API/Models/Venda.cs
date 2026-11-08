

namespace ComCax.API.Models
{
    public class  Venda : Lancamento
    {
        // Construtor da classe Venda
        public   Venda(DateTime dataLancamento, string descricao, decimal valor)
            : base(dataLancamento, descricao, valor) // Chama o construtor da classe base Lancamento
        {

        }
        public override decimal CalcularEfeitoNoSaldo()
        {
            return Valor; // A venda aumenta o saldo, então retornamos o valor positivo
        }


    }
}
