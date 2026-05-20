namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos;

public sealed class DireccionResponse
{
    public string? Pais { get; init; }
    public string? Departamento { get; init; }
    public string? Provincia { get; init; }
    public string? Calle { get; set; }
}