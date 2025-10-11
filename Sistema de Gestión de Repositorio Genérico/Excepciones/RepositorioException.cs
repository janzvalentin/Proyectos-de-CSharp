using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Excepciones
{
    //Excepcion personalizada
    public class RepositorioException : Exception
    {
        //Constructor basico que solo toma un mensaje
        public RepositorioException(string message) : base(message) { }

        //constructor que acepta un mensaje y una excepcion interna
        public RepositorioException(string message, Exception inner) : base(message, inner) { }
    }
}
