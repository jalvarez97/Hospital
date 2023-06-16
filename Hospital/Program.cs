using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {      
        static void Main(string[] args)
        {            
            Console.SetWindowSize(210,50);            

            bool bUsando = true;
            bool bMostrandoMedicos = true;
            List<Medico> lstMedicos = new List<Medico>();
            Medico oMedico = new Medico();  

            while (bUsando) {
                MostrarMenu();

                int nOpcion = 0;
                while (nOpcion <= 0 || nOpcion > 6)
                {
                    while (!int.TryParse(Console.ReadLine(), out nOpcion))
                        Console.WriteLine("  Debes introducir un número.");

                    if (nOpcion < 0 || nOpcion > 6)
                        Console.WriteLine("  Opción inexistiente.");

                    if (nOpcion == 0)
                    {
                        bUsando = false;
                        nOpcion = 1;
                    }
                }

                switch (nOpcion)
                {
                    case 1:
                        break;
                    case 3:
                        bMostrandoMedicos = true;
                        oMedico.GenerarMedicosHombre(3, lstMedicos);
                        oMedico.GenerarMedicosMujer(3, lstMedicos);

                        while (bMostrandoMedicos)
                        {
                            oMedico.MostrarMedicos(lstMedicos);

                            Console.WriteLine(" ");
                            Console.WriteLine(" Introduzca un número del 1 al " + lstMedicos.Count() + " para consultar los pacientes del médico. . .");
                            Console.WriteLine(" Introduzca 0 para volver al menú. . .");

                            int nMedicoSeleccionado = 0;
                            while (nMedicoSeleccionado == 0 || nMedicoSeleccionado > lstMedicos.Count())
                            {
                                while (!int.TryParse(Console.ReadLine(), out nMedicoSeleccionado))
                                    Console.WriteLine("  Debes introducir un número.");

                                if (nMedicoSeleccionado > lstMedicos.Count())
                                    Console.WriteLine("  Numero de médico inválido.");

                                if (nMedicoSeleccionado == 0)
                                {                               
                                    nMedicoSeleccionado = 1;
                                    bMostrandoMedicos = false;
                                }
                            }

                            if (bMostrandoMedicos)
                            {
                                oMedico.MostrarPacientesMedico(lstMedicos, nMedicoSeleccionado);

                                Console.WriteLine(" ");
                                Console.WriteLine(" Pulsa cualquier tecla para volver a la lista de médicos. . .");
                                Console.WriteLine(" Pulsa ESC para volver al ménu. . .");

                                if (Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    bMostrandoMedicos = false;
                                }
                            }
                        }
                        break;
                }
            }
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" Menú: ");
            Console.WriteLine("     1 - Dar de alta un medico.");
            Console.WriteLine("     2 - Dar de alta un paciente, para un médico concreto.");
            Console.WriteLine("     3 - Ver médicos.");
            Console.WriteLine("     4 - Ver pacientes de un médico.");
            Console.WriteLine("     5 - Dar de alta paciente");
            Console.WriteLine("     6 - Ver todas las personas del hospital");
            Console.WriteLine("     0 - Salir");
        }
    }    

}
