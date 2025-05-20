using TinyGameStore.Data;

namespace TinyGameStore.InMemory
{
    public static class InMemoryDb
    {
        private static List<User> Users { get; set; } = new List<User>()
        {
            new User() { Username = "admin", Password = "admin" },
            new User() { Username = "user1", Password = "pass1" },
        };

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static User Authenticate(User user)
        {
            foreach (var u in Users)
            {
                if (u.Username == user.Username && u.Password == user.Password)
                {
                    return u;
                }
            }
            return null;
        }
    }
}
