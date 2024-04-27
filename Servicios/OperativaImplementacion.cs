using GestionBilioteca.Dtos;
using GestionBilioteca.Servicios;
using System.Net;

namespace GestionBilioteca.Controlador
{
    internal class OperativaImplementacion : OperativaInterface
    {
        public void AltaBiblioteca()
        {
            try { 
                long idBiblioteca = Utilidades.Utils.calcularId();
                Console.WriteLine("Ingrese el nombre de la biblioteca");
                string nombreBiblioteca = Console.ReadLine();
                Console.WriteLine("Ingrese direccion");
                string direccionBiblioteca = Console.ReadLine();

                BibliotecaDto biblioteca = new BibliotecaDto(idBiblioteca, nombreBiblioteca, direccionBiblioteca);
                Program.listaBibliotecas.Add(biblioteca);
            }catch(Exception) { throw; }
        }

        public void AltaCliente()
        {
            try { 
                Utilidades.Utils.mostrarBibliotecas();
                long idCliente = Utilidades.Utils.calcularIdCliente();
                Console.WriteLine("Ingrese id de la biblioteca para crear un usuario");
                long idBibliotecaRegistroCliente =  Convert.ToInt64(Console.ReadLine());
                bool bibliotecaEncontrada = false;

                foreach(BibliotecaDto buscarID in Program.listaBibliotecas)
                {
                    if (buscarID.Id.Equals(idBibliotecaRegistroCliente))
                    {
                        bibliotecaEncontrada = true;
                        Console.WriteLine("Ingrese nombre completo: ");
                        string nombreCompleCliente = Console.ReadLine();
                        Console.WriteLine("Ingrese fcha de nacimiento (yyyy/mm/dd)");
                         DateTime fchaNaciCliente = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Ingrese los numeros del DNI");
                        int dniClienteRegistro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la letra del DNI");
                        char letraCliente = Convert.ToChar(Console.ReadLine().ToUpper());
                        var dniCl = verificarDni(dniClienteRegistro, letraCliente);
                        bool dniDuplicado = verificarDuplicado(dniClienteRegistro);
                    
                        Console.WriteLine("Ingrese un correo");
                        string correoCliente = Console.ReadLine();

                        ClienteDtos cli = new ClienteDtos(idCliente, idBibliotecaRegistroCliente, 
                            nombreCompleCliente,fchaNaciCliente, dniClienteRegistro, letraCliente,correoCliente);
                        Program.listaClientes.Add(cli);

                        Console.WriteLine("Su usuario se ha creado con exito");

                        break;
                    }  
                }
                if (!bibliotecaEncontrada)
                {
                    Console.WriteLine("La biblioteca no existe");
                }
            }catch(Exception) { throw; }
        }

        private bool verificarDuplicado(int dniClienteRegistro)
        {
            try { 
                foreach (ClienteDtos cliente in Program.listaClientes)
                {
                    if (cliente.DniCompletoCliente.Equals(dniClienteRegistro))
                    {                   
                        Console.WriteLine("Se ha encontrado duplicados, vuelva a crear un cliente");
                        return true;
                    }
                }
                return false; 
            }catch(Exception) { throw; } 
        }

        public void AltaLibro()
        {
            try { 

                Utilidades.Utils.mostrarBibliotecas();
                long idLibro = Utilidades.Utils.calcularIdLibro();
                Console.WriteLine("Ingrese id de la biblioteca para crear un Libro");
                long idBibliotecaRegistroLibro = Convert.ToInt64(Console.ReadLine());
                bool bibliotecaEncontrada = false;
                foreach (BibliotecaDto biblioteca in Program.listaBibliotecas)
                {
                    if (biblioteca.Id.Equals(idBibliotecaRegistroLibro))
                    {
                        bibliotecaEncontrada = true;
                        Console.WriteLine("Ingrese el titulo de la obra: ");
                        string tituloLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el subtilo de la obra: ");
                        string subtituloLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el autor de la obra: ");
                        string autorLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el ISDN del libro: ");
                        int isbnLibro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el numero de edicion: ");
                        int numEdiciconLibro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre de la editorial: ");
                        string editorialLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de stock");
                        int numStock = Convert.ToInt32(Console.ReadLine());

                        LibroDtos stockLibros = new LibroDtos(idLibro,idBibliotecaRegistroLibro,tituloLibro,
                            subtituloLibro,autorLibro,isbnLibro,numEdiciconLibro,editorialLibro,numStock);
                        Program.listaLibro.Add(stockLibros);
                        Console.WriteLine("El libro se ha creado correctamente");
                        break;

                    }
                }
                if(!bibliotecaEncontrada)
                {
                    Console.WriteLine("La biblioteca no existe/encontrado");
                }

            }catch(Exception) { throw; }
        }

        private int verificarDni(int dniCliente, char letraCliente)
        {
            try { 
                int dniVerificar = -1;

                int[] resto = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
                char[] letras = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

                int divisor = 23;
                int operacion = dniCliente % divisor;

                int posicionResto = resto[operacion];

                if (letraCliente == letras[posicionResto])
                {
                
                    Console.WriteLine("DNI válido");
                    dniVerificar = dniCliente; // Asigna el DNI verificado a la variable de retorno
                }
                else
                {
                    Console.WriteLine("La letra ingresada no coincide con la letra calculada.");
                }
                return dniVerificar;
            }
            catch (Exception) { throw; }
        }

        public void AltaPrestamos()
        {
            try
            {

            }catch (Exception) { throw; }
        }
    }

}