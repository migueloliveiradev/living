using living_backend.Database;
using living_backend.Models.Users;
using living_backend.Shared.Password;
using Microsoft.EntityFrameworkCore;

namespace living_backend.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext context;
    public UserRepository(DatabaseContext context)
    {
        this.context = context;
    }
    public bool CheckEmailExists(string email)
    {
        return context.Users.Any(u => u.Email == email);
    }

    public bool CheckIfUserExists(string userNameOrEmail)
    {
        throw new NotImplementedException();
    }

    public bool CheckPassword(string password, string hashedPassword)
    {
        return Hash.Check(password, hashedPassword);
    }

    public bool CheckPasswordUser(string password, int user_id)
    {
        return context.Users.Any(u => u.Id == user_id && Hash.Check(password, u.Password));
    }

    public bool CheckUsernameExists(string username)
    {
        return context.Users.Any(u => u.Username == username);
    }

    public User? CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public void FollowUser(int user_id, int user_id_to_follow)
    {
        context.UserFollows.Add(new UserFollow
        {
            FollowerId = user_id,
            FollowingId = user_id_to_follow,
            CreatedAt = DateTime.Now
        });
        context.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return context.Users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(int id)
    {
        return context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
        return context.Users.FirstOrDefault(u => u.Username == username);
    }

    public User? GetUserByUsernameOrEmail(string usernameOrEmail)
    {
        return context.Users.FirstOrDefault(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
    }

    public void UnfollowUser(int user_id, int user_id_to_unfollow)
    {
        context.UserFollows.Where(uf => uf.FollowerId == user_id && uf.FollowingId == user_id_to_unfollow).ExecuteDelete();
    }

    public User? UpdateUser(User user)
    {
        context.Users.Update(user);
        context.SaveChanges();
        return user;
    }
}
