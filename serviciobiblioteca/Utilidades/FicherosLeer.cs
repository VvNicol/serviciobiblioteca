using GestionBilioteca.Controlador;
using GestionBilioteca.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Utilidades
{

    internal class FicherosLeer
    {
        public static void cargarFicheros()
        {
            try
            {
                if (!File.Exists(Program.bibliotecaFichero))
                {
                    File.Create(Program.bibliotecaFichero).Dispose();
                }
                if (!File.Exists(Program.clienteFichero))
                {
                    File.Create(Program.clienteFichero).Dispose();
                }
                if (!File.Exists(Program.libroFichero))
                {
                    File.Create(Program.libroFichero).Dispose();
                }
                if (!File.Exists(Program.prestamoFichero))
                {
                    File.Create(Program.prestamoFichero).Dispose();
                }

                using (StreamReader sr = new StreamReader(Program.bibliotecaFichero))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(';');

                        long idBiblioteca = long.Parse(partes[0]);
                        string nombre = partes[1];
                        string direccion = partes[2];

                        BibliotecaDto bibliotecaAgregar = new BibliotecaDto(idBiblioteca, nombre, direccion);
                        Program.listaBibliotecas.Add(bibliotecaAgregar);
                    }
                }
                using (StreamReader sc = new StreamReader(Program.clienteFichero))
                {
                    Console.WriteLine(Program.listaClientes);
                    string linea;
                    while ((linea = sc.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(";");

                        ClienteDtos cli = new ClienteDtos(long.Parse(partes[0]), long.Parse(partes[1]), partes[2], partes[4], partes[5], DateTime.Parse(partes[7]), partes[10], partes[11]);
                        Program.listaClientes.Add(cli);


                        Console.WriteLine(cli.ToString());
                    }
                }
                using (StreamReader sl = new StreamReader(Program.libroFichero))
                {

                }
                using (StreamReader sp = new StreamReader(Program.prestamoFichero))
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los ficheros: " + ex.Message);
            }
        }
        public static void GuardarFicheros()
        {
            try
            {
                char sn = Convert.ToChar(Console.ReadLine().ToLower());
                if (sn == 's')
                {
                    using (StreamWriter bi = new StreamWriter(Program.bibliotecaFichero, true))
                    {
                        foreach (BibliotecaDto b in Program.listaBibliotecas)
                        {
                            bi.WriteLine(b.ToString("ficheroBiblioteca"));
                        }
                    }
                    using (StreamWriter cl = new StreamWriter(Program.clienteFichero, true))
                    {
                        foreach (ClienteDtos c in Program.listaClientes)
                        {
                            cl.WriteLine(c.ToString("clienteFichero"));
                        }
                    }
                    using (StreamWriter li = new StreamWriter(Program.libroFichero, true))
                    {
                        foreach (LibroDtos l in Program.listaLibro)
                        {
                            li.WriteLine(l.ToString());
                        }
                    }
                    using (StreamWriter pr = new StreamWriter(Program.prestamoFichero, true))
                    {
                        foreach (PrestamoDtos p in Program.listaPrestamo)
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

                

            } catch (Exception) { throw; }   
        }

       
    }
}
