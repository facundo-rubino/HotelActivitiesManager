using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Sistema
	{
        public List<Actividad> Actividades { get; } = new List<Actividad>();
        public List<Usuario> Usuarios { get; } = new List<Usuario>();
        public List<Agenda> Agendas { get; } = new List<Agenda>();

        //singleton
        private static Sistema _instancia = null;

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        public void Precargar()
        {
            PrecargarDatosInternas();
            PrecargarDatosTercerizadas();
            PrecargarHuespedes();
        }

        private void PrecargarDatosInternas()
        {
            Interna Interna1 = new Interna("Manuel", "LugarInterno1", true, "ActInterna1", "Descripción interna 1", new DateTime(2024, 01, 12), 10, 0, 2);
            AgregarActividadInterna(Interna1);

            Interna Interna2 = new Interna("Pedro", "LugarInterno2", true, "ActInterna2", "Descripción interna 2", new DateTime(2024, 02, 12), 11, 0, 6);
            AgregarActividadInterna(Interna2);

            Interna Interna3 = new Interna("Facundo", "LugarInterno3", false, "ActInterna3", "Descripción interna 3", new DateTime(2024, 03, 12), 12, 60, 1);
            AgregarActividadInterna(Interna3);

            Interna Interna4 = new Interna("Federico", "LugarInterno4", true, "ActInterna4", "Descripción interna 4", new DateTime(2024, 04, 12), 12, 35, 2);
            AgregarActividadInterna(Interna4);

            Interna Interna5 = new Interna("Gabriel", "LugarInterno5", false, "ActInterna5", "Descripción interna 5", new DateTime(2024, 05, 12), 9, 25, 10);
            AgregarActividadInterna(Interna5);

            Interna Interna6 = new Interna("Nahuel", "LugarInterno6", true, "ActInterna6", "Descripción interna 6", new DateTime(2024, 06, 12), 10, 20, 5);
            AgregarActividadInterna(Interna6);

            Interna Interna7 = new Interna("Nacho", "LugarInterno7", false, "ActInterna7", "Descripción interna 7", new DateTime(2024, 07, 12), 8, 11, 6);
            AgregarActividadInterna(Interna7);

            Interna Interna8 = new Interna("Mateo", "LugarInterno8", true, "ActInterna8", "Descripción interna 8", new DateTime(2024, 08, 12), 6, 0, 5);
            AgregarActividadInterna(Interna8);

            Interna Interna9 = new Interna("Maxi", "LugarInterno9", false, "ActInterna9", "Descripción interna 9", new DateTime(2024, 09, 12), 6, 0, 5);
            AgregarActividadInterna(Interna9);

            Interna Interna10 = new Interna("Felipe", "LugarInterno10", false, "ActInterna10", "Descripción interna 10", new DateTime(2024, 10, 12), 9, 30, 8);
            AgregarActividadInterna(Interna10);
        }

        private void PrecargarDatosTercerizadas()
        {
            
            Proveedor Proveedor1 = new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 1);
            ValidarProveedorRepetido(Proveedor1);

            Tercerizada Tercerizada1 = new Tercerizada(Proveedor1, false, new DateTime(2024, 01, 12), "ActTercerizada1", "Descripcion tercerizada 1", new DateTime(2024, 01, 12), 10, 0, 10);
            AgregarActividadTercerizada(Tercerizada1);

            Proveedor Proveedor2 = new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7);
            ValidarProveedorRepetido(Proveedor2);

            Tercerizada Tercerizada2 = new Tercerizada(Proveedor1, false, new DateTime(2024, 02, 12), "ActTercerizada2", "Descripcion tercerizada 2", new DateTime(2024, 02, 12), 12, 30, 2);
            AgregarActividadTercerizada(Tercerizada2);

            Proveedor Proveedor3 = new Proveedor("Bacci Tours", "29152020", "Misiones 1140", 9);
            ValidarProveedorRepetido(Proveedor3);

            Tercerizada Tercerizada3 = new Tercerizada(Proveedor1, false, new DateTime(2024, 03, 12), "ActTercerizada3", "Descripcion tercerizada 3", new DateTime(2024, 03, 12), 12, 0, 20);
            AgregarActividadTercerizada(Tercerizada3);

            Proveedor Proveedor4 = new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11);
            ValidarProveedorRepetido(Proveedor4);

            Tercerizada Tercerizada4 = new Tercerizada(Proveedor2, false, new DateTime(2024, 04, 12), "ActTercerizada4", "Descripcion tercerizada 4", new DateTime(2024, 04, 12), 10, 22, 10);
            AgregarActividadTercerizada(Tercerizada4);

            Proveedor Proveedor5 = new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10);
            ValidarProveedorRepetido(Proveedor5);

            Tercerizada Tercerizada5 = new Tercerizada(Proveedor2, false, new DateTime(2024, 05, 12), "ActTercerizada5", "Descripcion tercerizada 5", new DateTime(2024, 05, 12), 8, 0, 15);
            AgregarActividadTercerizada(Tercerizada5);

            Proveedor Proveedor6 = new Proveedor("Electric Blue", "26018945", "Cooper 678", 5);
            ValidarProveedorRepetido(Proveedor6);

            Tercerizada Tercerizada6 = new Tercerizada(Proveedor5, false, new DateTime(2024, 06, 12), "ActTercerizada6", "Descripcion tercerizada 6", new DateTime(2024, 06, 12), 8, 0, 10);
            AgregarActividadTercerizada(Tercerizada6);

            Proveedor Proveedor7 = new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4);
            ValidarProveedorRepetido(Proveedor7);

            Tercerizada Tercerizada7 = new Tercerizada(Proveedor3, false, new DateTime(2024, 07, 12), "ActTercerizada7", "Descripcion tercerizada 7", new DateTime(2024, 07, 12), 18, 33, 5);
            AgregarActividadTercerizada(Tercerizada7);

            Proveedor Proveedor8 = new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7);
            ValidarProveedorRepetido(Proveedor8);

            Tercerizada Tercerizada8 = new Tercerizada(Proveedor5, false, new DateTime(2024, 08, 12), "ActTercerizada8", "Descripcion tercerizada 8", new DateTime(2024, 08, 12), 12, 65, 10);
            AgregarActividadTercerizada(Tercerizada8);

            Proveedor Proveedor9 = new Proveedor("Perez Marquez", "22041120", "Agraciada 2512 Apto. 1", 8);
            ValidarProveedorRepetido(Proveedor9);

            Tercerizada Tercerizada9 = new Tercerizada(Proveedor3, false, new DateTime(2024, 09, 12), "ActTercerizada9", "Descripcion tercerizada 9", new DateTime(2024, 09, 12), 18, 0, 15);
            AgregarActividadTercerizada(Tercerizada9);

            Proveedor Proveedor10 = new Proveedor("MiloLines", "22001189", "Michigan 2100", 9);
            ValidarProveedorRepetido(Proveedor10);

            Tercerizada Tercerizada10 = new Tercerizada(Proveedor4, false, new DateTime(2024, 10, 12), "ActTercerizada10", "Descripcion tercerizada 10", new DateTime(2024, 10, 12), 18, 45, 15);
            AgregarActividadTercerizada(Tercerizada10);

            Tercerizada Tercerizada11 = new Tercerizada(Proveedor6, false, new DateTime(2024, 11, 12), "ActTercerizada11", "Descripcion tercerizada 11", new DateTime(2024, 11, 12), 10, 55, 10);
            AgregarActividadTercerizada(Tercerizada11);

            Tercerizada Tercerizada12 = new Tercerizada(Proveedor7, false, new DateTime(2024, 12, 12), "ActTercerizada12", "Descripcion tercerizada 12", new DateTime(2024, 12, 12), 10, 0, 20);
            AgregarActividadTercerizada(Tercerizada12);

            Tercerizada Tercerizada13 = new Tercerizada(Proveedor8, false, new DateTime(2024, 01, 12), "ActTercerizada13", "Descripcion tercerizada 13", new DateTime(2024, 01, 12), 12, 0, 20);
            AgregarActividadTercerizada(Tercerizada13);

            Tercerizada Tercerizada14 = new Tercerizada(Proveedor9, false, new DateTime(2024, 02, 12), "ActTercerizada14", "Descripcion tercerizada 14", new DateTime(2024, 02, 12), 8, 65, 5);
            AgregarActividadTercerizada(Tercerizada14);

            Tercerizada Tercerizada15 = new Tercerizada(Proveedor10, false, new DateTime(2024, 03, 12), "ActTercerizada15", "Descripcion tercerizada 15", new DateTime(2024, 03, 12), 12, 10, 2);
            AgregarActividadTercerizada(Tercerizada15);
        }

        public void PrecargarHuespedes()
        {
            Huesped Huesped1 = new Huesped(new Documento(TipoDocumento.CI, "51243902"), "Facundo", "Rubino", "24", new DateTime(2000, 04, 21), 4, "facundorubino21@gmail.com", "password");
            AgregarHuesped(Huesped1);
        }

        public void AgregarActividadInterna(Interna interna)
        {
            if (interna == null) throw new Exception("Actividad interna no válida");
            
            interna.Validar();
            Actividades.Add(interna);
        }

        public void AgregarActividadTercerizada(Tercerizada tercerizada)
        {
            if (tercerizada == null) throw new Exception("Actividad tercerizada no válida");

            tercerizada.Validar();
            Actividades.Add(tercerizada);
        }

        public void AgregarHuesped(Huesped huesped)
        {
            if (huesped == null) throw new Exception("El huesped no es válido");

            huesped.Validar();
            ValidarDocumentoRepetido(huesped);
            Usuarios.Add(huesped);
        }

        public void ValidarProveedorRepetido(Proveedor proveedor)
        {
            foreach (Actividad item in Actividades)
            {
                if (item is Tercerizada)
                {
                    Tercerizada unaTercerizada = item as Tercerizada;

                    if (unaTercerizada.Proveedor.Nombre == proveedor.Nombre) throw new Exception($"El nombre:'{proveedor.Nombre}' de proveedor ya existe");
                }
            }
        }

        public void ValidarDocumentoRepetido(Huesped huespedIngresado)
        {
            foreach (Usuario item in Usuarios)
            {
                //Hago la consulta aunque sean todos tipo huespedes, para que funcione igual de bien en el segundo obligatorio
                if (item is Huesped)
                {
                    Huesped unHuesped = item as Huesped;
                    if (unHuesped.Documento.NumDocumento == huespedIngresado.Documento.NumDocumento || unHuesped.Documento.TipoDocumento == huespedIngresado.Documento.TipoDocumento)
                    {
                        throw new Exception($"Ya existe '{huespedIngresado.Documento.TipoDocumento}' con el número {huespedIngresado.Documento.NumDocumento}");
                    }
                }
            }
        }

        public Proveedor? ObtenerProveedorPorNombre(string nombre)
        {
            foreach (Actividad item in Actividades)
            {
                if (item is Tercerizada)
                {
                    Tercerizada unaTercerizada = item as Tercerizada;

                    if (unaTercerizada.Proveedor.Nombre == nombre)
                    {
                        return unaTercerizada.Proveedor;
                    }
                } 
            }
            return null;
        }

        public void ModificarPromocionProveedor(string nombre, int promocion)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception($"El nombre no es válido");
            }
           
            Proveedor unProveedor = ObtenerProveedorPorNombre(nombre);

            if (unProveedor == null)
            {
                throw new Exception($"No se encontro el proveedor de nombre: {nombre}");
            }
            unProveedor.Descuento = promocion;
        }



    }
}

