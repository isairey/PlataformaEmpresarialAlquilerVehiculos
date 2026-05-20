using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres;

public class PrecioService
{
    public PrecioDetalle CalcularPrecio(Vehiculo vehiculo, DateRange periodo)
    {
        var tipoMoneda = vehiculo.Precio!.TipoMoneda;
        var precioPorPeriodo = new Moneda(periodo.CantidadDias * vehiculo.Precio.Monto, tipoMoneda);

        decimal percentageChange = 0;

        foreach (var accesorio in vehiculo.Accesorios)
        {
            percentageChange += accesorio switch
            {
                Accesorio.AppleCar or Accesorio.AndroidCar => 0.05m,
                Accesorio.AireAcondicionado => 0.01m,
                Accesorio.Mapas => 0.01m,
                _ => 0,
            };
        }

        var accesorioCharges = Moneda.Zero(tipoMoneda);

        if (percentageChange > 0)
        {
            accesorioCharges = new Moneda(precioPorPeriodo.Monto * percentageChange, tipoMoneda);
        }

        var precioTotal = Moneda.Zero(tipoMoneda);

        precioTotal += precioPorPeriodo;

        if (!vehiculo!.Mantenimiento!.IsZero())
        {
            precioTotal += vehiculo.Mantenimiento;
        }

        precioTotal += accesorioCharges;

        return new PrecioDetalle(
            precioPorPeriodo,
            vehiculo.Mantenimiento,
            accesorioCharges,
            precioTotal
        );
    }
}
