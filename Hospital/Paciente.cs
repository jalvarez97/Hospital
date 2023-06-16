
namespace Hospital
{
    public class Paciente : Persona
    {        
        string Enfermedad { get; set; }        
        string Tratamiento { get; set; }

        public Paciente(string nombre, int edad, string sexo, string docIdentidad
                       ,string email, int numeroTelefono, string enfermedad, string tratamiento) : base(nombre, edad, sexo, docIdentidad, email,numeroTelefono)
        {
            Enfermedad = enfermedad;
            Tratamiento = tratamiento;
        }

        public override string ToString()
        {
            return "ID: " + Nombre + " | Edad: " + Edad + " | Enfermedad: " + Enfermedad + " | Tratamiento: " + Tratamiento;
        }
    }
}
