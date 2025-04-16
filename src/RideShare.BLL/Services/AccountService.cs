using RideShare.BLL.Dtos.Account;
using RideShare.BLL.Interfaces;
using RideShare.DAL.Configuration;
using RideShare.DAL.Interfaces;
using RideShare.DAL.Models;

namespace RideShare.BLL.Services;

internal class AccountService(IUserRepository _userRepository, IRoleRepository _roleRepository,
    IPasswordHasher _passwordHasher, IJwtTokenGenerator _jwtTokenGenerator) : IAccountService
{
    public async Task<string> LoginUserAsync(UserLoginDto entity)
    {
        var user = await _userRepository.GetUserByCriteriaAsync(x => x.Email == entity.Email);

        if (user == null)
            throw new ArgumentException("Couldn't find an user with this email");

        if (!_passwordHasher.Verify(user.PasswordHash, entity.Password))
            throw new UnauthorizedAccessException("Password is incorrect");

        return _jwtTokenGenerator.GenerateToken(user);
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
}
