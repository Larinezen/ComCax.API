using ComCax.API.Models;
namespace ComCax.API.Repositories

{
    public interface ILancamentoRepository
    {
        void AdicionarLancamento(Lancamento lancamento);
        List<Lancamento> ObterLancamentosPorData(DateTime data);
    }
}
