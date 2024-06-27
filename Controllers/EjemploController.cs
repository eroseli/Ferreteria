using Api_Web_Ejemplo.Controllers.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.IO;

namespace Api_Web_Ejemplo.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class EjemploController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EjemploController(IConfiguration configuration) { 
            _configuration = configuration;
        }


        [HttpGet("GetUser")]
        public IActionResult GetEjemplo(IConfiguration configuration) {

            var user = new User { userName= "Eros", password = "passsword" };

            user.userName = _configuration["ConfiguracionPrueba:configuracion1"];

            return Ok(user);

        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct() { 
        
            var producto = new Product{  Id = 1, Name ="Procesador", Description = "Intel", Category= "Procesamiento" }; 

            return Ok(producto);

        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts() {

            List<Product> arreglo = new List<Product>();

            arreglo.Add(new Product { Id = 1, Name = "Procesador", Description = "Intel", Category = "Procesamiento" });
            arreglo.Add(new Product { Id = 2, Name = "Procesador", Description = "AMD", Category = "Procesamiento" });
            arreglo.Add(new Product { Id = 3, Name = "Procesador", Description = "M1", Category = "Procesamiento" });
            
            return arreglo;

        }

        [HttpGet("Getnames")]
        public IEnumerable<string> getNames()
        {

            string[] nombres = { "Eros", "Miguel", "Jonathan"};

            return nombres; 

        }

        [HttpGet("GetObjects")]
        public IEnumerable<Object> getObjects()
        {
            Object[] objetos = { "", 1, 2, null };


            return objetos;

        }

        [HttpGet("GetDictionary")]
        public IEnumerable<KeyValuePair<String,int>> getDictionary() {

            Dictionary<string, int> diccionario = new Dictionary<string, int>();

            diccionario.Add("Cadena1", 1);
            diccionario.Add("Cadena2",2);
            diccionario.Add("Cadena3", 3);
            diccionario.Add("Cadena4", 4);

            return diccionario;
            
        }

        [HttpGet("GetUserSelected")]
        public ActionResult GetUserSelected() { 
        
            User user = new User { password = "eros", userName = "eros" };

            //return Ok(user);
            return new ObjectResult(user){
                StatusCode = 200
            };

        }

        [HttpGet("GetUsersSelected")]
        public ActionResult GetUsersSelected() {

            List<User> users = new List<User> { new User { password = "eros", userName = "eros" }, new User { password = "daniel", userName = "daniel" } };

            return new ObjectResult(users) {
                StatusCode = 200
            };

        }

        [HttpGet("GetPDF")]
        public IActionResult GetPDF() {

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\DESARROLLO4\\Documents", "Documentacion.pdf");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            byte[] pdfBytes = System.IO.File.ReadAllBytes(filePath);
            return File(pdfBytes, "application/pdf", "Documentacion.pdf");

        }

        [HttpGet("GetImage")]
        public IActionResult GetImage() {

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\DESARROLLO4\\Documents", "Halo.jpg");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
            return File(imageBytes, "image/jpeg", "Halo.jpg");

        }

        [HttpGet("GetSong")]
        public IActionResult GetSong() {

            // Ruta del archivo de audio (en este ejemplo, se asume que está en el directorio wwwroot)
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\DESARROLLO4\\Documents", "song.mp3");

            // Verificar si el archivo de audio existe
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // Leer el contenido del archivo de audio
            byte[] audioBytes = System.IO.File.ReadAllBytes(filePath);

            // Devolver el archivo de audio como FileContentResult
            return File(audioBytes, "audio/mpeg", "song.mp3");

        }

        [HttpGet("LambdaListas")]
        public IEnumerable GetListFilter()
        {
            List<string> nombres  = new List<string> { "Eros","Eliel", "Damian", "Ferminio", "Leopoldo" };

            var listafiltrada = nombres.Where(nombre => nombre.Contains("r"));

            return listafiltrada;

        }

        [HttpGet("LambdaListObjets")]
        public IEnumerable GetObjectFomater()
        {
            List<Object> objetos = new List<object> { 1, 2, "Eros", "Damian", "Oaxaca", 1.3, "San Miguel", "Estados Unidos" };

            //var objectListFilter = objetos.Where(objeto => objeto is string).Select(objeto => objeto.ToString());
            var objectListFilter = objetos.Where(objeto =>  !(objeto is string )).Select(objeto => objeto);

            return objectListFilter;
        }

        [HttpGet("GetListStudents")]
        public IActionResult getListStudents()
        {

            List<Student> listaEstudiantes = new List<Student> { 
                new Student{  Id = 1,Edad= 25, Nombre = "Eros", Apaterno = "Roque", Amaterno = "Santiago", Carrera = "Informática", calificaciones = new List<float>{ 10,9,8,10,10 } },
                new Student{  Id = 2,Edad= 18, Nombre = "Dario", Apaterno = "salazar", Amaterno = "Sanchez", Carrera = "Ingeniería Civil", calificaciones = new List<float>{ 10,9,8,7,7 } },
                new Student{  Id = 3,Edad= 24, Nombre = "Emanuel", Apaterno = "Sonora", Amaterno = "Ramirez", Carrera = "Ingeniería Industrial", calificaciones = new List<float>{ 10,5,8,7,9 } },
                new Student{  Id = 4,Edad= 29, Nombre = "Enriqueta", Apaterno = "Marquez", Amaterno = "Rodriguez", Carrera = "Ingeniería Ambiental", calificaciones = new List<float>{ 0,9,0,7,7 } },
                new Student{  Id = 5,Edad= 24, Nombre = "Espianishi", Apaterno = "Jimenez", Amaterno = "Avendaño", Carrera = "Administración de Empresas", calificaciones = new List<float>{ 10,9,10,10,10 } },
                new Student{  Id = 6,Edad= 24, Nombre = "Yair Enrique", Apaterno = "Pacheco", Amaterno = "Mirinda", Carrera = "Ingeniero Agrónomo", calificaciones = new List<float>{ 10,9,8,7,0 } },
                new Student{  Id = 7,Edad= 22, Nombre = "Trinidad", Apaterno = "Leon", Amaterno = "Escarcega", Carrera = "Informática", calificaciones = new List<float>{ 10,9,10,7,10 } },
                new Student{  Id = 8,Edad= 25, Nombre = "Laura", Apaterno = "jimenez", Amaterno = "Costa", Carrera = "Informática", calificaciones = new List<float>{ 5,9,0,10,10 } },
            };


            //Presentar a estudiantes de informatica que tienen mas de 20 años
            var liststudentsSeniors = listaEstudiantes
                .Where(estudiante => estudiante.Edad >= 25 && estudiante.Carrera == "Informática")
                .Select(estudiante => estudiante);

            //obtener promedio de los alumnos de la carrera de informatica
            var listaStudiantespromedioInformatica = listaEstudiantes
                .Where(estudiante => estudiante.Carrera == "Informática")
                .Select(estudiante => new
                {
                    Nombre = estudiante.Nombre,
                    Carrera = estudiante.Carrera,
                    Promedio = estudiante.calificaciones.Average()
                });

            //Agrupar a estudiantes por la carrera 
            var listaEstudiantesPorCarrera = listaEstudiantes
                .GroupBy(estudiante => estudiante.Carrera)
                .Select(estudiante => new { 
                    Carrera =  estudiante.Key,
                    Cantidad = estudiante.Count()
                });


            List<Object> listaCompleta = new List<object> { liststudentsSeniors,listaStudiantespromedioInformatica, listaEstudiantesPorCarrera };


            return Ok(listaCompleta);

        }

        [HttpGet("GetListStudentsOk")]
        public IEnumerable getListOnlyStudents()
        {
            List<string> liststudents = new List<string> { "Eros","Daniel","Salazar" };

            return liststudents;
        }


        [HttpGet("LambdaDivision")]
        public IActionResult GetLambda() {

            float resultado = dividir(5, 3);

            return Ok(new{
                resultado = resultado    
            });   

        }
        Func<int, int, float> dividir = (x, y) => x / y;

        [HttpGet("Tree")]
        public ActionResult<TreeNode<string>> getTree() {

            TreeNode<int> root = new TreeNode<int>(1);
            root.Children.Add(new TreeNode<int>(2));
            root.Children.Add(new TreeNode<int>(2));

            TreeNode<int> child = new TreeNode<int>(3);

            root.Children[0].Children.Add(child);
            child = new TreeNode<int>(3);
            root.Children[0].Children.Add(child);

            child = new TreeNode<int>(3);
            root.Children[1].Children.Add(child);
            
            child = new TreeNode<int>(4);
            root.Children[0].Children[0].Children.Add(child);
            return Ok(root);

        }

    }
}
