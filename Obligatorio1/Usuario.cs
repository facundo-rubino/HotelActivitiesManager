using System;
namespace Dominio
{
	public abstract class Usuario
	{
		public string Email { get; set; }
		public string Contrasenia { get; set; }

		public Usuario()
		{
		}

        public Usuario(string email, string contrasenia)
        {
			Email = email;
			Contrasenia = contrasenia;
        }

        public virtual void Validar()
        {
            ValidarEmail();
            ValidarContrasenia();
        }

		private void ValidarEmail()
		{
			if (Email.IndexOf("@") == 0 || Email.LastIndexOf("@") == Email.Length - 1)
			{
                throw new Exception("El email ingresado no es válido");
            }
        }

        private void ValidarContrasenia()
        {
            if (Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe tener un mínimo de 8 caracteres");
            }
        }
    }
}

