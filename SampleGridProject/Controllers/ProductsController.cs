using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SampleGridProject.Models;
using SampleGridProject.Repository;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SampleGridProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _memoryCache;
        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository, IMemoryCache memoryCache)
        {
            _logger = logger;
            _productRepository = productRepository;
            _memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Monitor(MonitorViewModel monitorViewModel)
        {
            _memoryCache.TryGetValue("MonitorsList", out List<MonitorModel> monitors);
            if (monitors == null)
            {
                monitorViewModel = new MonitorViewModel
                {
                    Monitors = new List<MonitorModel>()
                };
                monitorViewModel.Monitors = _productRepository.GetMonitors();
                _memoryCache.Set("MonitorsList", monitorViewModel.Monitors);
            }
            else
            {
                //check if the items have changed
                if (monitorViewModel.SelectedMonitor == null)
                {
                    _memoryCache.TryGetValue("ModifiedItem", out MonitorModel modifiedMonitor);
                    if (modifiedMonitor != null)
                    {
                        if (modifiedMonitor.MonitorId != null)
                        {
                            var index = monitors.FindIndex(i => i.MonitorId == modifiedMonitor.MonitorId);
                            monitors[index] = modifiedMonitor;
                        }
                        //adding a new monitor
                        else
                        {
                            if(modifiedMonitor.Description!=null&& modifiedMonitor.Name != null&& modifiedMonitor.Price != null&& modifiedMonitor.Quantity != null)
                            {
                                modifiedMonitor.MonitorId = $"MonitorId{monitors.Count + 1}";
                                monitors.Add(modifiedMonitor);
                            }
                            else
                            {
                                
                            }
                        }
                    }
                   

                    _memoryCache.Set("MonitorsList", monitors);
                    monitorViewModel.Monitors = monitors;
                }


            }


            return View("~/Views/Products/Monitor.cshtml", monitorViewModel);
        }
        public IActionResult AddItem(MonitorViewModel monitor)
        {

            return RedirectToAction("Monitor");

        }
        public IActionResult SaveDetails(MonitorViewModel monitor)
        {
            _memoryCache.Set("ModifiedItem", monitor.SelectedMonitor);
            return RedirectToAction("Monitor");
        }
    }
}
