namespace Infrastructure.Model.Interfaces
{
    public interface IUser
    {
        byte[] PasswordHash { get; set; }
        byte[] PasswordSalt { get; set; }
    }
}
