using GestionBilioteca.Dtos;
using GestionBilioteca.Servicios;

namespace GestionBilioteca.Controlador
{
    internal class Program
    {
        public static List<BibliotecaDto> listaBibliotecas = new List<BibliotecaDto>();
        public static List<ClienteDtos> listaClientes = new List<ClienteDtos>();
        public static List<LibroDtos> listaLibro = new List<LibroDtos>();
        public static List<PrestamoDtos> listaPrestamo = new List<PrestamoDtos>();
        static void Main(string[] args)
        {
            MenuInterface mi = new MenuImplementacion();
            OperativaInterface oi = new OperativaImplementacion();

            int opcion;
            bool esCerrado = false;
            DateTime dateTime = DateTime.Now;
            string formato = $"{dateTime.ToString("dd-MM-yyyy")}";

            string bibliotecaFichero = $"{formato} Bliblioteca.txt";
            string clienteFichero = $"{formato} Bliblioteca.txt";
            string libroFichero = $"{formato} Bliblioteca.txt";
            string prestamoFichero = $"{formato} Bliblioteca.txt";
      

            try
            {
                //falta leer los ficheros y agregarlos

                do
                {
                    opcion = mi.MenuBiblioteca();
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Guardar cambios? (s/n)");
                            char sn = Convert.ToChar(Console.ReadLine().ToLower());
                            if(sn == 's')
                            {
                                using (StreamWriter bi = new StreamWriter(bibliotecaFichero, true))
                                {
                                    foreach(BibliotecaDto b in listaBibliotecas)
                                    {
                                        bi.WriteLine(b.ToString());
                                    }
                                }
                                using (StreamWriter cl = new StreamWriter(clienteFichero, true))
                                {
                                    foreach (ClienteDtos c in listaClientes)
                                    {
                                        cl.WriteLine(c.ToString());
                                    }
                                }
                                using (StreamWriter li = new StreamWriter(libroFichero, true))
                                {
                                    foreach (LibroDtos l in listaLibro)
                                    {
                                        li.WriteLine(l.ToString());
                                    }
                                }
                                using (StreamWriter pr = new StreamWriter(prestamoFichero, true))
                                {
                                    foreach (PrestamoDtos p in listaPrestamo)
                                    {
                                        pr.WriteLine(p.ToString());
                                    }
                                }

                                Console.WriteLine("Se ha guardado correctamente");
                            }
                            else
                            {
                                Console.WriteLine("No se guardaron los cambios");
                            }

                            esCerrado = true;
                            break;
                        case 1:
                            oi.AltaBiblioteca();
                            break;
                        case 2:
                            oi.AltaCliente();
                            break;
                        case 3:
                            oi.AltaLibro();
                            break;
                        case 4:
                            //falta la funcionalidad
                            oi.AltaPrestamos();
                            break;
                        default: Console.WriteLine("La opcion no existe");
                            break;

                    }

                } while (!esCerrado);
            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo leer/escribir: " + e.Message);
            }
        }
    }
}
