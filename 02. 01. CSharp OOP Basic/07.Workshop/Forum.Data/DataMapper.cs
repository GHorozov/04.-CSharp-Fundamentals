namespace Forum.Data
{
    using System;
    using Forum.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DataMapper
    {
        private const string DataPath = "../../../../data/";
        private const string ConfigPath = "config.ini";
        private const string DefaultConfig = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DataPath);
            config = LoadConfig(DataPath + ConfigPath);
        }

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DefaultConfig);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var content = ReadLines(configPath);

            var config = content
                .Select(l => l.Split("="))
                .ToDictionary(testc => testc[0], t => DataPath + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);

            return lines;
        }


        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        //Categories
        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var name = args[1];
                var postIds = new List<int>();
                if(args.Length > 2)
                {
                    postIds.AddRange( args[2]
                   .Split(',', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray());
                }
                var category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (var category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";
                string line = string.Format(categoryFormat, category.Id, category.Name, string.Join(',', category.PostIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        //LoadUsers, SaveUsers, LoadPosts, SavePosts, LoadReplies, SaveReplies.

        //Users
        public static List<User> LoadUsers()
        {
            var users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var username = args[1];
                var password = args[2];
                var postIds = new List<int>();
                if (args.Length > 3)
                {
                    postIds.AddRange(args[3]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray());
                }
                var user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                const string userFormat = "{0};{1};{2};{3}";
                string line = string.Format(
                    userFormat,
                    user.Id,
                    user.Username,
                    user.Password, 
                    string.Join(',', user.PostIds)
                    );

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        //Posts
        public static List<Post> LoadPosts()
        {
            var posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var title = args[1];
                var content = args[2];
                var categoryId = int.Parse(args[3]);
                var authorId = int.Parse(args[4]);
                var replyIds = new List<int>();
                if (args.Length > 5)
                {
                    replyIds.AddRange(args[5]
                   .Split(',', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray());
                }
                   
                var post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                const string userFormat = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(
                    userFormat,
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(',', post.ReplyIds)
                    );

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        //Replies
        public static List<Reply> LoadReplies()
        {
            var replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = int.Parse(args[2]);
                var postId = int.Parse(args[3]);
                var reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                const string userFormat = "{0};{1};{2};{3}";
                string line = string.Format(
                    userFormat,
                    reply.Id,
                    reply.Content,
                    reply.AuthorId,
                    reply.PostId
                    );

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
