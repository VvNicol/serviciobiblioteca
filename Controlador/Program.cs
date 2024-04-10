using GestionBilioteca.Dtos;
using GestionBilioteca.Servicios;

namespace GestionBilioteca.Controlador
{
    internal class Program
    {


        static List<BibliotecaDto> listaBibliotecas = new List<BibliotecaDto>();
        static List<ClienteDtos> listaClientes = new List<ClienteDtos>();
        static List<LibroDtos> listaLibro = new List<LibroDtos>();
        static List<PrestamoDtos> listaPrestamo = new List<PrestamoDtos>();
        static void Main(string[] args)
        {
            MenuInterface mi = new MenuImplementacion();
            OperativaInterface oi = new OperativaImplementacion();

            int opcion;
            bool esCerrado = false;

            try
            {
                do
                {
                    opcion = mi.MenuBiblioteca();
                    switch (opcion)
                    {
                        case 0:
                            esCerrado = true;
                            break;
                        case 1:
                            oi.AltaBiblioteca(listaBibliotecas);
                            break;
                        case 2:
                            oi.AltaCliente(listaClientes, listaBibliotecas);
                            break;
                        case 3:
                            oi.AltaLibro(listaLibro, listaBibliotecas);
                            break;
                        case 4:
                            //oi.AltaPrestamos();
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
