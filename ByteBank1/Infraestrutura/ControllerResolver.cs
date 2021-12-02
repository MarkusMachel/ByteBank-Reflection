using ByteBank1.Infraestrutura.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Infraestrutura
{
    public class ControllerResolver
    {
        private readonly IContainer _container;

        public ControllerResolver(IContainer container)
        {
            _container = container;
        }

        public object ObterController(string nomeContoller)
        {
            var tipoController = Type.GetType(nomeContoller);
            var instanciaController = _container.Recuperar(tipoController);
            return instanciaController;
        }
    }
}
