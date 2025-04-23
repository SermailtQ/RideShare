namespace RideShare.BLL.Dtos.Account
{
    public record JwtTokenDto(
        string Token,
        string RefreshToken
        );
}
