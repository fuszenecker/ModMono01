namespace MainApi.Mappings;

using Domain.Entities;

internal static class UserMapper
{
    extension(User user)
    {
        public User ToDto()
        {
            return user;
        }
    }
} 