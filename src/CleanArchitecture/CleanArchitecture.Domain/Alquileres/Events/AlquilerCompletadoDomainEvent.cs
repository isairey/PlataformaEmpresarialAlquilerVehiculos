using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres.Events;

public record AlquilerCompletadoDomainEvent(Guid AlquilerId) : IDomainEvent;