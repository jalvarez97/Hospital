using System;
using System.Collections.Generic;

namespace Hospital
{
    internal class Automatizacion
    {
        //Datos para generar médicos sin rellenar personas automaticamente
        //e ingresar y asignar pacientes por cada médico de forma aleatoria

        private List<string> lstNombresMedicosHombre = new List<string>() { "Pascal","Jhonny", "Samu", "Javi"
                                                                       , "Alex", "Saul", "Wintop", "Manu"
                                                                       , "Oscar", "Joel", "Alejandro", "Alvaro"
                                                                       , "Pol", "Josepe", "Salva"};

        private List<string> lstNombresMedicosMujer = new List<string>()  { "Ana","Eva", "Sofia", "Jennifer"
                                                                    , "Melody", "Alexandra", "Sonia", "Sofia"
                                                                    , "Nayara", "Lucia", "Maria", "Susana"
                                                                    , "Laura", "Judith", "Raquel"};

        private List<string> lstEspecialidades = new List<string>() { "Oncologia", "Traumatologia", "Urgencias", "Cardiologia" };

        private List<string> lstEnfermedades = new List<string>() { "Resfriado", "Gastroenteritis", "Venezuelanitis", "Calvitis", "Cirrosis" };

        private Random rnd = new Random();

        public List<Persona> GenerarMedicosConPacientesRandom(int generar)
        {
            List<Persona> oPersonas = new List<Persona>();
            Persona oPersona;
            Medico oMedico;

            for (int i = 0; i < generar; i++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                int nDecididor = rnd.Next(0, 1000);

                if (nDecididor % 2 == 0)
                {
                    oPersona = new Persona(lstNombresMedicosHombre[nNombreMedico], rnd.Next(18, 45), "H"
                                          , rnd.Next(23401238, 777777777) + "M", rnd.Next(638723799, 722999999));

                    oMedico = new Medico(oPersona, rnd.Next(1000, 2500), lstEspecialidades[rnd.Next(0, 3)]);

                    //Para cada medico generamos los mismos pacientes que medicos haya:                   
                    oMedico.Pacientes = GenerarPacientesRandom(generar, oPersonas, oMedico);
                }
                else
                { 
                    oPersona = new Persona(lstNombresMedicosMujer[nNombreMedico], rnd.Next(18, 45), "M"
                                          , rnd.Next(23401238, 777777777) + "W", rnd.Next(638723799, 722999999));

                    oMedico = new Medico(oPersona, rnd.Next(2500, 4000), lstEspecialidades[rnd.Next(0, 3)]);

                    //Para cada medico generamos los mismos pacientes que medicos haya:                    
                    oMedico.Pacientes = GenerarPacientesRandom(generar, oPersonas, oMedico);
                }
                oPersonas.Add(oMedico);
            }
            
            return oPersonas;
        }          
        
        public List<Paciente> GenerarPacientesRandom(int generar, List<Persona> oPersonasPaciente, Medico oMedico)
        {
            List<Paciente> lstPacientes = new List<Paciente>();
            Persona oPersona;
            Paciente oPaciente;

            for (int x = 0; x < generar; x++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                int nDecididor = rnd.Next(0, 1000);

                if (nDecididor % 2 == 0)
                {
                    oPersona = new Persona(lstNombresMedicosHombre[nNombreMedico], rnd.Next(18, 45), "H"
                                          , rnd.Next(23401238, 777777777) + "M", rnd.Next(638723799, 722999999));

                    oPaciente = new Paciente(oPersona, lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                }
                else
                {
                    oPersona = new Persona(lstNombresMedicosMujer[nNombreMedico], rnd.Next(18, 45), "M"
                                          , rnd.Next(23401238, 777777777) + "W", rnd.Next(638723799, 722999999));

                    oPaciente = new Paciente(oPersona, lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                }
                oPaciente.MedicoAsignado = oMedico;
                lstPacientes.Add(oPaciente);
                oPersonasPaciente.Add(oPaciente);
            }

            return lstPacientes;
        }
        
    }
}
