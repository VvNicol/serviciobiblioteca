using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Dtos
{
    internal class PrestamoDtos
    {
        int idPrestamo =  11111;
        int idCliente = 11111;
        int idLibro = 111111;
        DateTime fchaPrestamo = DateTime.Today;
        DateTime fchaEntrega;
        string estadoPrestamo = "aaaaa";
        override
        public string ToString()
        {
            string formato = $"id prestamo: {idPrestamo}; id cliente: {idCliente}; id libro: {idLibro}; fecha prestamo: {fchaEntrega}; fecha entrega: {fchaEntrega}; estado libro: {estadoPrestamo}";
            return formato ;
        }

        public PrestamoDtos()
        {
        }

        public PrestamoDtos(int idPrestamo, int idCliente, int idLibro, DateTime fchaPrestamo, DateTime fchaEntrega, string estadoPrestamo)
        {
            this.idPrestamo = idPrestamo;
            this.idCliente = idCliente;
            this.idLibro = idLibro;
            this.fchaPrestamo = fchaPrestamo;
            this.fchaEntrega = fchaEntrega;
            this.estadoPrestamo = estadoPrestamo;
        }

        public int IdPrestamo { get => idPrestamo; set => idPrestamo = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdLibro { get => idLibro; set => idLibro = value; }
        public DateTime FchaPrestamo { get => fchaPrestamo; set => fchaPrestamo = value; }
        public DateTime FchaEntrega { get => fchaEntrega; set => fchaEntrega = value; }
        public string EstadoPrestamo { get => estadoPrestamo; set => estadoPrestamo = value; }
    }
}
