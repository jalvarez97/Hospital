using System.Collections.Generic;

namespace Hospital
{
    public class Medico : Persona
    {
        public Medico() { }      

        public Medico(Persona p, int numcColegiado, string especialidad) : base(p.Nombre, p.Edad, p.Sexo, p.DocIdentidad
                                                                               ,p.NumTelefono,true)
        {
            NumColegiado = numcColegiado;
            Especialidad = especialidad;
        }
        //Constructor para la automatizacion
        public Medico(string nombre, int edad, string sexo, string docIdentidad
                     , int numeroTelefono, int numcColegiado, string especialidad) : base(nombre, edad, sexo, docIdentidad, numeroTelefono, true)
        {
            NumColegiado = numcColegiado;
            Especialidad = especialidad;
        }

        //Propiedades
        public int NumColegiado { get; set; }      
        public string Especialidad { get; set; }

        public List<Paciente> Pacientes = new List<Paciente>();        

        //Métodos
        public override string ToString()
        {
            return base.ToString() + " | NumColegiado: " + NumColegiado + " | Especialidad: " + Especialidad;
        }
    }
}
