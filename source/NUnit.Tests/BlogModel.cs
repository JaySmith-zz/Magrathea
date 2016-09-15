namespace NUnit.Tests
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("name=BlogModel")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    //public partial class BlogDbContext
    //{
    //    /// <summary>
    //    ///     This gives a mockable wrapper around the normal <see cref="DbSet{T}" /> method that allows for testablity
    //    ///     This method is now virtual to allow for the injection of cross cutting concerns.
    //    /// </summary>
    //    /// <typeparam name="T">The Entity being queried</typeparam>
    //    /// <returns>
    //    ///     <see cref="IQueryable{T}" />
    //    /// </returns>
    //    public virtual IQueryable<T> AsQueryable<T>() where T : class
    //    {
    //        DbSet<T> result = Set<T>();
    //        return result;
    //    }
    //}
}
