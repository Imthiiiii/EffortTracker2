using EffortTracker.Data;
using EffortTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Context _context;

        public UsersRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(int associate_id)
        {
            return await _context.Users.FindAsync(associate_id);
        }

        public async Task AddUserAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int associate_id)
        {
            var user = await _context.Users.FindAsync(associate_id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
