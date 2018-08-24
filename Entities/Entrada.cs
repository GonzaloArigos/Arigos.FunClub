using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CargaMasivaEntrada
    {
        public List<DAL.Entrada> Registradas { get; set; }
        public List<DAL.Entrada> Excluidas { get; set; }

    }
}
