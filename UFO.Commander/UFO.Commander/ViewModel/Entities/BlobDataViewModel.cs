using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class BlobDataViewModel : BlobData
    {
        public override string Name { get; set; }
        public override string Path { get; set; }
        public override byte[] DataStream { get; set; }
    }
}
