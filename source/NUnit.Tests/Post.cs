namespace NUnit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [Key]
        public int POST_ID { get; set; }

        [StringLength(200)]
        public string POST_TITLE { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int BLOG_ID { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
