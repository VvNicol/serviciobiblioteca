using GestionBilioteca.Controlador;
using GestionBilioteca.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Utilidades
{
    internal class Utils
    {
        public static long calcularId()
        {
            try
            {
                long idCalcular;
                int tamanioLista = Program.listaBibliotecas.Count();

                if (tamanioLista > 0)
                {
                    idCalcular = Program.listaBibliotecas.Count() + 1;
                }else
                {
                    idCalcular = 1;
                }
                return idCalcular;
            } catch (Exception ) { throw; }
        }

        public static long calcularIdCliente()
        {
            try { 
                long idCalcular;
                int tamanioLista = Program.listaClientes.Count();

                if (tamanioLista > 0)
                {
                    idCalcular = Program.listaClientes.Count() + 1;
                }
                else
                {
                    idCalcular = 1;
                }
                return idCalcular;
            }  catch (Exception ) { throw; }
        }
        public static long calcularIdLibro()
        {
            try
            {
                long idCalcular;
                int tamanioLista = Program.listaLibro.Count();

                if (tamanioLista > 0)
                {
                    idCalcular = Program.listaLibro.Count() + 1;
                }
                else
                {
                    idCalcular = 1;
                }
                return idCalcular;

            }catch (Exception ) { throw; }
        }

        public static void mostrarBibliotecas()
        {
            try { 
                Console.WriteLine("Bibliotecas: ");
                Console.WriteLine("------------");

                foreach (BibliotecaDto bibli in Program.listaBibliotecas)
                {
                    Console.WriteLine(bibli.ToString());
                }
            } catch(Exception ) { throw; }
        }

        public static void mostrarClientes()
        {
            try { 
                Console.WriteLine("Clientes: ");
                Console.WriteLine("------------");

                foreach (ClienteDtos cliente in Program.listaClientes)
                {
                    Console.WriteLine(cliente.ToString());
                }
            } catch(Exception ) { throw; }
        }

    }
}
