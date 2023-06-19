namespace Hospital
{
    public class Paciente : Persona
    {
        public Paciente() { }
        public Paciente(Persona p, string enfermedad
                      , string tratamiento) : base(p.Nombre, p.Edad, p.Sexo
                                                                , p.DocIdentidad, p.NumTelefono, false)
        {
            Enfermedad = enfermedad;
            Tratamiento = tratamiento;
        }

        public Paciente(string nombre, int edad, string sexo, string docIdentidad
                       , int numeroTelefono, string enfermedad, string tratamiento) : base(nombre, edad, sexo, docIdentidad, numeroTelefono, false)
        {
            Enfermedad = enfermedad;
            Tratamiento = tratamiento;

        }

        //propiedades
        public string Enfermedad { get; set; }        
        public string Tratamiento { get; set; }
        public Medico MedicoAsignado { get; set; }
        
        //métodos
        public override string ToString()
        {
            if(MedicoAsignado != null)
            {
                return "Médico asignado: " + MedicoAsignado.Nombre + "(" + MedicoAsignado.NumColegiado + ")"
                  + " | " + base.ToString() + " | Enfermedad: " + Enfermedad + " | Tratamiento: " + Tratamiento;
            }
            return base.ToString() + " | Enfermedad: " + Enfermedad + " | Tratamiento: " + Tratamiento;
        }
    }
}
