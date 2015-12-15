using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class CategoryViewModel : Category
    {
        public override string CategoryId { get; set; }
        public override string Name { get; set; }
    }
}
