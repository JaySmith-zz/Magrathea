using System.Linq;

namespace Magrathea.Test
{
    public class BlogByName : Scalar<Blog>
    {
        public BlogByName(string name)
        {
            ContextQuery = c => c.AsQueryable<Blog>().FirstOrDefault(x => x.BLOG_NAME == name);
        }
    }

}
