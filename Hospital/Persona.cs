using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Persona
    {
        public Persona(string nombre, int edad, string sexo, string docIdentidad, string email, int numTelefono)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            DocIdentidad = docIdentidad;
            Email = email;
            NumTelefono = numTelefono;
        }

        public  string Nombre { get; set; }
        public int Edad { get; set; }
        public  string Sexo { get; set; }
        public string DocIdentidad { get; set; }
        public string Email { get; set; }
        public int NumTelefono { get; set; }
    }
}
