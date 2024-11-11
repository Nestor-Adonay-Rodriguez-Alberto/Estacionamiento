using Api_RESTFul.Models;

namespace Api_RESTFul.Servicios
{
    public abstract class Descuentos
    {
        // METODO 1: Por Horas
        public static void PorHoras(AlquilerEstacionamiento alquilerEstacionamiento)
        {
            decimal? Total = alquilerEstacionamiento.Horas * alquilerEstacionamiento.Total;

            alquilerEstacionamiento.Total = (decimal)Total;
        }

        // METODO 2: Media Jornada:
        public static void Media_Jornada(AlquilerEstacionamiento alquilerEstacionamiento)
        {
            decimal Descuento = alquilerEstacionamiento.Total * 5 / 100;

            alquilerEstacionamiento.Total = alquilerEstacionamiento.Total - Descuento;
        }

        // METODO 2: Media Jornada:
        public static void Jornada_Completa(AlquilerEstacionamiento alquilerEstacionamiento)
        {
            decimal Descuento = alquilerEstacionamiento.Total * 10 / 100;

            alquilerEstacionamiento.Total = alquilerEstacionamiento.Total - Descuento;
        }
    }
}
