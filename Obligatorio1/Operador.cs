using System;
namespace Dominio
{
	public class Operador : Usuario
	{
		public Operador()
		{
		}
        public Operador(string email, string contrasenia) : base(email, contrasenia)
        {
        }
    }
}

