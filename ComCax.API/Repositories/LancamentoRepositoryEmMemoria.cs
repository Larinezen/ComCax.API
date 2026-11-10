using ComCax.API.Models;

namespace ComCax.API.Repositories
{
    public class LancamentoRepositoryEmMemoria : ILancamentoRepository
    {
        private readonly List<Lancamento> _lancamentos; // Lista interna para armazenar os lançamentos em memória
        public LancamentoRepositoryEmMemoria()
        {
            _lancamentos = new List<Lancamento>(); // Inicializa a lista de lançamentos vazia
        }
        public void AdicionarLancamento(Lancamento lancamento) // Adiciona um novo lançamento à lista
        {
            if (lancamento == null)
            {
                throw new ArgumentNullException(nameof(lancamento), "O lançamento não pode ser nulo.");
            }
            _lancamentos.Add(lancamento); // Adiciona o lançamento à lista interna
        }
        public List<Lancamento> ObterLancamentosPorData(DateTime data) // Retorna uma lista de lançamentos filtrados pela data fornecida
        {
            return _lancamentos.Where(l => l.DataLancamento.Date == data.Date).ToList(); // Filtra os lançamentos pela data e retorna a lista resultante
        }
    }
}
