using System;
using System.Collections.Generic;

namespace Hospital
{
    public class Hospital
    {
        public List<Persona> Personas = new List<Persona>();

        public Hospital()
        {}        

        public Persona PedirCamposPersona()
        {
            Persona oPersona = new Persona();

            Console.WriteLine("Introduzca un nombre: ");
            oPersona.Nombre = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Introduzca la edad: ");
            oPersona.Edad = InputValidarNumero(0, 120, "Edad inválida, valores esperados entre 1 y 120");

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
            Persona oPersona = PedirCamposPersona();

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
            Persona oPersona = PedirCamposPersona();

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
            Paciente oPaciente = (Paciente) SeleccionarPersona(false);                  
            
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
                
                Console.WriteLine(nContador + ". " + sTipoPersona + oPersona);
                nContador++;
            }

            Console.ForegroundColor = ConsoleColor.White;            
        }

        public void GenerarMedicosConPacientes()
        {
            Automatizacion oAutomatiza = new Automatizacion();

            Console.WriteLine("    Introduzca el número de medicos a generar.");
            Console.WriteLine("    A cada médico se le asignaran tantos pacientes como médicos haya.");

            int nNum = InputValidarNumero(0, 9999, "Número de médicos a generar insuficiente, mínimo 1 médico, máximo 9999.");
          
            Personas.AddRange(oAutomatiza.GenerarMedicosConPacientesRandom(nNum));            
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
            List<Persona> lstPersMedicos = new List<Persona>();
            List<Persona> lstPersPaciente = new List<Persona>();
            Persona oPersona;
            int nTotalPers;

            foreach (Persona p in Personas)
            {
                if (p is Medico)
                    lstPersMedicos.Add(p);
                else
                    lstPersPaciente.Add(p);
            }

            if (bMedico)
            {
                MostrarMedicos("         ");
                nTotalPers = lstPersMedicos.Count;
            }
            else
            {
                MostrarPacientes();
                nTotalPers = lstPersPaciente.Count;
            }                

            Console.WriteLine(" ");
            Console.WriteLine(" Introduzca un número del 1 al " + nTotalPers + " para asignar médico. . .");
            int nInputUser = InputValidarNumero(0, nTotalPers, "Numero de médico inválido.");

            if(bMedico)
                oPersona = lstPersMedicos[nInputUser - 1];
            else
                oPersona = lstPersPaciente[nInputUser - 1];            
            
            return oPersona;
        }
    }
}
