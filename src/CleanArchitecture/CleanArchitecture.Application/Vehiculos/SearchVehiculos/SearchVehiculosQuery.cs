using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos;

public sealed record SeachVehiculosQuery(
    DateOnly FechaInicio,
    DateOnly FechaFin
) : IQuery<IReadOnlyList<VehiculoResponse>>;