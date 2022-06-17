namespace Dissociate.Models
{
    public class TblUserDto
    {
        public TblUserDto(TblUser user)
        {
            IdUser = user.IdUser;
            Password = user.Password;
            Username = user.Username;
            Email = user.Email;
        }

        public int IdUser { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}