using SampleGridProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SampleGridProject.Repository
{
    public interface IProductRepository
    {
        public IList<MonitorModel> GetMonitors();
    }
}