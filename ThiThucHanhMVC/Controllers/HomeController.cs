using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThiThucHanhMVC.Models;
using ThiThucHanhMVC.ViewModels;
using X.PagedList;

namespace ThiThucHanhMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlbanRauCuContext db = new QlbanRauCuContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page==null ||page<0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucRauCus.AsNoTracking().OrderBy(x => x.TenRauCu);
            PagedList<TDanhMucRauCu> lst = new PagedList<TDanhMucRauCu>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucRauCus.AsNoTracking().Where(x => x.MaLoaiRauCu == maloai).OrderBy(x => x.TenRauCu);
            PagedList<TDanhMucRauCu> lst = new PagedList<TDanhMucRauCu>(lstsanpham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }
        public IActionResult SanPhamChiTiet(string maSp)
        {
            var sanPham = db.TDanhMucRauCus.SingleOrDefault(x => x.MaRauCu == maSp);
            var chiTietSanPham = db.TChiTietRauCus.SingleOrDefault(x=>x.MaRauCu==maSp);
            var anhSanPham = db.TDanhMucRauCus.Where(x => x.MaRauCu == maSp).ToList();
            var homeSanPhamChiTietViewModel = new HomeSanPhamChiTietViewModel
            {
                danhMucSp = sanPham,
                chiTietRauCu = chiTietSanPham,
            };
            return View(homeSanPhamChiTietViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
