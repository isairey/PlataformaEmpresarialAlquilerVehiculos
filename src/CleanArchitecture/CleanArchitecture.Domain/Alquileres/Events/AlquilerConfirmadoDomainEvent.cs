using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres.Events;

public sealed record AlquilerConfirmadoDomainEvent(Guid AlquilerId) : IDomainEvent;