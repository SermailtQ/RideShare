using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RideShare.BLL.Dtos.Account;
using RideShare.BLL.Interfaces;
using RideShare.DAL.Configuration;
using RideShare.DAL.Interfaces;
using RideShare.DAL.Models;
using RideShare.DAL.Models.User;

namespace RideShare.BLL.Services;

internal class AccountService(IUserRepository _userRepository, IRoleRepository _roleRepository,
    IPasswordHasher _passwordHasher, IJwtTokenService _jwtTokenGenerator, 
    IRefreshTokenRepository _refreshTokenRepository, IHttpContextAccessor _httpContextAccessor) : IAccountService
{
    public async Task<JwtTokenDto> LoginUserAsync(UserLoginDto entity)
    {
        var user = await _userRepository.GetUserByCriteriaAsync(x => x.Email == entity.Email);

        if (user == null)
            throw new ArgumentException("Couldn't find an user with this email");

        if (!_passwordHasher.Verify(user.PasswordHash, entity.Password))
            throw new UnauthorizedAccessException("Password is incorrect");

        var token = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        var refreshTokenEntity = new UserRefreshToken
        {
            User = user,
            RefreshToken = refreshToken,
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
        };

        try
        {
            await _refreshTokenRepository.AddUserRefreshTokens(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();
        }
        catch
        {
            throw new ArgumentNullException("An error occured on the server, please try later");
        }

        var returnResult = new JwtTokenDto(token, refreshToken);

        return returnResult;
    }

    public async Task RegisterUserAsync(RegisterUserDto entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Data was null");

        if (await _userRepository.IsUsernameInUseAsync(entity.Username))
            throw new ArgumentException("Username is already in use");

        if (await _userRepository.IsEmailInUseAsync(entity.Email))
            throw new ArgumentException("Email is already in use");

        if (await _userRepository.IsPhoneInUseAsync(entity.PhoneNumber))
            throw new ArgumentException("Phone Number is already in use");

        try
        {
            var rolesToAdd = new List<UserRoleEntity> { await _roleRepository.GetByNameAsync(RolesSeedConstants.PassagerRoleName) };

            var userToAdd = new UserEntity
            {
                Firstname = entity.FirstName,
                Lastname = entity.LastName,
                Email = entity.Email,
                Phone = entity.PhoneNumber,
                Username = entity.Username,
                PasswordHash = _passwordHasher.Hash(entity.Password),
                Roles = rolesToAdd,
                Birthdate = entity.BirthDate,
            };

            await _userRepository.AddUserAsync(userToAdd);

            if (!await _userRepository.SaveChangesAsync())
                throw new Exception("Error while saving changes");

        }
        catch
        {
            throw new ArgumentNullException("An error occured on the server, please try later");
        }
    }

    public async Task<JwtTokenDto> RefreshToken(string refreshToken)
    {
        var refreshTokenEntity = await _refreshTokenRepository.GetRefreshTokensForUser(refreshToken);

        if (refreshTokenEntity == null || refreshTokenEntity.ExpiresOnUtc < DateTime.UtcNow)
            throw new ApplicationException("Refresh token has expired");

        string accessToken = _jwtTokenGenerator.GenerateToken(refreshTokenEntity.User);

        refreshTokenEntity.RefreshToken = _jwtTokenGenerator.GenerateRefreshToken();
        refreshTokenEntity.ExpiresOnUtc = DateTime.UtcNow.AddDays(7);

        await _refreshTokenRepository.SaveChangesAsync();

        return new JwtTokenDto(accessToken, refreshTokenEntity.RefreshToken);
    }

    public async Task RevokeRefreshTokens(Guid? UserId)
    {
        var userEntity = await _userRepository.GetUserByCriteriaAsync(x => x.Id == UserId);

        if (userEntity == null)
            throw new ArgumentException("Couldn't find an user with this email");

        if (userEntity.Id != GetCurrentUserID())
            throw new UnauthorizedAccessException("You are not authorized to revoke the tokens for this user");
        
        await _refreshTokenRepository.RemoveUserRefreshTokens(userEntity.Id);

        await _refreshTokenRepository.SaveChangesAsync();
    }


    private Guid? GetCurrentUserID()
    {
        return Guid.TryParse(
            _httpContextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Sub),
            out Guid parsed) ? parsed : null;
    }
}
