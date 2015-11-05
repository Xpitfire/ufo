using System;

namespace UFO.Server.Domain
{
    [Serializable]
    public class Category
    {
        public const int InvalidCategoryId = int.MinValue;

        public int CategoryId { get; set; } = InvalidCategoryId;

        public string Name { get; set; }
    }
}
