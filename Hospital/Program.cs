using System;

namespace Hospital
{
    internal class Program
    {
        static Hospital oHospital = new Hospital();

        static void Main(string[] args)
        {  
            while (Menu())
            {}
        }

        public static bool Menu()
        {
            MostrarMenu();

            int nOpcion = oHospital.InputValidarNumero(0, 8, "Opción inexistente");

            if (nOpcion == 8)
                return false;
            else
                SeleccionaOpcion(nOpcion);

            return true;
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");
            Console.WriteLine(" Menú: ");
            Console.WriteLine("     1 - Ingresar un médico.");
            Console.WriteLine("     2 - Ingresar un paciente");
            Console.WriteLine("     3 - Ver médicos.");
            Console.WriteLine("     4 - Ver pacientes.");
            Console.WriteLine("     5 - Eliminar paciente.");
            Console.WriteLine("     6 - Ver todas las personas del hospital.");
            Console.WriteLine("     7 - Generar médicos y pacientes automáticamente.");
            Console.WriteLine("     8 - Salir.");
        }

        public static void SeleccionaOpcion(int nOpcion)
        {
            Console.Clear();
            Console.WriteLine("Hospital APP");

            switch (nOpcion)
            {
                case 1:
                    Console.WriteLine("1 - Ingresar un médico:\n");
                    oHospital.InsertMedico();
                    break;
                case 2:
                    Console.WriteLine("2 - Ingresar un paciente:\n");
                    oHospital.InsertPaciente();
                    break;
                case 3:
                    Console.WriteLine("3 - Ver médicos:\n");
                    oHospital.MostrarMedicos("  ");
                    break;
                case 4:
                    Console.WriteLine("4 - Ver pacientes:\n");
                    oHospital.MostrarPacientes();
                    break;
                case 5:
                    Console.WriteLine("5 - Eliminar paciente:\n");
                    oHospital.DeletePaciente();
                    break;
                case 6:
                    Console.WriteLine("6 - Ver todas las personas del hospital:\n");
                    oHospital.MostrarPersonas();
                    break;
                case 7:
                    Console.WriteLine("7 - Generar médicos y pacientes automáticos:\n");
                    oHospital.GenerarMedicosConPacientes();
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("Pulsa cualquier tecla para continuar. . .");
            Console.ReadKey();
        }
    }  
}
