using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Hospital
{
    public class Hospital
    {
        public List<Persona> Personas = new List<Persona>();
        private Random rnd = new Random();

        public Hospital() { }

        public void IngresarMedico()
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" 1 - Dar de alta un médico:");
            
            Console.WriteLine("");
            Console.WriteLine("Introduzca un nombre: ");

            string sNombre = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca la edad: ");
            
            int nEdad = 0;
            while (nEdad == 0 || nEdad < 20)
            {
                while (!int.TryParse(Console.ReadLine(), out nEdad))
                    Console.WriteLine("  Debes introducir un número.");

                if (nEdad == 0 || nEdad < 20)
                    Console.WriteLine("Edad insuficiente, minimo 20 años");                
            }

            Console.WriteLine("");
            Console.WriteLine("Introduzca el género: ");

            string sGenero = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el documento de identidad: ");

            string sDocIdentidad = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el teléfono: ");

            int nTelefono = 0;
            while (nTelefono == 0 || nTelefono < 600000000)
            {
                while (!int.TryParse(Console.ReadLine(), out nTelefono))
                    Console.WriteLine("Debes introducir un número.");

                if (nTelefono == 0 || nTelefono < 600000000)
                    Console.WriteLine("Número no válido");
            }

            Console.WriteLine("");
            Console.WriteLine("Introduzca la especialidad: ");

            string sEspecialidad = Console.ReadLine();            

            Medico oMedico = new Medico(sNombre, nEdad, sGenero, sDocIdentidad
                                      , sNombre + "@gmail.com", nTelefono
                                      , rnd.Next(1000, 2500), sEspecialidad);
            Personas.Add(oMedico);

            Console.WriteLine(" Pulsa cualquier tecla para continuar. . .");
        }     

        public void IngresarPaciente() 
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" 2 - Dar de alta un paciente:");

            Console.WriteLine("");
            Console.WriteLine("Introduzca un nombre: ");

            string sNombre = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca la edad: ");

            int nEdad = 0;
            while (nEdad <= 0)
            {
                while (!int.TryParse(Console.ReadLine(), out nEdad))
                    Console.WriteLine("Debes introducir un número.");

                if (nEdad <= 0 )
                    Console.WriteLine("Edad Minima 1");
            }

            Console.WriteLine("");
            Console.WriteLine("Introduzca el género: ");

            string sGenero = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el documento de identidad: ");

            string sDocIdentidad = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el teléfono: ");

            int nTelefono = 0;
            while (nTelefono == 0 || nTelefono < 600000000)
            {
                while (!int.TryParse(Console.ReadLine(), out nTelefono))
                    Console.WriteLine("Debes introducir un número.");

                if (nTelefono == 0 || nTelefono < 600000000)
                    Console.WriteLine("Número no válido");
            }

            Console.WriteLine("");
            Console.WriteLine("Introduzca la enfermedad: ");

            string sEnfermedad = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el tratamiento: ");

            string sTratamiento = Console.ReadLine();

            Paciente oPaciente = new Paciente(sNombre, nEdad, sGenero, sDocIdentidad
                                      , sNombre + "@gmail.com", nTelefono
                                      , sEnfermedad, sTratamiento);
            
            Personas.Add(oPaciente);

            AsignarPacienteMedico(oPaciente);           
        }

        public void AsignarPacienteMedico(Paciente oPaciente)
        {
            List<Medico> lstMedicos = ObtenerMedicos();

            //AsignamosPaciente
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" 2 - Ingresar un paciente:");
            Console.WriteLine("     Paciente ingresado correctamente.");
            Console.WriteLine("");
            Console.WriteLine("         " + oPaciente);
            Console.WriteLine("");
            Console.WriteLine("     Mostrando médicos para asignar: ");
            Console.WriteLine("");

            MostrarMedicos(false);

            Console.WriteLine(" ");
            Console.WriteLine(" Introduzca un número del 1 al " + lstMedicos.Count + " para asignar médico. . .");

            int nMedicoSeleccionado = 0;
            while (nMedicoSeleccionado == 0 || nMedicoSeleccionado > lstMedicos.Count())
            {
                while (!int.TryParse(Console.ReadLine(), out nMedicoSeleccionado))
                    Console.WriteLine("  Debes introducir un número.");

                if (nMedicoSeleccionado > lstMedicos.Count())
                    Console.WriteLine("  Numero de médico inválido.");                
            }

            lstMedicos[nMedicoSeleccionado - 1].Pacientes.Add(oPaciente);

            //Recorremos personas para reemplazar el medico, por el medico con el paciente ya asignado
            for (int i = 0; i < Personas.Count; i++)
            {
                if (Personas[i] == lstMedicos[nMedicoSeleccionado - 1])
                {
                    Personas[i] = lstMedicos[nMedicoSeleccionado - 1];
                }
            }

            Console.WriteLine(" Pulsa cualquier tecla para continuar. . .");
        }      

        public void DarAltaPaciente()
        {
            List <Paciente> lstPacientes = ObtenerPacientes();

            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" 5 - Dar Alta:");

            for (int i = 0; i < lstPacientes.Count; i++)
            {                
                Thread.Sleep(125);
                Console.WriteLine("  " + (i + 1) + ". " + lstPacientes[i]);
                Thread.Sleep(125);                
            }

            Console.WriteLine(" ");
            Console.WriteLine(" Introduzca un número del 1 al " + lstPacientes.Count + " para asignar médico. . .");

            int nPacienteSeleccionado = 0;
            while (nPacienteSeleccionado == 0 || nPacienteSeleccionado > lstPacientes.Count())
            {
                while (!int.TryParse(Console.ReadLine(), out nPacienteSeleccionado))
                    Console.WriteLine("  Debes introducir un número.");

                if (nPacienteSeleccionado > lstPacientes.Count())
                    Console.WriteLine("  Numero de médico inválido.");               
            }

            for (int i = 0; i < Personas.Count; i++)
            {
                if (Personas[i].DocIdentidad == lstPacientes[nPacienteSeleccionado - 1].DocIdentidad
                    && Personas[i].Nombre == lstPacientes[nPacienteSeleccionado - 1].Nombre)
                {
                    Personas.Remove(Personas[i]);
                }
            }

            Console.WriteLine(" Paciente dado de alta correctamente.");
            Console.WriteLine(" Pulsa cualquier tecla para continuar. . .");
        }

        private List<Medico> ObtenerMedicos()
        {
            List<Medico> oMedicos = new List<Medico>();

            foreach (Persona oPersona in Personas)
            {
                if (oPersona.EsMedico)
                    oMedicos.Add((Medico)oPersona);
            }

            return oMedicos;
        }

        private List<Paciente> ObtenerPacientes()
        {
            List<Paciente> oPacientes = new List<Paciente>();

            foreach (Persona oPersona in Personas)
            {
                if (!oPersona.EsMedico)
                    oPacientes.Add((Paciente)oPersona);
            }

            return oPacientes;
        }

        public void MostrarMedicos(bool vieneMenu)
        {
            int nContador = 0;
            //Si viene de la opcion del menu se muestra diferente
            if (vieneMenu)
            {                
                Console.Clear();
                Console.WriteLine("Hospital APP");
                Console.WriteLine(" 3 - Ver médicos:");

                for (int i = 0; i < Personas.Count; i++)
                {
                    if (Personas[i].EsMedico)
                    {
                        Thread.Sleep(125);
                        Console.WriteLine("  " + (nContador + 1) + ". " + Personas[i]);
                        Thread.Sleep(125);
                        nContador++;
                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(" Pulsa cualquier tecla para continuar. . .");
            }
            //Viene del menu AsignarPaciente a Médico
            else
            {
                for (int i = 0; i < Personas.Count; i++)
                {
                    if (Personas[i].EsMedico)
                    {
                        Thread.Sleep(125);
                        Console.WriteLine("         " + (nContador + 1) + ". " + Personas[i]);
                        Thread.Sleep(125);
                        nContador++;
                    }
                }
            }            
        }

        public void MostrarPaciente()
        {            
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" 4 - Ver todos los pacientes");

            //Si viene de la opcion del menu se muestra diferente
            List<Medico> lstMedicos = ObtenerMedicos();
            string sMedicoAsignado = "";
            int nContador = 0;

            for (int oNumPersona = 0; oNumPersona < Personas.Count; oNumPersona++)
            {
                if (!Personas[oNumPersona].EsMedico)
                {
                    for (int oNumMedico = 0; oNumMedico < lstMedicos.Count; oNumMedico++)
                    {
                        for (int oNumPaciente = 0; oNumPaciente < lstMedicos[oNumMedico].Pacientes.Count; oNumPaciente++)
                        {
                            if (lstMedicos[oNumMedico].Pacientes[oNumPaciente].Nombre == Personas[oNumPersona].Nombre)
                            {
                                sMedicoAsignado = lstMedicos[oNumMedico].Nombre;
                            };
                        }
                    }

                    Thread.Sleep(125);
                    Console.Write("  " + (nContador + 1) + ". " + Personas[oNumPersona] + " | ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Médico Asignado: " + sMedicoAsignado);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Thread.Sleep(125);
                    nContador++;
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine(" Pulsa cualquier tecla para continuar. . .");
        }

        public void MostrarPersonas()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" 6 - Ver todas las personas del hospital.");

            int nContador = 1;  

            foreach (Persona oPersona in Personas)
            {
                string sTipoPersona = "";

                if (oPersona.EsMedico)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    sTipoPersona = "   " + nContador + ". " + "Médico | ";
                }     
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    sTipoPersona = "   " + nContador + ". " + "Paciente | ";
                }
                
                Thread.Sleep(125);
                Console.WriteLine(sTipoPersona + oPersona);
                Thread.Sleep(125);
                nContador++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine(" Pulsa cualquier tecla para continuar. . .");
        }
              
    }
}
