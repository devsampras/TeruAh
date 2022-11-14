namespace Authentication
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1, Username = "peter", Password = "peter123"
            }
        };
        public async Task<bool> Authenticate(string username, string password)
        {
            if (await Task.FromResult(_users.SingleOrDefault(x => x.Username == username && x.Password == password)) != null)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public Task<List<string>> GetUserNames()
        {
            List<string> users = new List<string>();
            foreach(var user in _users)
            {
                users.Add(user.Username);
            }
            return  Task.FromResult(users);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}