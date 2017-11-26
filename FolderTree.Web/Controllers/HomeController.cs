using System.Web.Mvc;
using FolderTree.Core.Workers;

namespace FolderTree.Web.Controllers
{
    public class HomeController : Controller
    {
        HomeWorker _worker = new HomeWorker();
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Title = $"Path: {_worker.GetParentFolderName(id)}";

            var item = _worker.GetCollectionByParentId(id);
            return View(item);
        }

        
    }
}