using ThiThucHanhMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ThiThucHanhMVC.Repository;
namespace ThiThucHanhMVC.ViewComponents
{
    public class LoaiSpMenuViewComponent:ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp = _loaiSp.GetAllLoaiSp().OrderBy(x=>x.LoaiRauCu);
            return View(loaiSp);
        }
    }
}
