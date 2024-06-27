using Api_Web_Ejemplo.Controllers.Models;
using System.Diagnostics;

namespace Api_Web_Ejemplo.Application.Services
{
    public class ArbolBinario
    {
        public Nodo raiz;
        public List<int> orden;

        public ArbolBinario()
        {
            this.raiz = null;
            this.orden = new List<int>();   
        }

        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        public Nodo InsertarRecursivo(Nodo nodoactual, int valor)
        {
            if (nodoactual == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodoactual.valor) {
                nodoactual.izquierdo = InsertarRecursivo(nodoactual.izquierdo, valor);
            }
            else if (valor > nodoactual.valor)
            {
                nodoactual.derecho = InsertarRecursivo(nodoactual.derecho, valor);
            }

            return nodoactual;

        }

        public List<int> Getinorden() {

            asignarOrden(raiz);

            return orden;
        }

        public void asignarOrden(Nodo nodo)
        {

            if (nodo != null) { 
            
                asignarOrden(nodo.izquierdo);
                orden.Add(nodo.valor);
                asignarOrden(nodo.derecho);
            }

        }

        public List<int> GetPreorden() {

            asignarPreorden(raiz);
            return orden;
        }

        public void asignarPreorden(Nodo nodo)
        {

            if (nodo != null) {

                orden.Add(nodo.valor);
                asignarPreorden(nodo.izquierdo);
                asignarPreorden(nodo.derecho);

            }

        }

        public List<int> GetPostOrden() {

            asignarPostOrden(raiz);
            return orden;

        }

        public void asignarPostOrden(Nodo nodo)
        {

            if ( nodo != null)
            {
                asignarPreorden(nodo.izquierdo);
                asignarPreorden(nodo.derecho);
                orden.Add(nodo.valor);
            }

        }
    



    }
}
