using System.Linq;

namespace Magrathea.Test
{
    public class BlogByName : Scalar<Blog>
    {
        public BlogByName(string name)
        {
            ContextQuery = c => c.AsQueryable<Blog>().FirstOrDefault(x => x.BLOG_NAME == name);
            //ContextQuery = c => c.Set<Blog>().AsQueryable().FirstOrDefault(x => x.BLOG_NAME == name); // AsQueryable<Blog>().FirstOrDefault(x => x.BLOG_NAME == name);
        }
    }

}
