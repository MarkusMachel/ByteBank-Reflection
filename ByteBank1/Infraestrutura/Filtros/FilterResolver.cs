using ByteBank1.Filtros;
using ByteBank1.Infraestrutura.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Infraestrutura.Filtros
{
    public class FilterResolver
    {
        public FilterResult VerificarFiltros(ActionBindInfo actionBindInfo)
        {
            var methodInfo = actionBindInfo.MethodInfo;

            var atributos = methodInfo.GetCustomAttributes(typeof(FiltroAttribute), false);

            foreach (FiltroAttribute filtos in atributos)
            {
                if(!filtos.PodeContinuar())
                return new FilterResult(false);
            }

            return new FilterResult(true);

        }
    }
}
