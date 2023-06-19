namespace Hospital
{
    public class Paciente : Persona
    {
        public Paciente(Persona p, string enfermedad
                      , string tratamiento) : base(p.Nombre, p.Edad, p.Sexo
                                                  , p.DocIdentidad, p.NumTelefono)
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
