using BlogWebCore.Entities;

namespace BlogWebEntity.Entities
{
    public class Image: EntitiyBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Image> Images { get; set;}

    }
}
