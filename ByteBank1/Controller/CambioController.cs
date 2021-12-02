using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank1.Infraestrutura;
using ByteBank1.Filtros;
using System;
using ByteBank.Service.Cartao;

namespace ByteBank1.Controller
{
    public class CambioController : ControllerBase 
    {
        private ICambioService _cambioService;
        private ICartaoService _cartaoService;

        public CambioController(ICambioService cambioService, ICartaoService cartaoService)
        {
            _cambioService =  cambioService;
            _cartaoService = cartaoService;
        }

        [ApenasHorarioComercialFiltro]
        public string MXN()
        {
           var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
           var textoPagina = View();
           
           var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

           return textoResultado;
        }
        [ApenasHorarioComercialFiltro]
        public string USD()
        {
           var valorFinal = _cambioService.Calcular("USD", "BRL", 1);
           return View(new {
               Valor = valorFinal
            });
        }
        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var cartaoPromocao = _cartaoService.ObterCartaoDeCreditoDeDestaque();

            var modelo = new {
                MoedaDestino = moedaDestino,
                ValorDestino = valorFinal,
                MoedaOrigem = moedaOrigem,
                ValorOrigem = valor,
                CartaoPromocao = cartaoPromocao
            };

            return View(modelo);
        }
        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BRL", moedaDestino, valor);


    }
}
