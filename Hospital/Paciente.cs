
namespace Hospital
{
    public class Paciente : Persona
    {
        public Paciente() { }

        public Paciente(string nombre, int edad, string sexo, string docIdentidad
                       , string email, int numeroTelefono, string enfermedad, string tratamiento) : base(nombre, edad, sexo, docIdentidad, email, numeroTelefono, false)
        {
            Enfermedad = enfermedad;
            Tratamiento = tratamiento;
        }

        public string Enfermedad { get; set; }        
        public string Tratamiento { get; set; }
        

        public override string ToString()
        {
            return base.ToString() + " | Enfermedad: " + Enfermedad + " | Tratamiento: " + Tratamiento;
        }
    }
}
