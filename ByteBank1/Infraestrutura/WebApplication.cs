using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using ByteBank1.Controller;
using ByteBank1.Infraestrutura.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Infraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;
        private readonly IoC.IContainer _container = new ContainerSimples();
        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
                throw new ArgumentNullException(nameof(prefixos));
            _prefixos = prefixos;

            Configurar();
        }

        private void Configurar()
        {
            _container.Registrar(typeof(ICambioService), typeof(CambioTesteService));
            _container.Registrar(typeof(ICartaoService), typeof(CartaoServiceTeste));
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();

        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.PathAndQuery;
            Console.WriteLine(path);

            if (Utilidades.EhArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController(_container);
                manipulador.Manipular(resposta, path);
            }





           

            
            httpListener.Stop();
        }
    }
}
