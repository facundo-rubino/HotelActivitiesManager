using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Dominio.Documento;

namespace Dominio
{
    public class Sistema
    {
        public List<Actividad> Actividades { get; } = new List<Actividad>();
        public List<Usuario> Usuarios { get; } = new List<Usuario>();
        public List<Agenda> Agendas { get; } = new List<Agenda>();
        public List<TipoDocumento> TiposDeDocumento { get; } = new List<TipoDocumento>();


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

        private Sistema()
        {
            Precargar();
        }

        public void Precargar()
        {
            PrecargarDatosInternas();
            PrecargarDatosTercerizadas();
            PrecargarTiposDeDocumento();
            PrecargarHuespedes();
            PrecargarOperadores();
        }

        private void PrecargarDatosInternas()
        {
            Interna Interna1 = new Interna("Valentina", "Salón de bienestar", true, "Clase de yoga al amanecer", "Únete a nuestra sesión de yoga temprano en la mañana para comenzar el día con energía y equilibrio.", new DateTime(2024, 01, 12), 10, 0, 2);
            AgregarActividadInterna(Interna1);

            Interna Interna2 = new Interna("Facundo", "Área de recepción", true, "Excursión en bicicleta por la ciudad", "Explora los lugares más pintorescos de la ciudad en una emocionante excursión en bicicleta guiada.", new DateTime(2024, 02, 12), 11, 0, 6);
            AgregarActividadInterna(Interna2);

            Interna Interna3 = new Interna("Marcelo", "Cocina gourmet", false, "Taller de cocina local", "Descubre los secretos de la cocina local mientras aprendes a preparar platos tradicionales con nuestros talentosos chefs.", new DateTime(2024, 03, 12), 12, 60, 10);
            AgregarActividadInterna(Interna3);

            Interna Interna4 = new Interna("Tatiana", " Salón de entretenimiento", true, "Noche de música en vivo", "Disfruta de una noche de música en vivo en nuestro acogedor salón mientras te relajas con una copa de vino.", new DateTime(2024, 04, 12), 12, 35, 2);
            AgregarActividadInterna(Interna4);

            Interna Interna5 = new Interna("Federico", "Barra de cócteles", false, "Clase de coctelería", "Aprende a mezclar y preparar los cócteles más deliciosos en nuestra clase interactiva de coctelería.", new DateTime(2024, 05, 12), 9, 25, 0);
            AgregarActividadInterna(Interna5);

            Interna Interna6 = new Interna("María José", "Sala de catas", true, "Tour de cata de vinos", "Déjate seducir por los sabores y aromas de los vinos de la región en nuestro exclusivo tour de cata de vinos.", new DateTime(2024, 06, 12), 10, 20, 10);
            AgregarActividadInterna(Interna6);

            Interna Interna7 = new Interna("Gabriel", "Playa privada", false, "Clase de surf", "Atrévete a desafiar las olas y aprende a surfear con la ayuda de nuestros experimentados instructores.", new DateTime(2024, 07, 12), 8, 11, 6);
            AgregarActividadInterna(Interna7);

            Interna Interna8 = new Interna("Santiago", "Jardín central", true, "Noche de cine al aire libre", "Disfruta de una película bajo las estrellas en nuestro jardín, mientras te relajas en una cómoda hamaca.", new DateTime(2024, 08, 12), 6, 0, 0);
            AgregarActividadInterna(Interna8);

            Interna Interna9 = new Interna("Jorge", "Senderos cercanos", false, "Caminata por la naturaleza", "Explora los senderos naturales cercanos al hotel y admira la belleza de la flora y fauna local.", new DateTime(2024, 09, 12), 6, 0, 5);
            AgregarActividadInterna(Interna9);

            Interna Interna10 = new Interna("Serenella", "Salón de baile", false, "Clase de baile latino", "Aprende los movimientos más sensuales y divertidos de la salsa y la bachata en nuestra clase de baile latino.", new DateTime(2024, 10, 12), 9, 30, 0);
            AgregarActividadInterna(Interna10);

            #region TestingInterna
            //Testeo Validar Nombre vacío
            //Interna InternaTesting = new Interna("Felipe", "LugarInterno10", false, "", "Descripción interna 10", new DateTime(2024, 10, 12), 9, 30, 8);
            //AgregarActividadInterna(InternaTesting);
            #endregion

        }

        private void PrecargarDatosTercerizadas()
        {
            Proveedor Proveedor1 = new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10);
            ValidarProveedorRepetido(Proveedor1);
            Proveedor1.Validar();

            Tercerizada Tercerizada1 = new Tercerizada(Proveedor1, true, new DateTime(2024, 01, 12), "Torneo de tenis", "Demuestra tus habilidades en la cancha de tenis en nuestro torneo amistoso organizado para huéspedes.", new DateTime(2024, 01, 12), 10, 0, 10);
            AgregarActividadTercerizada(Tercerizada1);

            Proveedor Proveedor2 = new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 20);
            ValidarProveedorRepetido(Proveedor2);
            Proveedor2.Validar();


            Tercerizada Tercerizada2 = new Tercerizada(Proveedor1, false, new DateTime(2024, 02, 12), "Spa de lujo", "Sumérgete en un oasis de relajación con nuestros tratamientos de spa rejuvenecedores y terapéuticos.", new DateTime(2024, 02, 12), 12, 30, 2);
            AgregarActividadTercerizada(Tercerizada2);


            Proveedor Proveedor3 = new Proveedor("TravelFun", "29152020", "Misiones 1140", 25);
            ValidarProveedorRepetido(Proveedor3);
            Proveedor3.Validar();

            Tercerizada Tercerizada3 = new Tercerizada(Proveedor1, false, new DateTime(2024, 03, 12), "Clase de pintura", "Libera tu creatividad y descubre el artista que llevas dentro en nuestra clase de pintura dirigida.", DateTime.Today, 12, 0, 20);
            AgregarActividadTercerizada(Tercerizada3);

            Proveedor Proveedor4 = new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 20);
            ValidarProveedorRepetido(Proveedor4);
            Proveedor4.Validar();

            Tercerizada Tercerizada4 = new Tercerizada(Proveedor2, true, new DateTime(2024, 04, 12), "Excursión a la montaña", "Embárcate en una emocionante aventura en las montañas cercanas, disfrutando de vistas impresionantes y aire fresco.", new DateTime(2024, 04, 12), 10, 22, 10);
            AgregarActividadTercerizada(Tercerizada4);

            Proveedor Proveedor5 = new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10);
            ValidarProveedorRepetido(Proveedor5);
            Proveedor5.Validar();

            Tercerizada Tercerizada5 = new Tercerizada(Proveedor2, true, new DateTime(2024, 05, 11), "Torneo de Basquetbol", "Torneo de basquetbol 3x3 para poder competir con tus amigos o conocer gente nueva", DateTime.Today, 8, 0, 15);
            AgregarActividadTercerizada(Tercerizada5);

            Proveedor Proveedor6 = new Proveedor("Electric Blue", "26018945", "Cooper 678", 35);
            ValidarProveedorRepetido(Proveedor6);
            Proveedor6.Validar();

            Tercerizada Tercerizada6 = new Tercerizada(Proveedor5, true, new DateTime(2024, 06, 12), "Clase de meditación", "Aprende a calmar tu mente y encontrar la paz interior en nuestra clase guiada de meditación.", new DateTime(2024, 06, 12), 8, 0, 10);
            AgregarActividadTercerizada(Tercerizada6);

            Proveedor Proveedor7 = new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 50);
            ValidarProveedorRepetido(Proveedor7);
            Proveedor7.Validar();

            Tercerizada Tercerizada7 = new Tercerizada(Proveedor3, false, new DateTime(2024, 07, 12), "Paseo en velero", "Disfruta de la brisa marina y las vistas panorámicas en un relajante paseo en velero por la costa.", DateTime.Today, 18, 33, 0);
            AgregarActividadTercerizada(Tercerizada7);

            Proveedor Proveedor8 = new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 10);
            ValidarProveedorRepetido(Proveedor8);
            Proveedor8.Validar();

            Tercerizada Tercerizada8 = new Tercerizada(Proveedor5, true, new DateTime(2024, 06, 12), "Tour de observación de aves", "Descubre la diversidad de aves locales en un apasionante tour de observación con un guía experto.", new DateTime(2024, 08, 12), 12, 65, 10);
            AgregarActividadTercerizada(Tercerizada8);

            Proveedor Proveedor9 = new Proveedor("Salt Lake", "22041120", "Agraciada 2512 Apto. 1", 15);
            ValidarProveedorRepetido(Proveedor9);
            Proveedor9.Validar();

            Tercerizada Tercerizada9 = new Tercerizada(Proveedor9, true, new DateTime(2024, 09, 12), "Noche de karaoke", "Muestra tu talento vocal y diviértete con amigos en nuestra noche de karaoke llena de risas y música.", DateTime.Today, 18, 0, 15);
            AgregarActividadTercerizada(Tercerizada9);

            Proveedor Proveedor10 = new Proveedor("Norberto Molina", "22001189", "Michigan 2100", 15);
            ValidarProveedorRepetido(Proveedor10);
            Proveedor10.Validar();

            Tercerizada Tercerizada10 = new Tercerizada(Proveedor4, true, new DateTime(2024, 10, 12), "Clase de Pilates", "Fortalece tu cuerpo y mejora tu flexibilidad en nuestra clase de Pilates, impartida por un instructor certificado", new DateTime(2024, 10, 12), 18, 45, 0);
            AgregarActividadTercerizada(Tercerizada10);

            Tercerizada Tercerizada11 = new Tercerizada(Proveedor6, false, new DateTime(2024, 11, 12), "Excursión a una cascada", "Embárcate en una emocionante excursión a una hermosa cascada escondida en plena naturaleza.", new DateTime(2024, 11, 12), 10, 55, 10);
            AgregarActividadTercerizada(Tercerizada11);

            Tercerizada Tercerizada12 = new Tercerizada(Proveedor7, true, new DateTime(2024, 12, 12), "Noche de juegos de casino", "Prueba tu suerte en nuestra noche temática de casino, donde podrás disfrutar de emocionantes juegos de mesa como blackjack, ruleta y póker. ", new DateTime(2024, 12, 12), 10, 0, 20);
            AgregarActividadTercerizada(Tercerizada12);

            Tercerizada Tercerizada13 = new Tercerizada(Proveedor8, false, new DateTime(2024, 01, 12), "Clase de boxeo", "Descarga adrenalina y mejora tu condición física en nuestra clase de boxeo, dirigida por un entrenador profesional. ", new DateTime(2024, 01, 12), 12, 0, 20);
            AgregarActividadTercerizada(Tercerizada13);

            Tercerizada Tercerizada14 = new Tercerizada(Proveedor9, false, new DateTime(2024, 02, 12), "Excursión en kayak", "Descubre la belleza de la costa mientras remas en kayak a lo largo de la costa marítima. ", new DateTime(2024, 02, 12), 8, 65, 5);
            AgregarActividadTercerizada(Tercerizada14);

            Tercerizada Tercerizada15 = new Tercerizada(Proveedor10, false, new DateTime(2024, 03, 12), "Noche de Stand up", "Ríete a carcajadas en nuestra noche de comedia, donde talentosos comediantes te harán pasar un rato inolvidable con sus actuaciones.", new DateTime(2024, 03, 12), 12, 10, 0);
            AgregarActividadTercerizada(Tercerizada15);

            #region TestingProveedor

            //Testing Proveedor

            //Testeo Validar Nombre vacío
            //Proveedor ProveedorTesteo = new Proveedor("", "22001189", "Michigan 2100", 9);
            //ProveedorTesteo.Validar();

            //Testeo Validar Nombre repetido
            //Proveedor ProveedorTesteo = new Proveedor("Norberto Molina", "22001189", "Michigan 2100", 9);
            //ValidarProveedorRepetido(ProveedorTesteo);

            //Testeo Validar Número vacío
            //Proveedor ProveedorTesteo = new Proveedor("Nombre testing", "", "Michigan 2100", 9);
            //ProveedorTesteo.Validar();

            //Testeo Validar Dirección vacía
            //Proveedor ProveedorTesteo = new Proveedor("Nombre testing", "222", "", 9);
            //ProveedorTesteo.Validar();

            //Testeo Validar Descuento equivocado
            //Proveedor ProveedorTesteo = new Proveedor("Nombre testing", "222", "dire", 101);
            //ProveedorTesteo.Validar();

            //Testing Tercerizadas

            //Testeo Validar Nombre vacío
            //Tercerizada TercerizadaTesting = new Tercerizada(Proveedor10, false, new DateTime(2024, 03, 12), "", "Descripcion tercerizada 15", new DateTime(2024, 03, 12), 12, 10, 2);
            //AgregarActividadTercerizada(TercerizadaTesting);

            //Testeo Validar Nombre largo
            //Tercerizada TercerizadaTesting = new Tercerizada(Proveedor10, false, new DateTime(2024, 03, 12), "nombreNombreNombreNombreNombreNombre", "Descripcion tercerizada 15", new DateTime(2024, 03, 12), 12, 10, 2);
            //AgregarActividadTercerizada(TercerizadaTesting);

            //Testeo Validar Descripción vacía
            //Tercerizada TercerizadaTesting = new Tercerizada(Proveedor10, false, new DateTime(2024, 03, 12), "ActTercerizada16", "", new DateTime(2024, 03, 12), 12, 10, 2);
            //AgregarActividadTercerizada(TercerizadaTesting);

            //Testeo Validar fecha menor a la de hoy
            //Tercerizada TercerizadaTesting = new Tercerizada(Proveedor10, false, new DateTime(2024, 02, 12), "ActTercerizada16", "desc", new DateTime(2023, 02, 12), 12, 10, 2);
            //AgregarActividadTercerizada(TercerizadaTesting);


            #endregion

        }

        private void PrecargarTiposDeDocumento()
        {
            TipoDocumento CEDULA = new TipoDocumento("Cédula");
            TiposDeDocumento.Add(CEDULA);
            TipoDocumento PASAPORTE = new TipoDocumento("Pasaporte");
            TiposDeDocumento.Add(PASAPORTE);
            TipoDocumento OTROS = new TipoDocumento("Otros");
            TiposDeDocumento.Add(OTROS);
        }

        private void PrecargarHuespedes()
        {
            Huesped Huesped1 = new Huesped(new Documento(1, "51243902"), "Facundo", "Rubino", new DateTime(2000, 04, 21), "facundorubino21@gmail.com", "password");
            AgregarHuesped(Huesped1);

            #region TestingHuesped

            //Testeo mail erroneo
            //Huesped HuespedTesting = new Huesped(new Documento(1, "51243902"), "Facundo", "Rubino", "24", new DateTime(2000, 04, 21), "facundorubino21@", "password");
            //AgregarHuesped(HuespedTesting);

            //Testeo contraseña corta
            //Huesped HuespedTesting = new Huesped(new Documento(1, "51243902"), "Facundo", "Rubino", "24", new DateTime(2000, 04, 21), "facundorubino21@123", "pass");
            //AgregarHuesped(HuespedTesting);

            //Testeo Habitación Vacía
            //Huesped HuespedTesting = new Huesped(new Documento(1, "51243902"), "Facundo", "Rubino", "", new DateTime(2000, 04, 21), "facundorubino21@123", "password");
            //AgregarHuesped(HuespedTesting);

            //Testeo Nombre Vacío
            //Huesped HuespedTesting = new Huesped(new Documento(1, "51243902"), "", "Rubino", "22", new DateTime(2000, 04, 21), "facundorubino21@123", "password");
            //AgregarHuesped(HuespedTesting);

            //Testeo Apellido Vacío
            //Huesped HuespedTesting = new Huesped(new Documento(1, "51243902"), "Facundo", "", "22", new DateTime(2000, 04, 21), "facundorubino21@123", "password");
            //AgregarHuesped(HuespedTesting);

            //Testeo Documento invalido
            //Huesped HuespedTesting = new Huesped(new Documento(1, "5124390"), "Facundo", "Rubino", "22", new DateTime(2000, 04, 21), "facundorubino21@123", "password");
            //AgregarHuesped(HuespedTesting);

            //Testeo Documento Repetido
            //Huesped HuespedTesting = new Huesped(new Documento(1, "51243902"), "Facundo", "Rubino", "22", new DateTime(2000, 04, 21), "facundorubino21@123", "password");
            //AgregarHuesped(HuespedTesting);

            #endregion
        }

        private void PrecargarOperadores()
        {
            Operador Operador1 = new Operador("admin@admin", "admin1234", "Facundo", "Rubino", new DateTime(2023, 02, 01));
            AgregarOperador(Operador1);

            Operador Operador2 = new Operador("admin@ort", "admin1234", "Luis", "Dentone", new DateTime(2020, 02, 01));
            AgregarOperador(Operador2);
        }

        public void AgregarActividadInterna(Interna interna)
        {
            if (interna == null) throw new Exception("Actividad interna no válida");

            if (Actividades.Contains(interna))
            {
                throw new Exception($"El nombre de la actividad {interna.Nombre} ya esta registrado.");
            }

            interna.Validar();
            Actividades.Add(interna);
        }

        public void AgregarActividadTercerizada(Tercerizada tercerizada)
        {
            if (tercerizada == null) throw new Exception("Actividad tercerizada no válida");

            if (Actividades.Contains(tercerizada))
            {
                throw new Exception($"El nombre de la actividad {tercerizada.Nombre} ya esta registrada.");
            }

            tercerizada.Validar();
            Actividades.Add(tercerizada);
        }

        public void AgregarHuesped(Huesped huesped)
        {
            if (huesped == null) throw new Exception("El huesped no es válido");

            if (Usuarios.Contains(huesped))
            {
                throw new Exception($"El email {huesped.Email} ya esta registrado.");
            }

            huesped.Validar();
            huesped.Documento.ValidarCedula();
            ValidarDocumentoRepetido(huesped);
            Usuarios.Add(huesped);
        }

        public void AgregarOperador(Operador operador)
        {
            if (operador == null) throw new Exception("El operador no es válido");

            if (Usuarios.Contains(operador))
            {
                throw new Exception($"El email {operador.Email} ya esta registrado.");
            }

            operador.Validar();
            Usuarios.Add(operador);
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
                if (item is Huesped)
                {
                    Huesped unHuesped = item as Huesped;
                    if (unHuesped.Documento.NumDocumento == huespedIngresado.Documento.NumDocumento && unHuesped.Documento.TipoDocumento == huespedIngresado.Documento.TipoDocumento)
                    {
                        throw new Exception($"Ya existe la cédula con el número {huespedIngresado.Documento.NumDocumento}");
                    }
                }
            }
        }

        public Proveedor? ObtenerProveedorPorNumero(string numero)
        {
            foreach (Actividad item in Actividades)
            {
                if (item is Tercerizada)
                {
                    Tercerizada unaTercerizada = item as Tercerizada;
                    if (unaTercerizada.Proveedor.Numero == numero)
                    {
                        return unaTercerizada.Proveedor;
                    }
                }
            }
            return null;
        }

        public void ModificarPromocionProveedor(string numero, decimal descuento)
        {
            if (descuento < 0 || descuento > 100) throw new Exception("La promoción ofrecida por el proveedor puede ser de 0 a 100");

            if (string.IsNullOrEmpty(numero)) throw new Exception($"El numero no es válido");

            if (descuento == null) throw new Exception($"El descuento no es válido");


            Proveedor unProveedor = ObtenerProveedorPorNumero(numero);

            if (unProveedor == null) throw new Exception($"No se encontro el proveedor de número: {numero}");

            unProveedor.Descuento = descuento;
        }

        public IEnumerable<Proveedor> ListaProveedoresOrdenada()
        {
            List<Proveedor> aux = new List<Proveedor>();

            foreach (Actividad item in Actividades)
            {
                if (item is Tercerizada)
                {
                    Tercerizada unaTercerizada = item as Tercerizada;

                    if (!aux.Contains(unaTercerizada.Proveedor))
                    {
                        aux.Add(unaTercerizada.Proveedor);
                    }
                }
            }
            aux.Sort();
            return aux;
        }

        public IEnumerable<Actividad> ListaActividadesPorCosto(DateTime fechaUno, DateTime fechaDos, int costoIngresado)
        {
            int fechasComparadas = DateTime.Compare(fechaUno, fechaDos);

            if (fechasComparadas > 0)
            {
                //fecha1 más grande que la fecha2;
                DateTime fechaAux = fechaUno;
                fechaUno = fechaDos;
                fechaDos = fechaAux;
            }

            List<Actividad> aux = new List<Actividad>();

            foreach (Actividad item in Actividades)
            {
                if (item.Costo > costoIngresado && item.Fecha >= fechaUno && item.Fecha <= fechaDos)
                {
                    aux.Add(item);
                }
            }
            aux.Sort();
            return aux;
        }

        public IEnumerable<Actividad> ListaActividadesPorFecha(DateTime fecha)
        {
            List<Actividad> aux = new List<Actividad>();

            foreach (Actividad item in Actividades)
            {
                if (item.Fecha == fecha)
                {
                    aux.Add(item);
                }
            }
            aux.Sort();
            return aux;
        }

        public IEnumerable<Actividad> ListaActividadesDelDia()
        {
            List<Actividad> ActividadesDeHoy = new List<Actividad>();

            foreach (Actividad item in Actividades)
            {
                if (item.Fecha == DateTime.Today)
                {
                    ActividadesDeHoy.Add(item);
                }
            }
            ActividadesDeHoy.Sort();
            return ActividadesDeHoy;

        }

        public IEnumerable<Agenda> ListaActividadesPorProveedor(int tipoDocumento, string numDocumento)
        {

            Documento documentoHuesped = new Documento(tipoDocumento, numDocumento);

            List<Agenda> aux = new List<Agenda>();
            foreach (Agenda item in Agendas)
            {
                if (item.Huesped.Documento.Equals(documentoHuesped))
                {
                    aux.Add(item);
                }
            }
            return aux;
        }

        public IEnumerable<Agenda> AgendasPorFecha(DateTime fechaUno, DateTime fechaDos)
        {
            List<Agenda> aux = new List<Agenda>();

            foreach (Agenda item in Agendas)
            {
                if (item.AgendaEntreFechas(fechaUno, fechaDos))
                {
                    aux.Add(item);
                }
            }
            return aux;
        }

        public void CrearAgenda(Huesped huesped, Actividad actividad)
        {
            string estado = "PENDIENTE_PAGO";
            decimal costoAgenda = actividad.CalcularCosto(huesped.Fidelizacion);
            if (costoAgenda == 0)
                estado = "CONFIRMADA";

            Agenda agenda = new Agenda(actividad, huesped, estado, costoAgenda, DateTime.Now);
            AgregarAgenda(agenda);

        }

        public void AgregarAgenda(Agenda agenda)
        {
            if (agenda == null) throw new Exception("La agenda no es válida");

            agenda.Validar();
            Agendas.Add(agenda);
        }

        public Usuario ObtenerUsuario(string email, string pass)
        {
            foreach (Usuario item in Usuarios)
            {
                if (item.Email == email)
                {
                    if (item.Contrasenia == pass)
                        return item;
                    else
                        throw new Exception("Contraseña incorrecta");
                }
            }
            throw new Exception($"Usuario no encontrado para el email: {email}");
        }


        public string ObtenerRolUsuario(string email, string pass)
        {
            string rol = "";
            Usuario usuarioLogueado = ObtenerUsuario(email, pass);

            if (usuarioLogueado is Huesped) rol = "huesped";
            if (usuarioLogueado is Operador) rol = "operador";

            return rol;
        }


    }
}

