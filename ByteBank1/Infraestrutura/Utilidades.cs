﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Infraestrutura
{
    public static class Utilidades
    {
        public static string ConverterPathParaNomeAssembly(string path)
        {
            var prefixoAssembly = "ByteBank1";
            var pathComPontos = path.Replace("/", ".");
            var nomeCompleto = $"{prefixoAssembly}{pathComPontos}";

            return nomeCompleto;
        }

        public static string ObterTipoDeConteudo(string path)
        {
            if (path.EndsWith(".css"))
                return "text/css; charset=utf-8";
            if (path.EndsWith(".js"))
                return "application/js; charset=utf-8";
            if (path.EndsWith(".html"))
                return "text/html; charset=utf-8";
            throw new NotImplementedException("Tipo de conteudo não previsto!");
        }
            

    }
}