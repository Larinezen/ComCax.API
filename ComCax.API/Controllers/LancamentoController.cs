using ComCax.API.DTO; // Importa o namespace que contém a classe LancamentoRequest
using ComCax.API.Services;  // Importa o namespace que contém a classe LancamentoService
using ComCax.API.Models;
using Microsoft.AspNetCore.Mvc;   // Importa o namespace que contém a classe SaldoDiario

namespace ComCax.API.Controllers
{
    [ApiController] // Indica que esta classe é um controlador de API
    [Route("api/v1/lancamentos")] // Define a rota base para os endpoints deste controlador
    public class LancamentoController : ControllerBase // Define a classe do controlador que herda de ControllerBase, forncendo funcionalidades basicas para controladores de API
    {
        private readonly LancamentoService _lancamentoService; // Serviço de lançamentos para manipulação da lógica de negócios
        public LancamentoController(LancamentoService lancamentoService) // Construtor que recebe uma instância do serviço de lançamentos via injeção de dependência
        {
            _lancamentoService = lancamentoService; // Inicializa o serviço de lançamentos
        }
        [HttpPost] // Define que este método responde a requisições HTTP POST
        public IActionResult RegistrarLancamento([FromBody] LancamentoRequest request) // Método para registrar um novo lançamento, recebendo os dados no corpo da requisição
        {
            try
            {
                var lancamento = request.ConverterParaLancamento(); // Converte o request em um objeto do tipo Lancamento
                _lancamentoService.RegistrarLancamento(lancamento); // Chama o serviço para registrar o lançamento
                return Ok("Lançamento registrado com sucesso."); // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
            }
            catch (ArgumentException ex) // Captura exceções do tipo ArgumentException
            {
                return BadRequest(ex.Message); // Retorna uma resposta HTTP 400 Bad Request com a mensagem da exceção
            }
            catch (Exception) // Captura quaisquer outras exceções
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }    
        }

        [HttpGet("saldo-diario")] // Define que este método responde a requisições HTTP GET na rota "saldo-diario"
        public IActionResult ObterSaldoDiario([FromQuery] DateTime data)
        {
            try
            {
                var saldo = _lancamentoService.CalcularSaldoDiario(data); // Chama o serviço para calcular o saldo diário com base na data fornecida
                return Ok(saldo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpGet("lancamentos-por-data")] // Define que este método responde a requisições HTTP GET na rota "lancamentos-por-data"
        public IActionResult ObterLancamentosPorData([FromQuery] DateTime data)
        {
            try
            {
                var lancamentos = _lancamentoService.ListarLancamentosPorData(data);
                return Ok(lancamentos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

    }
}
