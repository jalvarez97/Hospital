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
                oHospital.SeleccionaOpcion(nOpcion);

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
    }  
}
