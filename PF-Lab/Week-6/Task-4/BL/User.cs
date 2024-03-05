using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class User
    {
        private string Name;
        private List<Post> Posts;
        private List<User> Followers;
        private List<User> Following;
        public User(string name)
        {
            Name = name;
            Posts = new List<Post>();
            Followers = new List<User>();
            Following = new List<User>();
        }
        public void FollowUser(User user)
        {
            Following.Add(user);
            user.Followers.Add(this);   // Add this user to the followers list of the user being followed
        }
        public void ViewFollowers()
        {
            foreach (User follower in Followers)
            {
                Console.WriteLine(follower.Name);
            }
        }
        public void ViewFollowing()
        {
            foreach (User following in Following)
            {
                Console.WriteLine(following.Name);
            }
        }
        public void ViewPosts()
        {
            foreach (Post post in Posts)
            {
                Console.WriteLine($"Likes: {post.GetLikes()}");
                Console.WriteLine($"Comments:\n{post.GetComments()}");
            }
        }
        public void AddPost(Post post)
        {
            Posts.Add(post);
        }
    }
}
