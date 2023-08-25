using living_backend.Models.Users;

namespace living_backend.Repositories.Users;

public interface IUserRepository
{
    User? GetUserById(int id);
    User? GetUserByEmail(string email);
    User? GetUserByUsername(string username);
    User? GetUserByUsernameOrEmail(string usernameOrEmail);
    bool CheckIfUserExists(string userNameOrEmail);
    bool CheckUsernameExists(string username);
    bool CheckEmailExists(string email);
    bool CheckPassword(string password, string hashedPassword);
    bool CheckPassword(string password, int user_id);
    User Create(User user);
    User Update(User user);
    void Follow(int user_id, int user_id_to_follow);
    void Unfollow(int user_id, int user_id_to_unfollow);
    void Delete(int id);

}
