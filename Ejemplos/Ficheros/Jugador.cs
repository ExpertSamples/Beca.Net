using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Ficheros
{
    public enum Destreza
    {
        Diestro,
        Zurdo
    }

    public class Jugador
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Apodo { get; set; }
        public int Altura { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public int Peso { get; set; }
        public Destreza Bateador { get; set; }
        public Destreza Lanzador { get; set; }

        public void FromString(string linea)
        {
            string[] elementos = linea.Split(',');

            this.Id = elementos[0];
            this.Nombre = elementos[13];
            this.Apellido = elementos[14];
            this.Apodo = elementos[15];
            this.Altura = int.Parse(elementos[17]);
            this.FechaNacimiento = new DateTime(int.Parse(elementos[1]), int.Parse(elementos[2]), int.Parse(elementos[3]));
            this.CiudadNacimiento = elementos[6];
            this.Peso = int.Parse(elementos[16]);
            this.Bateador = (elementos[18] == "R") ? Destreza.Diestro : Destreza.Zurdo;
            this.Lanzador = (elementos[19] == "R") ? Destreza.Diestro : Destreza.Zurdo;

        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
