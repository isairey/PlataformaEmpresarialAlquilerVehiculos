using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres.Events;

public sealed record AlquilerRechazadoDomainEvent(Guid Id) : IDomainEvent;