using NUnit.Framework;

namespace Magrathea.Test
{
    [TestFixture] 

    public class TestClass
    {
        public void DataRepository()
        {
            var dbContext = new BlogContext();

            var repository = new Repository(dbContext);

            var blog = repository.Find(new BlogByName("Jay's Blog"));

            var blogs = repository.Find(new BlogsByName("Jay's Blog"));

        }

        public void AddEntity()
        {
            var dbContext = new BlogContext();

            var repository = new Repository(dbContext);

            var blog = new Blog
            {
                BLOG_NAME =  "New Blog"
            };

            repository.Context.Add(blog);
            repository.Context.Commit();
        }

    }
}
