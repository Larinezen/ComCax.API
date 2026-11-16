using ComCax.API.Models;
using ComCax.API.Repositories;

namespace ComCax.API.Services
{
    public class LancamentoService
    {
        private readonly ILancamentoRepository _repositorio; // Repositório de lançamentos para persistência e recuperação de dados

        public LancamentoService(ILancamentoRepository repositorio)
        {
            _repositorio = repositorio; // Inicializa o repositório de lançamentos através da injeção de dependência
        }

        public void RegistrarLancamento(Lancamento lancamento) 
        {
            if (lancamento == null) // Verifica se o lançamento fornecido é nulo e lança uma exceção se for o caso
            {
                throw new ArgumentNullException(nameof(lancamento), "O lançamento não pode ser nulo.");
            }
            _repositorio.AdicionarLancamento(lancamento); // Adiciona o lançamento ao repositório
        }   

        public List<Lancamento> ListarLancamentosPorData(DateTime data)
        {
            return _repositorio.ObterLancamentosPorData(data); // Retorna os lançamentos do repositório filtrados pela data fornecida
        }

        public SaldoDiario CalcularSaldoDiario(DateTime data)
        {   
            var lancamentos = _repositorio.ObterLancamentosPorData(data); // Obtém os lançamentos do repositório filtrados pela data fornecida
            return new SaldoDiario(data, lancamentos); // Retorna uma instância de SaldoDiario com os lançamentos obtidos
        }

        
    }
}
