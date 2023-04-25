using System;
namespace Dominio
{
	public static class Utilidades
	{
        public static bool StringValido(string valor)
        {
            bool exito = false;
            if (string.IsNullOrEmpty(valor))
            {
                exito = false;
            }
            else
            {
                exito = true;
            }
            return exito;
        }
    }
}

