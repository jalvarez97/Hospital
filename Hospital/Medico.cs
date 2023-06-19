using System.Collections.Generic;

namespace Hospital
{
    public class Medico : Persona
    {
        public Medico(Persona p, int numcColegiado, string especialidad) : base(p.Nombre, p.Edad, p.Sexo, p.DocIdentidad
                                                                               ,p.NumTelefono)
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
