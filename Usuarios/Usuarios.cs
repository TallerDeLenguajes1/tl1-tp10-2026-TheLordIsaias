namespace Usuarios{
    public class Usuario{
        public int id{get; set;}
        public string name{get; set;}
        public string username{get; set;}
        public string email{get; set;}
        public Direccion address{get; set;}
    }
    public class Direccion{
        public string street{get; set;}
        public string suite{get; set;}
        public string city{get; set;}
        public string zipcode{get; set;}
        public Geolocalizacion geo{get; set;}
    }
    public class Geolocalizacion
        {
            public string lat{get; set;}
            public string lng{get; set;}
        }
}