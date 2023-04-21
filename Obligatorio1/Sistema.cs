using System;
namespace Obligatorio1
{
	public class Sistema
	{
		public List<Actividad> Actividades { get; }
		public List<Usuario> Usuarios { get; }
		public List<Agenda> Agendas { get;  }


		public Sistema()
		{
		}

        public void Precargar()
        {
            PrecargarDatosInternas();
            PrecargarDatosTercerizadas();
        }

        private void PrecargarDatosInternas()
        {
            Interna Interna1 = new Interna("Manuel", "LugarInterno1", true, "ActInterna1", "Descripción interna 1", new DateTime(2024, 01, 12), 10, 40, 2);
            Interna Interna2 = new Interna("Pedro", "LugarInterno2", true, "ActInterna2", "Descripción interna 2", new DateTime(2024, 02, 12), 11, 67, 6);
            Interna Interna3 = new Interna("Facundo", "LugarInterno3", false, "ActInterna3", "Descripción interna 3", new DateTime(2024, 03, 12), 12, 60, 1);
            Interna Interna4 = new Interna("Federico", "LugarInterno4", true, "ActInterna4", "Descripción interna 4", new DateTime(2024, 04, 12), 12, 35, 2);
            Interna Interna5 = new Interna("Gabriel", "LugarInterno5", false, "ActInterna5", "Descripción interna 5", new DateTime(2024, 05, 12), 9, 25, 10);
            Interna Interna6 = new Interna("Nahuel", "LugarInterno6", true, "ActInterna6", "Descripción interna 6", new DateTime(2024, 06, 12), 10, 20, 5);
            Interna Interna7 = new Interna("Nacho", "LugarInterno7", false, "ActInterna7", "Descripción interna 7", new DateTime(2024, 07, 12), 8, 11, 6);
            Interna Interna8 = new Interna("Mateo", "LugarInterno8", true, "ActInterna8", "Descripción interna 8", new DateTime(2024, 08, 12), 6, 20, 5);
            Interna Interna9 = new Interna("Maxi", "LugarInterno9", false, "ActInterna9", "Descripción interna 9", new DateTime(2024, 09, 12), 6, 22, 5);
            Interna Interna10 = new Interna("Felipe", "LugarInterno10", false, "ActInterna10", "Descripción interna 10", new DateTime(2024, 10, 12), 9, 30, 8);
        }

        private void PrecargarDatosTercerizadas()
        {
            Proveedor Proveedor1 = new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 1);
            Proveedor Proveedor2 = new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7);
            Proveedor Proveedor3 = new Proveedor("TravelFun", "29152020", "Misiones 1140", 9);
            Proveedor Proveedor4 = new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11);
            Proveedor Proveedor5 = new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10);
            Proveedor Proveedor6 = new Proveedor("Electric Blue", "26018945", "Cooper 678", 5);
            Proveedor Proveedor7 = new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4);
            Proveedor Proveedor8 = new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7);
            Proveedor Proveedor9 = new Proveedor("", "22041120", "Agraciada 2512 Apto. 1", 8);
            Proveedor Proveedor10 = new Proveedor("Norberto Molina", "22001189", "Paraguay 2100", 9);

            Tercerizada Tercerizada1 = new Tercerizada(Proveedor1, false, new DateTime(2024, 01, 12), "ActTercerizada1", "Descripcion tercerizada 1", new DateTime(2023, 01, 12), 10, 40, 10);
            Tercerizada Tercerizada2 = new Tercerizada(Proveedor1, false, new DateTime(2024, 02, 12), "ActTercerizada2", "Descripcion tercerizada 2", new DateTime(2023, 02, 12), 12, 30, 2);
            Tercerizada Tercerizada3 = new Tercerizada(Proveedor1, false, new DateTime(2024, 03, 12), "ActTercerizada3", "Descripcion tercerizada 3", new DateTime(2023, 03, 12), 12, 32, 20);
            Tercerizada Tercerizada4 = new Tercerizada(Proveedor2, false, new DateTime(2024, 04, 12), "ActTercerizada4", "Descripcion tercerizada 4", new DateTime(2023, 04, 12), 10, 22, 10);
            Tercerizada Tercerizada5 = new Tercerizada(Proveedor2, false, new DateTime(2024, 05, 12), "ActTercerizada5", "Descripcion tercerizada 5", new DateTime(2023, 05, 12), 8, 41, 15);
            Tercerizada Tercerizada6 = new Tercerizada(Proveedor2, false, new DateTime(2024, 06, 12), "ActTercerizada6", "Descripcion tercerizada 6", new DateTime(2023, 06, 12), 8, 45, 10);
            Tercerizada Tercerizada7 = new Tercerizada(Proveedor3, false, new DateTime(2024, 07, 12), "ActTercerizada7", "Descripcion tercerizada 7", new DateTime(2023, 07, 12), 18, 33, 5);
            Tercerizada Tercerizada8 = new Tercerizada(Proveedor3, false, new DateTime(2024, 08, 12), "ActTercerizada8", "Descripcion tercerizada 8", new DateTime(2023, 08, 12), 12, 65, 10);
            Tercerizada Tercerizada9 = new Tercerizada(Proveedor3, false, new DateTime(2024, 09, 12), "ActTercerizada9", "Descripcion tercerizada 9", new DateTime(2023, 09, 12), 18, 25, 15);
            Tercerizada Tercerizada10 = new Tercerizada(Proveedor4, false, new DateTime(2024, 10, 12), "ActTercerizada10", "Descripcion tercerizada 10", new DateTime(2023, 10, 12), 18, 45, 15);
            Tercerizada Tercerizada11 = new Tercerizada(Proveedor4, false, new DateTime(2024, 11, 12), "ActTercerizada11", "Descripcion tercerizada 11", new DateTime(2023, 11, 12), 10, 55, 10);
            Tercerizada Tercerizada12 = new Tercerizada(Proveedor4, false, new DateTime(2024, 12, 12), "ActTercerizada12", "Descripcion tercerizada 12", new DateTime(2023, 12, 12), 10, 24, 20);
            Tercerizada Tercerizada13 = new Tercerizada(Proveedor5, false, new DateTime(2024, 01, 12), "ActTercerizada13", "Descripcion tercerizada 13", new DateTime(2023, 01, 12), 12, 26, 20);
            Tercerizada Tercerizada14 = new Tercerizada(Proveedor5, false, new DateTime(2024, 02, 12), "ActTercerizada14", "Descripcion tercerizada 14", new DateTime(2023, 02, 12), 8, 65, 5);
            Tercerizada Tercerizada15 = new Tercerizada(Proveedor5, false, new DateTime(2024, 03, 12), "ActTercerizada15", "Descripcion tercerizada 15", new DateTime(2023, 03, 12), 12, 10, 2);

        }




    }
}

