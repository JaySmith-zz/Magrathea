using System.Linq;

namespace Magrathea.Test
{
    public class BlogsByName : Query<Blog>
    {
        public BlogsByName(string name)
        {
            ContextQuery = c => c.AsQueryable<Blog>().Where(x => x.BLOG_NAME == name);
        }
    }

}
