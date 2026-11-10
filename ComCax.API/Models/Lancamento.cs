
namespace ComCax.API.Models
{
    public abstract class Lancamento
    {
        public int IdLancamento { get; private set; }
        public DateTime DataLancamento { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }

        // Construtor protegido para ser chamado pelas classes derivadas

        public const int TamanhoMaximoDescricao = 200; // Definindo o tamanho máximo da descrição como uma constante
        protected Lancamento(DateTime dataLancamento, string descricao, decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor do lançamento não pode ser zero ou negativo.");
            }
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição do lançamento não pode ser vazia.", nameof(descricao));
            }
            if(descricao.Length > TamanhoMaximoDescricao)
            {
                throw new ArgumentException($"A descrição do lançamento não pode exceder {TamanhoMaximoDescricao} caracteres.", nameof(descricao));
            }





            DataLancamento = dataLancamento;
            Descricao = descricao;
            Valor = valor;


        }
        public abstract decimal CalcularEfeitoNoSaldo();

    }
}