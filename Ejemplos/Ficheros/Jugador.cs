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


        internal void FromLineaCsv(int i, LectorCsv lector)
        {
            this.Id = lector[i, "playerID"];
            this.Nombre = lector[i, "nameFirst"];
            this.Apellido = lector[i, "nameLast"];
            this.Apodo = lector[i, "nameGiven"];

            int altura;
            if (int.TryParse(lector[i, "height"],out altura))
            {
                this.Altura = altura;
            }

            int año,mes,dia;
            if (int.TryParse(lector[i, "birthYear"], out año) && int.TryParse(lector[i, "birthMonth"], out mes) && int.TryParse(lector[i, "birthDay"], out dia))
            {
                this.FechaNacimiento = new DateTime(año, mes, dia);
            }

            this.CiudadNacimiento = lector[i, "birthCity"];

            int peso;
            if (int.TryParse(lector[i, "weight"], out peso))
            {
                this.Peso = peso;
            }
            
            this.Bateador = (lector[i, "bats"] == "R") ? Destreza.Diestro : Destreza.Zurdo;
            this.Lanzador = (lector[i, "throws"] == "R") ? Destreza.Diestro : Destreza.Zurdo;
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
