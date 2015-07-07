namespace SpectroWebApplication.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public partial class PostRevision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int PostID { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Post Post { get; set; }
    }

    /*public class PostRevisionContext : DbContext
    {
        public PostRevisionContext(): base("DefaultConnection")
        {
        }
    }*/
}
