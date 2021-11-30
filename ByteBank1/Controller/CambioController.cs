using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank1.Infraestrutura;
using ByteBank1.Filtros;
using System;

namespace ByteBank1.Controller
{
    public class CambioController : ControllerBase 
    {
        private ICambioService _cambioService;

        public CambioController()
        {
            _cambioService =  new CambioTesteService();
        }

        [ApenasHorarioComercial]
        public string MXN()
        {
           var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
           var textoPagina = View();
           
           var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

           return textoResultado;
        }
        [ApenasHorarioComercial]
        public string USD()
        {
           var valorFinal = _cambioService.Calcular("USD", "BRL", 1);
           return View(new {
               Valor = valorFinal
            });
        }
        [ApenasHorarioComercial]
        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);

            var modelo = new {
                MoedaDestino = moedaDestino,
                ValorDestino = valorFinal,
                MoedaOrigem = moedaOrigem,
                ValorOrigem = valor
            };

            return View(modelo);
        }
        [ApenasHorarioComercial]
        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BRL", moedaDestino, valor);


    }
}
