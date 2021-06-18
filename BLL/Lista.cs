using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Lista
    {
        public nodo Primero { get; set; }
        public nodo Ultimo { get; set; }
        public int Contador { get => _contador; set => _contador = value; }
        
        int _contador;
    }
}
