using System;
namespace Dominio
{
	public class Operador : Usuario, IValidable
    {
		public Operador()
		{
		}
        public Operador(string email, string contrasenia) : base(email, contrasenia)
        {
        }
    }
}

