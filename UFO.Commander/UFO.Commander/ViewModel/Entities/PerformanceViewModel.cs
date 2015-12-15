using System;
using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class PerformanceViewModel : Performance
    {
        public override DateTime DateTime { get; set; }
    }
}
