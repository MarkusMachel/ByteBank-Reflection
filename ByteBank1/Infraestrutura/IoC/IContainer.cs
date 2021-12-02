using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Infraestrutura.IoC
{
    public interface IContainer
    {
        void Registrar(Type tipoOrigem, Type tipoDestino);
        object Recuperar(Type tipoOrigem);
    }
}
