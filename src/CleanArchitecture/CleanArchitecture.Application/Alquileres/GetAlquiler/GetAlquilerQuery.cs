using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Alquileres.GetAlquiler;

public sealed record GetAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;