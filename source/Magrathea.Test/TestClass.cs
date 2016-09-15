using NUnit.Framework;
using Magrathea.Data;

namespace Magrathea.Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void DataRepository()
        {
            var dbContext = new BlogContext();

            var repository = new Repository(dbContext);

            var blog = repository.Find(new BlogByName("Jay's Blog"));

            var blogs = repository.Find(new BlogsByName("Jay's Blog"));

        }

    }
}
