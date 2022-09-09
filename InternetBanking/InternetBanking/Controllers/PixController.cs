using InternetBanking.Model;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    public class PixController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Enviar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enviar(IFormCollection formCollection)
        {
            var chave = (formCollection["chave"].FirstOrDefault() ?? "").Trim();

            var tipoChave = (formCollection["tipoChave"].FirstOrDefault() ?? "").Trim().ToUpper();

            var valorExpression = (formCollection["valor"].FirstOrDefault() ?? "0").Trim().ToUpper();

            _ = decimal.TryParse(valorExpression, out decimal valor);

            string? status = null;

            if (valor == 0)
                status = "Valor não pode ser 0";

            var conta = ContaRepository.Get(tipoChave, chave);

            if (conta == null)
                status = "Conta não encontrada com o tipo e chave";

            status ??= "SUCESSO";

            var pix = new Pix()
            {
                Conta = conta,
                IdTransacao = Guid.NewGuid(),
                Status = status,
                Valor = valor
            };

            PixRepository.Save(pix);

            return RedirectToAction("Comprovante", new { idTransacao = pix.IdTransacao });
        }

        public IActionResult Comprovante(Guid idTransacao)
        {
            var pix = PixRepository.Get(idTransacao);

            if (pix == null)
                throw new Exception("Pix não encontrado");

            return View(pix);
        }

    }
}
