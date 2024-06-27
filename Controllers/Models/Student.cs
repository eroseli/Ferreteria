namespace Api_Web_Ejemplo.Controllers.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Edad { get; set; }
        public string Nombre { get; set; }    
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }

        public string Carrera { get; set; }
        public List<float> calificaciones { get; set; } 

    }
}
