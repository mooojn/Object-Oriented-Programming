using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Post
    {
        private int Likes;
        private List<string> Comments;
        public Post()
        {
            Likes = 0;
            Comments = new List<string>();
        }
        public void SetLike(int like)
        {
            Likes += like;
        }
        public int GetLikes()
        {
            return Likes;
        }
        public void SetComment(string comment)
        {
            Comments.Add(comment);
        }
        public string GetComments()
        {
            string msg = "";
            foreach (string comment in Comments)
            {
                msg += comment + "\n";
            }
            return msg;
        }   
    }
}
