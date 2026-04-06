using Domain.Entities;

namespace ModuleA.DataAccess.Mappings;

internal static class UserMapperExtensions
{
    extension(Entities.User dataAccessUser)
    {
        public User? ToDomainEntity()
        {
            if (dataAccessUser == null)
                return null;

            return new User
            {
                Name = dataAccessUser.Name,
                Age = dataAccessUser.Age,
                Addresses = dataAccessUser.Addresses?.Select(MapToDomainAddress).ToList()
            };
        }
    }

    private static Address MapToDomainAddress(ModuleA.DataAccess.Entities.Address dataAccessAddress)
    {
        return new Address
        {
            Street = dataAccessAddress.Street,
            City = dataAccessAddress.City,
            State = dataAccessAddress.State,
            ZipCode = dataAccessAddress.ZipCode
        };
    }
}