using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres.Events;

public sealed record AlquilerReservadoDomainEvent(Guid AlquilerId) : IDomainEvent;