
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Hospital
{
    public class Medico : Persona
    {
        
        int NumColegiado { get; set; }
      
        string Especialidad { get; set; }
      
       

        List<string> lstEspecialidades = new List<string>() { "Oncologia", "Traumatologia", "Urgencias", "Cardiologia" };
        List<string> lstEnfermedades = new List<string>() { "Resfriado", "Gastroenteritis", "Venezuelanitis", "Calvitis", "Cirrosis" };
        Random rnd = new Random();

        public List<Paciente> Pacientes = new List<Paciente>();
        public Medico () { }

        public Medico(string nombre, int numColegiado, int edad
                    , string especialidad, string sexo, string docIdentidad
                    , string email, int numTelefono)
        {
            Nombre = nombre;
            NumColegiado = numColegiado;
            Edad = edad;
            Especialidad = especialidad;
            Sexo = sexo;
            DocIdentidad = docIdentidad;
            Email = email;
            NumTelefono = numTelefono;
        }

        public override string ToString()
        {
            return "Nombre: " + Nombre + " | Número colegiado: " + NumColegiado + " | Edad: " + Edad 
                   + " | Especialidad: " + Especialidad + " | Genero: " + Sexo + " | DNI: " + DocIdentidad 
                   + " | Email: " + Email + " | Telefono: " + NumTelefono; 
        }

        public void GenerarMedicosHombre(int generar, List<Medico> medicos)
        {
            List<string> lstNombresMedicosHombre = new List<string>() { "Pascal","Jhonny", "Samu", "Javi"
                                                                       , "Alex", "Saul", "Wintop", "Manu"
                                                                       , "Oscar", "Joel", "Alejandro", "Alvaro"
                                                                       , "Pol", "Josepe", "Salva"};            

            for (int i = 0; i < generar; i++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                Medico oMedico = new Medico(lstNombresMedicosHombre[nNombreMedico], rnd.Next(1000, 2500), rnd.Next(18, 45)
                                        , lstEspecialidades[rnd.Next(0, 3)], "H", rnd.Next(23401238, 777777777) + "W"
                                        , lstNombresMedicosHombre[nNombreMedico] + "@gmail.com", rnd.Next(638723799, 722999999));
                //Para cada medico generamos los mismos pacientes que medicos haya:
                for (int x = 0; x < generar; x++)
                {
                    Paciente oPaciente = new Paciente(rnd.Next(1000,2000), rnd.Next(30, 45), lstEnfermedades[rnd.Next(0,4)], "Ibuprofeno");
                    oMedico.Pacientes.Add(oPaciente);
                }                    

                medicos.Add(oMedico);
            }
        }

        public void GenerarMedicosMujer(int generar, List<Medico> medicos)
        {
            List<string> lstNombresMedicosMujer = new List<string>()  { "Ana","Eva", "Sofia", "Jennifer"
                                                                    , "Melody", "Alexandra", "Sonia", "Sofia"
                                                                    , "Nayara", "Lucia", "Maria", "Susana"
                                                                    , "Laura", "Judith", "Raquel"};
            for (int i = 0; i < generar; i++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                Medico oMedico = new Medico(lstNombresMedicosMujer[nNombreMedico], rnd.Next(1000, 2500), rnd.Next(18, 45)
                                        , lstEspecialidades[rnd.Next(0, 3)], "M", rnd.Next(23401238, 777777777) + "A"
                                        , lstNombresMedicosMujer[nNombreMedico] + "@gmail.com", rnd.Next(638723799, 722999999));
                //Para cada medico generamos los mismos pacientes que medicos haya:
                for (int x = 0; x < generar; x++)
                {
                    Paciente oPaciente = new Paciente(rnd.Next(1000, 2000), rnd.Next(30, 45), lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                    oMedico.Pacientes.Add(oPaciente);
                }

                medicos.Add(oMedico);
            }
        }
        
        public void MostrarMedicos(List<Medico> lstMedicos)
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" Médicos generados");

            //Mostramos medicos
            for (int i = 0; i < lstMedicos.Count; i++)
            {
                Thread.Sleep(125);
                Console.WriteLine("  " + (i + 1) + ". " + lstMedicos[i]);
                Thread.Sleep(125);
            }            
        }

        public void MostrarPacientesMedico(List<Medico> lstMedicos, int nMedicoSeleccionado)
        {            
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" Médico seleccionado: ");
            Console.WriteLine("  " + nMedicoSeleccionado + ". " + lstMedicos[nMedicoSeleccionado - 1]);
            Console.WriteLine("  " + "   Lista de pacientes: ");

            int nContador = 1;
            foreach (Paciente oPaciente in lstMedicos[nMedicoSeleccionado - 1].Pacientes)
            {

                Thread.Sleep(125);
                Console.WriteLine("  " + "    " + (nContador) + ". " + oPaciente);
                Thread.Sleep(125);
                nContador++;
            }
        }
    }
}
