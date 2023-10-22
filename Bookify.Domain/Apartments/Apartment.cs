using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments.Events;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments;

public sealed class Apartment: Entity
{
    private Apartment(Guid id, Name name, Description description, Address address, Money price, Money cleaningFee, DateTime? lastBookedOnUtc) : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        LastBookedOnUtc = lastBookedOnUtc;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc{ get; internal set; }
    
    public List<Amenity> Amenities { get; private set; } = new();
    
    public static Apartment Create(Name name, Description description, Address address, Money price, Money cleaningFee, DateTime? lastBookedOnUtc)
    {
        var apartment = new Apartment(Guid.NewGuid(),name, description, address,  price,  cleaningFee, lastBookedOnUtc);

        apartment.RaiseDomainEvent(new ApartmentCreatedDomainEvent(apartment.Id));
        
        return apartment;
    } 
}