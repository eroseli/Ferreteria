namespace Api_Web_Ejemplo.Application.Services
{
    public class Factorial
    {

        public int calculafactorial(int valor)
        {
            if (valor == 0 || valor == 1)
            {
                return 1;
            }

            return valor * calculafactorial(valor -1);

        }
    }
}
