using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgregandoModificar
{
    public class Cliente
    {
        public int Numero { get; set; }
        public decimal Precio { get; set; }
        public string Nombre { get; set; }

        public Cliente()
        {

        }

        public Cliente(string linea)
        {
            string[] datos;
            
            datos=linea.Split(';');

            Numero = Convert.ToInt32(datos[0]);
            Precio = Convert.ToDecimal(datos[1]);
            Nombre = datos[2];

        }

        public string GenerarRegistro()
        {
            return $"{Numero};{Precio};{Nombre}";
        }

        public override string ToString()
        {
            return $"{Numero} {Precio} {Nombre}"; 
        }

    }
}
