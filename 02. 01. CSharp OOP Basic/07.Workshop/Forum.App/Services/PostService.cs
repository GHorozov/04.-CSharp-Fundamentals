namespace Forum.App.Services
{
    using Forum.App.UserInterface.ViewModels;
    using Forum.Data;
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();
            var category = forumData.Categories.Find(x => x.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(x => x.Id == postId);
            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = forumData.Replies.Find(x => x.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();
            var allCategories = forumData.Categories.Select(x => x.Name).ToArray();

            return allCategories;
        }

        internal static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();
            var postIds = forumData.Categories.First(x => x.Id == categoryId).PostIds;
            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(x => x.Id == postId);
            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var catagoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == catagoryName);
            if(category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, catagoryName, new List<int>());
                forumData.Categories.Add(category);
                forumData.SaveChanges();
            }
              
            return category;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if(emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();
            Category category = EnsureCategory(postView, forumData);
            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
            User author = UserService.GetUser(postView.Author); //, forumData
            int authorId = author.Id;
            string content = string.Join("", postView.Content);
           

            Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(postId);
            category.PostIds.Add(postId);
            forumData.SaveChanges();
            postView.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyViewModel, int postId)
        {
            if (!replyViewModel.Content.Any())
            {
                return false;
            }

            ForumData forumData = new ForumData();
            var author = UserService.GetUser(replyViewModel.Author, forumData);
            var post = forumData.Posts.Single(x => x.Id == postId);
            var replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var content = string.Join("", replyViewModel.Content);

            var reply = new Reply(replyId, content, author.Id, postId);
            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();

            return true;
        }
    }
}
