namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos;

public sealed class VehiculoResponse
{
    public Guid Id { get; init; }
    public string? Modelo { get; set; }
    public string? Vin { get; set; }
    public decimal Precio { get; init; }
    public string? TipoMoneda { get; init; }
    public DireccionResponse? Direccion { get; set; }
}