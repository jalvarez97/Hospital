using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Hospital
{
    public class Hospital
    {
        public List<Persona> Personas = new List<Persona>();

        public Hospital()
        {}    

        public void SeleccionaOpcion(int nOpcion)
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");

            switch (nOpcion)
            {
                case 1:
                    Console.WriteLine("1 - Ingresar un médico:\n");
                    InsertMedico();
                    break;
                case 2:
                    Console.WriteLine("2 - Ingresar un paciente:\n");
                    InsertPaciente();
                    break;
                case 3:
                    Console.WriteLine("3 - Ver médicos:\n");
                    MostrarMedicos("  ");                    
                    break;
                case 4:
                    Console.WriteLine("4 - Ver pacientes:\n");
                    MostrarPacientes();
                    break;
                case 5:
                    Console.WriteLine("5 - Eliminar paciente:\n");
                    DeletePaciente();
                    break;
                case 6:
                    Console.WriteLine("6 - Ver todas las personas del hospital:\n");
                    MostrarPersonas();
                    break;
                case 7:
                    Console.WriteLine("7 - Generar médicos y pacientes automáticos:\n");
                    GenerarMedicosPacientes();
                    break;                
            }
            Console.WriteLine("");
            Console.WriteLine("Pulsa cualquier tecla para continuar. . .");
            Console.ReadKey();
        }

        public Persona PedirCampos()
        {
            Persona oPersona = new Persona();

            Console.WriteLine("Introduzca un nombre: ");
            oPersona.Nombre = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca la edad: ");
            oPersona.Edad = InputValidarNumero(1, 120, "Edad inválida, valores esperados entre 1 y 120");

            Console.WriteLine("");
            Console.WriteLine("Introduzca el género: ");
            oPersona.Sexo = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el documento de identidad: ");
            oPersona.DocIdentidad = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el teléfono: ");
            oPersona.NumTelefono = InputValidarNumero(600000000, 999999999, "Número de teléfono inválido");

            return oPersona;
        }

        public void InsertMedico()
        {           
            Persona oPersona = PedirCampos();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el número de colegiado: ");
            int nNumColegiado = InputValidarNumero(1000,9999,
                                                   "Número de colegiado inválido, valores esperados entre 1000 o 9999");

            Console.WriteLine("");
            Console.WriteLine("Introduzca la especialidad: ");
            string sEspecialidad = Console.ReadLine();

            Medico oMedico = new Medico(oPersona, nNumColegiado, sEspecialidad);

            Personas.Add(oMedico);
        }        
        
        public void InsertPaciente() 
        {
            Persona oPersona = PedirCampos();

            Console.WriteLine("");
            Console.WriteLine("Introduzca la enfermedad: ");
            string sEnfermedad = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca el tratamiento: ");
            string sTratamiento = Console.ReadLine();

            Paciente oPaciente = new Paciente(oPersona, sEnfermedad, sTratamiento);
            
            Personas.Add(oPaciente);

            AsignaPacienteMedico(oPaciente);           
        }       

        public void AsignaPacienteMedico(Paciente oPaciente)
        {          
            Console.WriteLine("     Paciente ingresado correctamente.");
            Console.WriteLine("");
            Console.WriteLine("         " + oPaciente);
            Console.WriteLine("");
            Console.WriteLine("     Mostrando médicos para asignar: ");
            Console.WriteLine("");

            Medico oMedSelect = (Medico) SeleccionarPersona(true);

            oPaciente.MedicoAsignado = oMedSelect;
            oMedSelect.Pacientes.Add(oPaciente);            
        }      

        public void DeletePaciente()
        {
            Paciente oPaciente = (Paciente)SeleccionarPersona(false);                  
            
            Personas.Remove(oPaciente);
        }
        
        public void MostrarMedicos(string sMensaje)
        {
            int nContador = 1;

            foreach (Persona oPersona in Personas)
            {
                if(oPersona is Medico)
                {
                    Console.WriteLine(sMensaje + nContador + ". " + oPersona);
                    nContador++;
                }
            }
        }                   

        public void MostrarPacientes()
        {            
            int nContador = 1;

            foreach (Persona oPersona in Personas)
            {
                if(oPersona is Paciente)
                {
                    Console.WriteLine("  " + nContador + ". " + oPersona);
                    nContador++;
                }
            }  
        }

        public void MostrarPersonas()
        {          
            int nContador = 1;  

            foreach (Persona oPersona in Personas)
            {
                string sTipoPersona = "";

                if (oPersona is Medico)                
                    Console.ForegroundColor = ConsoleColor.Green;                    
                else                
                    Console.ForegroundColor = ConsoleColor.White;               
                
                Console.WriteLine(sTipoPersona + oPersona);
                nContador++;
            }

            Console.ForegroundColor = ConsoleColor.White;            
        }

        public void GenerarMedicosPacientes()
        {
            Automatizacion oAutomatiza = new Automatizacion();

            Console.WriteLine("    Introduzca la el número de medicos a generar.");
            Console.WriteLine("    A cada médico se le asignaran tantos pacientes como médicos haya.");

            int nNum = 0;
            while (nNum <= 0)
            {
                while (!int.TryParse(Console.ReadLine(), out nNum))
                    Console.WriteLine("Debes introducir un número.");

                if (nNum <= 0)
                    Console.WriteLine("Número de médicos a generar insuficiente, mínimo 1 médico.");
            }

            Personas = oAutomatiza.GenerarMedicosConPacientesRandom(nNum);
        }

        public int InputValidarNumero(int nMin, int nMax, string sMensajeError)
        {
            int nNumValidar = 0;
            while (nNumValidar <= nMin || nNumValidar > nMax)
            {
                while (!int.TryParse(Console.ReadLine(), out nNumValidar))
                    Console.WriteLine("Debes introducir un número.");

                if (nNumValidar <= nMin || nNumValidar > nMax)
                    Console.WriteLine(sMensajeError);
            }
            return nNumValidar;
        }       

        private Persona SeleccionarPersona(bool bMedico)
        {
            List<Persona> lstPersonas = new List<Persona>();
            Persona oPersona;

            if (bMedico)
            {
                foreach (Persona p in Personas)
                {
                    if (p is Medico)
                    {
                        lstPersonas.Add(p);
                    }
                }

                MostrarMedicos("         ");

                Console.WriteLine(" ");
                Console.WriteLine(" Introduzca un número del 1 al " + lstPersonas.Count + " para asignar médico. . .");

                int nInputUser = InputValidarNumero(0, lstPersonas.Count, "Numero de médico inválido.");

                oPersona = lstPersonas[nInputUser - 1];              
            }
            else
            {
                foreach (Persona p in Personas)
                {
                    if (p is Paciente)
                    {
                        lstPersonas.Add(p);
                    }
                }

                MostrarPacientes();

                Console.WriteLine(" ");
                Console.WriteLine(" Introduzca un número del 1 al " + lstPersonas.Count + " para borrar paciente. . .");

                int nInputUser = InputValidarNumero(0, lstPersonas.Count, "Numero de médico inválido.");

                oPersona = lstPersonas[nInputUser - 1];
            }
            
            return oPersona;
        }
    }
}
