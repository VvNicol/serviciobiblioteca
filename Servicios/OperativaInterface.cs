using GestionBilioteca.Dtos;

namespace GestionBilioteca.Servicios
{
    internal interface OperativaInterface
    {
        void AltaBiblioteca();
        void AltaCliente();
        void AltaLibro();
        void AltaPrestamos();
    }
}