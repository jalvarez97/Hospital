namespace Hospital
{
    public class Persona
    {
        public Persona() { }    
        public Persona(string nombre, int edad, string sexo, string docIdentidad, string email, int numTelefono, bool esMedico)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            DocIdentidad = docIdentidad;
            Email = email;
            NumTelefono = numTelefono;
            EsMedico = esMedico;
        }

        //propiedades
        public  string Nombre { get; set; }
        public int Edad { get; set; }
        public  string Sexo { get; set; }
        public string DocIdentidad { get; set; }
        public string Email { get; set; }
        public int NumTelefono { get; set; }

        public bool EsMedico { get; set; }

        //métodos
        public override string ToString()
        {
            return "Nombre: " + Nombre + " | Edad: " + Edad + " | Sexo: " + Sexo + " | DNI: " + DocIdentidad + " | Email: " + Email + " | Teléfono: " + NumTelefono;
        }
    }
}
