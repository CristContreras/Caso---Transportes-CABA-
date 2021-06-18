using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class nodo
    {
        private string _nombre;
        public string Nombre { get => _nombre; set => _nombre = value; }
        public nodo Siguiente { get; set; }
    }
}
