namespace CleanArchitecture.Domain.Shared;

public record Moneda(decimal Monto, TipoMoneda TipoMoneda)
{
    public static Moneda operator +(Moneda primero, Moneda segundo)
    {
        if (primero.TipoMoneda != segundo.TipoMoneda)
        {
            throw new InvalidOperationException("El tipo de moneda debe ser el mismo");
        }

        return new Moneda(primero.Monto + segundo.Monto, primero.TipoMoneda);
    }

    public static Moneda Zero() => new(0, TipoMoneda.None);

    public static Moneda Zero(TipoMoneda tipoMoneda) => new(0, tipoMoneda);

    public bool IsZero() => this == Zero(TipoMoneda);
}
