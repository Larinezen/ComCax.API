using ComCax.API.Models;


namespace ComCax.API.DTO
{
    public class LancamentoRequest
    {
        public string Tipo { get; set; } // Tipo de lançamento (ex: "Venda", "RecebimentoCartao")
        public DateTime DataLancamento { get; set; } // Data do lançamento
        public string Descricao { get; set; } // Descrição do lançamento
        public decimal Valor { get; set; } // Valor do lançamento
        public string? Categoria { get; set; } // Categoria do lançamento (Só despesa)
        public decimal? Taxa { get; set; } // Taxa do recebimento do cartão (Só para RecebimentoCartao)
    

    public Lancamento ConverterParaLancamento()
        {
            switch (Tipo?.ToLower())
            {
                case "venda":
                    return new Venda(DataLancamento, Descricao, Valor);
                case "recebimentocartao":
                    if (Taxa == null)
                    {
                        throw new ArgumentException("A taxa deve ser fornecida para o tipo de lançamento 'RecebimentoCartao'.");
                    }
                    
                    return new RecebimentoCartao(DataLancamento, Descricao, Valor, Taxa.Value);
                case "despesa":
                    
                    return new Despesa(DataLancamento, Descricao, Valor, Categoria!);
                default:
                    throw new ArgumentException($"Tipo de lançamento inválido: {Tipo}");
            }
        }
    }

}