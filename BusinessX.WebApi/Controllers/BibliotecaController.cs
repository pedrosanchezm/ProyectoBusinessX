using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessX.WebApi.Models;
using BusinessX.Entities;
using BusinessX.SLC;

namespace BusinessX.WebApi.Controllers
{
    public class BibliotecaController : ApiController, IService
    {
        static RepositoryMemoryData RMD = new RepositoryMemoryData();

        //POST api/biblioteca/CrearLibro
        [HttpPost]
        public Libro CrearLibro(Libro nuevoLibro)
        {
            var Libro = RMD.CrearLibro(nuevoLibro);
            return Libro;
        }

        //GET api/biblioteca/ObtenerLibroPorID/id
        [HttpGet]
        public Libro ObtenerLibroPorID(int ID)
        {
            return RMD.ObtenerLibro(ID);
        }

        //POST api/bibliocate/ActualizarLibro/id
        [HttpPost]
        public bool ActualizarLibro(int ID, Libro LibroToUpdate)
        {
            LibroToUpdate.IDL = ID;
            if (!RMD.ActualizarLibro(LibroToUpdate))
            {
                throw new HttpResponseException(
                    HttpStatusCode.NotFound);
            }
            return true;
        }

        //GET api/biblioteca/EliminarLibro?id={id}
        [HttpGet]
        public bool EliminarLibro(int ID)
        {
            var Resultado = RMD.EliminarLibro(ID);

            if (!Resultado)
            {
                Resultado = false;
                throw new HttpResponseException
                    (HttpStatusCode.NotFound);
            }
            return Resultado;
        }

        //GET api/biblioteca/FiltrarLibroPorIDGenero
        [HttpGet]
        public List<Libro> FiltrarLibroPorIDGenero(int ID)
        {
            return RMD.ObtenerTodoLibro().Where(p => p.IDGeneroL == ID).ToList();
        }

        //GET api/biblioteca/ObtenerTodoLibro
        [HttpGet]
        public List<Libro> ObtenerTodoLibro()
        {
            return RMD.ObtenerTodoLibro();
        }
    }
}
