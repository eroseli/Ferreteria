namespace Api_Web_Ejemplo.Controllers.Models
{
    public class Nodo
    {
        public int valor {  get; set; } 
        public Nodo izquierdo { get; set; }
        public Nodo derecho { get; set; }


        public Nodo(int valor)
        {
            this.valor = valor;
            this.izquierdo = null;
            this.derecho = null;
        }

    }
}
