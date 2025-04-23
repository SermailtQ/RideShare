using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RideShare.DAL.Context;
using RideShare.DAL.Interfaces;
using RideShare.DAL.Models;

namespace RideShare.DAL.Repositories
{
    internal class UserRepository(AppDbContext _context) : IUserRepository, IDisposable
    {
        public async Task AddUserAsync(UserEntity user) 
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateUserAsync(UserEntity user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<UserEntity?> GetUserByCriteriaAsync(Expression<Func<UserEntity, bool>> expression)
        {
            return await _context.Users.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> IsEmailInUseAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsPhoneInUseAsync(string phone)
        {
            return await _context.Users.AnyAsync(u => u.Phone == phone);
        }

        public async Task<bool> IsUsernameInUseAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 1;
        }
        public async Task<bool> AddRefreshToken(UserEntity user, string refreshToken)
        {
            throw new NotImplementedException();
        }

        #region Dispose Methods

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
