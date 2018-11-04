using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2P1
{
    public class Sort<T> : IComparer<T>
    {
        int IComparer<T>.Compare(T x, T y)
        {
        }
    }
}


/*
 * Por ID (ascendente)
Por nome (ascendente, por ordem alfabética)
Por data de lançamento (descendente, do mais recente para o mais antigo)
Por número de DLCs (descendente)
Por nota no Metacritic (descendente)
Por número de recomendações (descendente)
Por número de pessoas que têm o jogo (descendente)
Por número de pessoas que efetivamente jogaram ao jogo (descendente)
Por número de achievements (descendente)
*/
