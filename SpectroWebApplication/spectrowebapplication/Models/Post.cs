namespace SpectroWebApplication.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public partial class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<PostRevision> Revisions { get; set; }

        public virtual Account Account { get; set; }
    }
}
