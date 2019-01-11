using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessX.Entities;

namespace BusinessX.WebApi.Models
{
    public class RepositoryMemoryData
    {
        private List<Libro> Libros = new List<Libro>();
        private List<Genero> Generos = new List<Genero>();

        private static int NextID;

        public RepositoryMemoryData()
        {
            Generos.Add(new Genero { IDG = 1, NombreGenero = "Genero 1" });
            Generos.Add(new Genero { IDG = 2, NombreGenero = "Genero 2" });
            Generos.Add(new Genero { IDG = 3, NombreGenero = "Genero 3" });
            Generos.Add(new Genero { IDG = 4, NombreGenero = "Genero 4" });
            Generos.Add(new Genero { IDG = 5, NombreGenero = "Genero 5" });
            Libros.Add(new Libro {
                IDL = 1,
                NombreL = "Libro 1",
                AutorL = "Autor 1",
                Editorial = "Editorial 1",
                ISBN = "ISBN 1",
                IDGeneroL = 5,
                PrecioL =45,
                RutaImgL = "https://marketplace.canva.com/MACXC0twKgo/1/0/thumbnail_large/canva-green-and-pink-science-fiction-book-cover-MACXC0twKgo.jpg"
            });
            Libros.Add(new Libro { IDL = 2,
                NombreL = "Libro 2",
                AutorL = "Autor 2",
                Editorial = "Editorial 2",
                ISBN = "ISBN 2",
                IDGeneroL = 3,
                PrecioL = 50,
                RutaImgL = "https://marketplace.canva.com/MACXC0twKgo/1/0/thumbnail_large/canva-green-and-pink-science-fiction-book-cover-MACXC0twKgo.jpg"
            });
            Libros.Add(new Libro { IDL = 2,
                NombreL = "Libro 3",
                AutorL = "Autor 3",
                Editorial = "Editorial 3",
                ISBN = "ISBN 3",
                IDGeneroL = 5,
                PrecioL = 30,
                RutaImgL = "https://marketplace.canva.com/MACXC0twKgo/1/0/thumbnail_large/canva-green-and-pink-science-fiction-book-cover-MACXC0twKgo.jpg"
            });
        }
        public List<Libro> ObtenerTodoLibro()
        {
            return Libros;
        }

        public Libro ObtenerLibro(int id)
        {

            return Libros.Find(p => p.IDL == id);
        }

        public Libro CrearLibro(Libro nuevoLibro)
        {
            if (nuevoLibro == null)
            {
                throw new ArgumentException("Libro");
            }
            nuevoLibro.IDL = ++NextID;
            Libros.Add(nuevoLibro);
            return nuevoLibro;
        }

        public bool EliminarLibro(int id)
        {
            bool Resultado = false;
            var pr = Libros.RemoveAll(p => p.IDL == id);
            if (pr > 0)
            {
                Resultado = true;
            }
            return Resultado;
        }

        public bool ActualizarLibro(Libro LibroToUpdate)
        {
            if (LibroToUpdate == null)
            {
                throw new ArgumentException("Libro");
            }

            int index = Libros.FindIndex(p => p.IDL == LibroToUpdate.IDL);
            if (index == -1)
            {
                return false;
            }
            Libros.RemoveAt(index);
            Libros.Add(LibroToUpdate);
            return true;
        }
    }
}