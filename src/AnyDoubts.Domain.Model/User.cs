namespace AnyDoubts.Domain.Model
{
    public class User : EntityBase
    {   
        public string Username { get; set; }
        
        public User()
        {
        }

        public User(string username)
        {
            Username = username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
    }
}
