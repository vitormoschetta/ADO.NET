using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDbDataParameter
    {
        byte Precision { get; set; } // Indica a precisão dos parâmetros numéricos. (default = 0)

        byte Scale { get; set; } // Indica a escala dos parâmetros numéricos.
       
        int Size { get; set; } // O tamanho máximo, em bytes, dos dados na coluna. 
    }
}