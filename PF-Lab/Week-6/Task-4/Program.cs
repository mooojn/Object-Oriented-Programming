using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User User1 = new User("moon");
            User User2 = new User("meera");
            User User3 = new User("saliq");

            Post Post1 = new Post();
            Post1.SetLike(100);
            Post1.SetComment("Good");
            Post1.SetComment("Nice");
            Post1.SetComment("Awesome");

            User1.AddPost(Post1);

            User1.FollowUser(User2);
            User2.FollowUser(User3);
            User3.FollowUser(User1);
            User3.FollowUser(User2);
            
            Console.WriteLine("Followers of User1");
            User1.ViewFollowers();
            
            Console.WriteLine("Followers of User2");
            User2.ViewFollowers();

            Console.WriteLine("Following of User3");
            User3.ViewFollowing();


            Console.WriteLine("Posts of User1");
            User1.ViewPosts();
            Console.ReadKey();
        }
    }
}