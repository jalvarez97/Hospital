using System;

namespace Hospital
{
    internal class Program
    {      
        static void Main(string[] args)
        {            
            Console.SetWindowSize(210,50);            

            bool bUsando = true;

            Hospital oHospital = new Hospital();
            Automatizacion oAutomatiza = new Automatizacion();

            oHospital.Personas = oAutomatiza.GenerarMedicosConPacientesRandom(3);

            while (bUsando) 
            {
                MostrarMenu();

                int nOpcion = 0;
                while (nOpcion <= 0 || nOpcion > 7)
                {
                    while (!int.TryParse(Console.ReadLine(), out nOpcion))
                        Console.WriteLine("  Debes introducir un número.");

                    if (nOpcion <= 0 || nOpcion > 7)
                        Console.WriteLine("  Opción inexistente.");                    
                }

                switch (nOpcion)
                {
                    case 1:
                        oHospital.IngresarMedico();
                        break;
                    case 2:
                        oHospital.IngresarPaciente();
                        break;
                    case 3:
                        oHospital.MostrarMedicos(true);
                        Console.ReadKey();
                        break;
                    case 4:
                        oHospital.MostrarPaciente();
                        Console.ReadKey();
                        break;
                    case 5:
                        oHospital.DarAltaPaciente();
                        break;
                    case 6:
                        oHospital.MostrarPersonas();
                        Console.ReadKey();
                        break;
                    case 7:
                        bUsando = false;
                        break;
                }
               
            }
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" Menú: ");
            Console.WriteLine("     1 - Dar de alta un médico.");
            Console.WriteLine("     2 - Ingresar un paciente, para un médico concreto.");
            Console.WriteLine("     3 - Ver médicos.");
            Console.WriteLine("     4 - Ver pacientes.");
            Console.WriteLine("     5 - Dar de alta paciente.");
            Console.WriteLine("     6 - Ver todas las personas del hospital.");
            Console.WriteLine("     7 - Salir.");
        }
    }    

}
