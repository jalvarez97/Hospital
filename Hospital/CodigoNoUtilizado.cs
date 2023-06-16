using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital
{
    internal class CodigoNoUtilizado
    {
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

        public void GenerarMedicosConPacientesRandom(int generar, List<Medico> medicos)
        {
            Medico oMedico = new Medico();

            for (int i = 0; i < generar; i++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                int nDecididor = rnd.Next(0, 1000);

                if (nDecididor % 2 == 0)
                {
                    oMedico = new Medico(lstNombresMedicosHombre[nNombreMedico], rnd.Next(18, 45), "H", rnd.Next(23401238, 777777777) + "M"
                                        , lstNombresMedicosHombre[nNombreMedico] + "@gmail.com", rnd.Next(638723799, 722999999)
                                        , rnd.Next(1000, 2500), lstEspecialidades[rnd.Next(0, 3)]);

                    //Para cada medico generamos los mismos pacientes que medicos haya:                   
                    oMedico.Pacientes = GenerarPacientesRandom(generar);
                }
                else
                {
                    oMedico = new Medico(lstNombresMedicosMujer[nNombreMedico], rnd.Next(18, 45), "M", rnd.Next(23401238, 777777777) + "W"
                                        , lstNombresMedicosMujer[nNombreMedico] + "@gmail.com", rnd.Next(638723799, 722999999)
                                        , rnd.Next(2500, 4000), lstEspecialidades[rnd.Next(0, 3)]);


                    //Para cada medico generamos los mismos pacientes que medicos haya:                    
                    oMedico.Pacientes = GenerarPacientesRandom(generar);

                }

                medicos.Add(oMedico);
            }
        }

        public List<Paciente> GenerarPacientesRandom(int generar)
        {
            List<Paciente> lstPacientes = new List<Paciente>();
            Paciente oPaciente = new Paciente();

            for (int x = 0; x < generar; x++)
            {
                int nNombreMedico = rnd.Next(0, 14);
                int nDecididor = rnd.Next(0, 1000);

                if (nDecididor % 2 == 0)
                {
                    oPaciente = new Paciente(lstNombresMedicosHombre[nNombreMedico], rnd.Next(18, 45), "H", rnd.Next(23401238, 777777777) + "M"
                                        , lstNombresMedicosHombre[nNombreMedico] + "@gmail.com", rnd.Next(638723799, 722999999)
                                        , lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                }
                else
                {
                    oPaciente = new Paciente(lstNombresMedicosMujer[nNombreMedico], rnd.Next(18, 45), "M", rnd.Next(23401238, 777777777) + "W"
                                        , lstNombresMedicosMujer[nNombreMedico] + "@gmail.com", rnd.Next(638723799, 722999999)
                                        , lstEnfermedades[rnd.Next(0, 4)], "Ibuprofeno");
                }
                lstPacientes.Add(oPaciente);
            }
            return lstPacientes;
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
