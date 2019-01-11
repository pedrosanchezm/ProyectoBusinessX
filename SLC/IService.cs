using System;
using System.Collections.Generic;
using System.Text;
using BusinessX.Entities;

namespace BusinessX.SLC
{
    public interface IService
    {
        Libro CrearLibro(Libro nuevoLibro);
        Libro ObtenerLibroPorID(int ID);
        bool ActualizarLibro(int ID, Libro LibroToUpdate);
        bool EliminarLibro(int ID);
        List<Libro> FiltrarLibroPorIDGenero(int ID);
        List<Libro> ObtenerTodoLibro();
    }
}
