using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessX.ViewModel
{
    public class Principal : ViewModelBase
    {
        public Principal()
        {
            InicialViewModel();
        }
        public void InicialViewModel()
        {
            Libros = new List<Entities.Libro>();
            BuscarLibroCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var Proxy = new ProxyService.Proxy();
                    Libros = Proxy.FiltrarLibroPorIDGenero(IDGeneroL);
                });
            BuscarLibroPorIDCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    if (LibroSelected.IDL != 0)
                    {
                        var Proxy = new ProxyService.Proxy();
                        var p = Proxy.ObtenerLibroPorID(LibroSelected.IDL);
                        IDL = p.IDL;
                        NombreL = p.NombreL;
                        AutorL = p.AutorL;
                        Editorial = p.Editorial;
                        ISBN = p.ISBN;
                        IDGeneroL = p.IDGeneroL;
                    }
                });
            CrearLibroCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var nuevoLibro = new Entities.Libro
                    {
                        IDL = IDL,
                        NombreL = NombreL,
                        AutorL = AutorL,
                        Editorial = Editorial,
                        ISBN = ISBN,
                        IDGeneroL = IDGeneroL

                    };
                    var Proxy = new ProxyService.Proxy();
                    nuevoLibro = Proxy.CrearLibro(nuevoLibro);
                    IDL = nuevoLibro.IDL;
                    if (IDL!=0)
                    {
                        //Application.Current.MainPage.DisplayAlert("Mensaje", "Creado Correctamente", "Ok");
                    }
                }
            );

            ActualizarLibroCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var nuevoLibro = new Entities.Libro
                    {
                        NombreL = NombreL,
                        AutorL = AutorL,
                        Editorial = Editorial,
                        ISBN = ISBN,
                        IDGeneroL = IDGeneroL
                    };
                    var Proxy = new ProxyService.Proxy();
                    var Respuesta = Proxy.ActualizarLibro(IDL, nuevoLibro);
                    if (Respuesta)
                    {
                        //Application.Current.MainPage.DisplayAlert("Mensaje", "Actualizado Correctamente", "Ok");
                    }
                });
            EliminarLibroCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var Proxy = new ProxyService.Proxy();
                    var Respuesta = Proxy.EliminarLibro(IDL);
                    if (Respuesta)
                    {
                        IDL = 0;
                        NombreL = "";
                        AutorL = "";
                        Editorial = "";
                        ISBN = "";
                        IDGeneroL = 0;
                        
                        //Application.Current.MainPage.DisplayAlert("Mensaje", "Eliminado Correctamente", "Ok");
                        
                    }

                });
        }
        #region Properties
        private List<Entities.Libro> Libros_BF;
        public List<Entities.Libro> Libros
        {
            get { return Libros_BF; }
            set
            {
                Libros_BF = value;
                OnPropertyChanged();
            }
        }

        private Entities.Libro LibroSelected_BF;
        public Entities.Libro LibroSelected
        {
            get { return LibroSelected_BF; }
            set
            {
                LibroSelected_BF = value;
                OnPropertyChanged();
            }
        }

        private int IDL_BF;
        public int IDL {
            get { return IDL_BF; }
            set
            {
                IDL_BF = value;
                OnPropertyChanged();
            }
        }

        private string NombreL_BF;
        public string NombreL
        {
            get { return NombreL_BF; }
            set
            {
                NombreL_BF = value;
                OnPropertyChanged();
            }
        }

        private string AutorL_BF;
        public string AutorL
        {
            get { return AutorL_BF; }
            set
            {
                AutorL_BF = value;
                OnPropertyChanged();
            }
        }

        private string Editorial_BF;
        public string Editorial
        {
            get { return Editorial_BF; }
            set
            {
                Editorial_BF = value;
                OnPropertyChanged();
            }
        }

        private string ISBN_BF;
        public string ISBN
        {
            get { return ISBN_BF; }
            set
            {
                ISBN_BF = value;
                OnPropertyChanged();
            }
        }

        private double PrecioL_BF;
        public double PrecioL
        {
            get { return PrecioL_BF; }
            set
            {
                PrecioL_BF = value;
                OnPropertyChanged();
            }
        }

        private string RutaImgL_BF;
        public string RutaImgL
        {
            get { return RutaImgL_BF; }
            set
            {
                RutaImgL_BF = value;
                OnPropertyChanged();
            }
        }

        private int IDGeneroL_BF;
        public int IDGeneroL
        {
            get { return IDGeneroL_BF; }
            set
            {
                IDGeneroL_BF = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CommandDelegate BuscarLibroCommand { get; set; }
        public CommandDelegate BuscarLibroPorIDCommand { get; set; }
        public CommandDelegate CrearLibroCommand { get; set; }
        public CommandDelegate ActualizarLibroCommand { get; set; }
        public CommandDelegate EliminarLibroCommand { get; set; }
    }
}
