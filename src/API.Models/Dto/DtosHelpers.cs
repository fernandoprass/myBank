namespace API.Models.Dto
{
    internal static class DtosHelpers
    {
        public static User ToDto(this UserDto result)
        {
            return new User
            {
                Id = result.Id,
                Name = result.Name,
                Surname = result.Surname
            };
        }
    }
}
