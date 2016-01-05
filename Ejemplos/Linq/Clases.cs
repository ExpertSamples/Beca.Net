using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Linq
{
    public class Equipo
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }

        public Equipo FromLineaCsv(int numeroLinea, LectorCsv lector)
        {
            this.Id = lector[numeroLinea, "teamId"];
            this.Nombre = lector[numeroLinea, "name"];
            this.Año = lector[numeroLinea, "yearId"].ToInt();

            return this;
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }

    public class Aparicion
    {
        public string IdEquipo { get; set; }
        public string IdJugador { get; set; }
        public int Año { get; set; }

        public Aparicion FromLineaCsv(int numeroLinea, LectorCsv lector)
        {
            this.IdEquipo = lector[numeroLinea, "teamId"];
            this.IdJugador = lector[numeroLinea, "playerId"];
            this.Año = lector[numeroLinea, "yearId"].ToInt();

            return this;
        }

        public override string ToString()
        {
            return this.IdEquipo + "-" + this.IdJugador + "." + this.Año.ToString();
        }
    }

    public class Salario
    {
        public string IdEquipo { get; set; }
        public string IdJugador { get; set; }
        public int Año { get; set; }
        public long Cantidad { get; set; }

        public Salario FromLineaCsv(int numeroLinea, LectorCsv lector)
        {
            this.IdEquipo = lector[numeroLinea, "teamId"];
            this.IdJugador = lector[numeroLinea, "playerId"];
            this.Año = lector[numeroLinea, "yearId"].ToInt();
            this.Cantidad = lector[numeroLinea, "salary"].ToLong();

            return this;
        }

        public override string ToString()
        {
            return this.Cantidad.ToString();
        }
    }
}
