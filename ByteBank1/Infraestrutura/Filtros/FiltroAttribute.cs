﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank1.Infraestrutura.Filtros
{
    public abstract class FiltroAttribute : Attribute
    {
        public abstract bool PodeContinuar();
    }
}
