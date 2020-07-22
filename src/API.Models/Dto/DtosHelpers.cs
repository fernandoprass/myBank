namespace API.Models.Dto
{
    internal static class DtosHelpers
    {
        public static Account ToDto(this AccountDto result)
        {
            return new Account
            {
                Id = result.Id,
                CustomerId = result.CustomerId,
                Balance =  result.Balance,
                CreationDate = result.CreationDate
            };
        }

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
