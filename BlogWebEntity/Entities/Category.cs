using BlogWebCore.Entities;

namespace BlogWebEntity.Entities
{
    public class Category : EntitiyBase
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public int CategoryId { get; set; }

    }
}
