using Api_Web_Ejemplo.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Web_Ejemplo.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {

        [HttpGet("RecursividadFactorial")]
        public ActionResult GetFactorialNumber(int numero) // Ejercicio basico con recursividad 
        {
            Factorial factorial = new Factorial();

            var valor = factorial.calculafactorial(numero);

            return Ok(valor);

        }


        [HttpGet("arbolBinario")]
        public IActionResult GetArbilBinario([FromBody] List<int> valoresArbol)
        {
            ArbolBinario arbol = new ArbolBinario();

            // Insertar nodos en el árbol
            //arbol.Insertar(50);
            //arbol.Insertar(30);
            //arbol.Insertar(20);
            //arbol.Insertar(40);
            //arbol.Insertar(70);
            //arbol.Insertar(60);
            //arbol.Insertar(80);

            foreach (var item in valoresArbol)
            {
                arbol.Insertar(item);
            }

            return Ok(arbol.GetPostOrden());    

        }
        
    }
}
