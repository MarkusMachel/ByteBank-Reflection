using ByteBank.Service;
using ByteBank.Service.Cartao;
using ByteBank1.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Controller
{
    public class CartaoController : ControllerBase
    {
        private ICartaoService _cartaoService;

        public CartaoController(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }
        public string Debito() =>
            View(new { CartaoNome = _cartaoService.ObterCartãoDeDebitoDeDestaque() });

        public string Credito() =>
            View(new { CartaoNome = _cartaoService.ObterCartaoDeCreditoDeDestaque() });
    }
}
