using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews.Events;

public record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;