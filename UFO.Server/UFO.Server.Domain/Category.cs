using System;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class Category
    {
        public const int InvalidCategoryId = int.MinValue;

        public int CategoryId { get; set; } = InvalidCategoryId;

        public string Name { get; set; }
    }
}
