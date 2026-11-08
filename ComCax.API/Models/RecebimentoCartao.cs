namespace ComCax.API.Models
{
    public class RecebimentoCartao : Venda
    {
        public decimal Taxa { get; private set; } // Propriedade para armazenar a taxa do recebimento do cartão
        public RecebimentoCartao(DateTime dataRecebimento, string descricao, decimal valor, decimal taxa)
            : base(dataRecebimento, descricao, valor) // Chama o construtor da classe base Venda
        {
            if (taxa < 0 || taxa > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(taxa), "A taxa deve estar entre 0% e 10%.");
            }
            Taxa = taxa;

        }
        public override decimal CalcularEfeitoNoSaldo()
        {
            return Valor - (Valor * Taxa / 100); // O recebimento do cartão aumenta o saldo, mas com a taxa aplicada
        }
    }
}

