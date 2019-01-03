namespace Forum.App.Services
{
    using Forum.Data;
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using static Forum.App.Controllers.SignUpController;

    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool IsUserExists = forumData.Users.Any(x => x.Username == username && x.Password == password);

            return IsUserExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if(!validUsername || !validPassword)
            {
                return SignUpStatus.DetailError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExist = forumData.Users.Any(x => x.Username == username);

            if (!userAlreadyExist)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username,password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Username == username);

            return user;
        }

        internal static User GetUser(string username, ForumData forumData)
        {
            User user = forumData.Users.Find(u => u.Username == username);

            return user;
        }
    }
}
