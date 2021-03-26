using System.Collections.Generic;

namespace SampleGridProject.Models
{
    public class MonitorViewModel
    {
        public IList<MonitorModel> Monitors { get; set; }
        public MonitorModel SelectedMonitor { get; set; }
    }
}
