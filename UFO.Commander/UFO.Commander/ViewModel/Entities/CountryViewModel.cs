using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class CountryViewModel : Country
    {
        public override string Code { get; set; }
        public override string Name { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}
