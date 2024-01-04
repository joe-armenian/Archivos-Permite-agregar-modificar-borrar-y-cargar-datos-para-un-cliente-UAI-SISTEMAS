using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgregandoModificar
{
    public class GestorCliente
    {

        public string Ruta { get; set; }


        public GestorCliente(string ruta)
        {
            Ruta = ruta;
        } 
        
        public void RegistrarCliente(Cliente unCliente)
        {
            FileStream fs = new FileStream(Ruta, FileMode.Append, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(unCliente.GenerarRegistro());
            }
            fs.Close();
        }

        public void EliminarCliente(int numero)
        {
            string output = string.Empty;

            FileStream fs = new FileStream(Ruta,FileMode.OpenOrCreate,FileAccess.Read);

            using (StreamReader sr= new StreamReader(fs)) 
            {
                string linea=sr.ReadLine();

                while (linea!=null)
                {
                    Cliente unCliente = new Cliente(linea);

                    if (unCliente.Numero!=numero)
                    {
                        output += linea + Environment.NewLine;
                    }
                    linea = sr.ReadLine();  
                }

            }
            fs.Close();

            fs = new FileStream(Ruta, FileMode.Truncate, FileAccess.Write);

            using (StreamWriter sw= new StreamWriter(fs))
            {
                sw.Write(output);
            }
            fs.Close();

        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            FileStream fs = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader sr= new StreamReader(fs)) 
            {
              string linea= sr.ReadLine();  

                while (linea!=null)
                {
                    Cliente unCliente = new Cliente(linea);
                    clientes.Add(unCliente);
                    linea = sr.ReadLine();
                }
            }
            fs.Close();


            return clientes;
        }

        public void ModificarCliente(int numero,Cliente unClienteModificado)
        {
            string output = string.Empty;

            FileStream fs = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader sr = new StreamReader(fs))
            {
                string linea = sr.ReadLine();

                while (linea != null)
                {
                    Cliente unCliente = new Cliente(linea);

                    if (unCliente.Numero == numero)
                    {
                        unCliente = unClienteModificado;
                    }

                    output += unCliente.GenerarRegistro() + Environment.NewLine;
                    linea = sr.ReadLine();
                }   

            }
            fs.Close();

            fs = new FileStream(Ruta, FileMode.Truncate, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(output);
            }
            fs.Close();

        }





    }
}
