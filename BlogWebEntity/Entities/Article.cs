using BlogWebCore.Entities;

namespace BlogWebEntity.Entities
{
    public class Article: EntitiyBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public Category Category { get; set; }
    }
}
