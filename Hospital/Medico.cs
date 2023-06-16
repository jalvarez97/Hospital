
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Hospital
{
    public class Medico : Persona
    {
        public Medico() { }
        public Medico(string nombre, int edad, string sexo, string docIdentidad
                     , string email, int numeroTelefono, int numcColegiado, string especialidad) : base(nombre, edad, sexo, docIdentidad, email, numeroTelefono,true)
        {
            NumColegiado = numcColegiado;
            Especialidad = especialidad;
        }

        public int NumColegiado { get; set; }      
        public string Especialidad { get; set; }

        public List<Paciente> Pacientes = new List<Paciente>();        

        public override string ToString()
        {
            return base.ToString() + " | NumColegiado: " + NumColegiado + " | Especialidad: " + Especialidad;
        }
    }
}
