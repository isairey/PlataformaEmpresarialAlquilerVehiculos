using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres;

public static class AlquilerErrors
{
    public static Error NotFound = new Error(
      "Alquiler.Found",
      "El alquiler con el id especificado no fue encontrado"
    );

    public static Error Overlap = new Error(
      "Alquiler.Overlap",
      "El Alquiler esta siendo tomado por 2 o mas clientes al mismo tiempo en la misma fecha"
    );

    public static Error NotReserved = new Error(
      "Alquiler.NotReserved",
      "El alquiler no esta reservado"
    );

    public static Error NotConfirmed = new Error(
      "Alquiler.NotConfirmed",
      "El alquiler no esta confirmado"
    );

    public static Error AlreadyStarted = new Error(
      "Alquiler.AlreadyStarted",
      "El alquiler ya ha comenzado"
    );
}