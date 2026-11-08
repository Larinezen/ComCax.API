namespace ComCax.API.Models
{
    public class Despesa : Lancamento
    {
        public string Categoria { get; private set; }
        public Despesa(DateTime dataDespesa, string descricao, decimal valor, string categoria)
            : base(dataDespesa, descricao, valor) // Chama o construtor da classe base Lancamento
        {
            if (string.IsNullOrWhiteSpace(categoria))
            {
                throw new ArgumentException("A categoria da despesa não pode ser vazia.", nameof(categoria));
            }
            Categoria = categoria;

        }
        public override decimal CalcularEfeitoNoSaldo()
        {
            return -Valor; // A despesa  diminui o saldo, então retornamos o valor negativo
        }

    }
}
