using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Apartments.Events;

public sealed record ApartmentCreatedDomainEvent(Guid ApartmentId): IDomainEvent;