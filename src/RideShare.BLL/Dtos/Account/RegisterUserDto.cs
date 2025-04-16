namespace RideShare.BLL.Dtos.Account
{
    public record RegisterUserDto
        (
        string Username,
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        DateOnly BirthDate
        );
}
