using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThiThucHanhMVC.Models;
using ThiThucHanhMVC.ViewModels;
using X.PagedList;

namespace ThiThucHanhMVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanRauCuContext db =new QlbanRauCuContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucRauCus.AsNoTracking().OrderBy(x => x.TenRauCu);
            PagedList<TDanhMucRauCu> lst = new PagedList<TDanhMucRauCu>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucRauCu sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucRauCus.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            
            var sanPham = db.TDanhMucRauCus.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucRauCu sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietRauCus.Where(x => x.MaRauCu == maSanPham).ToList();
            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";

                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            
            db.Remove(db.TDanhMucRauCus.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";

            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

        [Route("ChiTiet")]
        [HttpGet]
        public IActionResult ChiTiet(string maSp)
        {

            var sanPham = db.TDanhMucRauCus.SingleOrDefault(x => x.MaRauCu == maSp);
            var chiTietSanPham = db.TChiTietRauCus.SingleOrDefault(x => x.MaRauCu == maSp);
            var anhSanPham = db.TDanhMucRauCus.Where(x => x.MaRauCu == maSp).ToList();
            var homeSanPhamChiTietViewModel = new HomeSanPhamChiTietViewModel
            {
                danhMucSp = sanPham,
                chiTietRauCu = chiTietSanPham,
            };
            return View(homeSanPhamChiTietViewModel);
        }

        [Route("quanlynguoidung")]
        public IActionResult QuanLyNguoiDung(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttaikhoan = db.TUsers.AsNoTracking().OrderBy(x => x.Username);
            PagedList<TUser> lst = new PagedList<TUser>(lsttaikhoan, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemTaiKhoan")]
        [HttpGet]
        public IActionResult ThemTaiKhoan()
        {
            return View();
        }
        [Route("ThemTaiKhoan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemTaiKhoan(TUser taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TUsers.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung");
            }
            return View(taiKhoan);
        }

        [Route("SuaTaiKhoan")]
        [HttpGet]
        public IActionResult SuaTaiKhoan(string maTaiKhoan)
        {

            var taiKhoan = db.TUsers.Find(maTaiKhoan);
            return View(taiKhoan);
        }
        [Route("SuaTaiKhoan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaTaiKhoan(TUser taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung", "HomeAdmin");
            }
            return View(taiKhoan);
        }

        [Route("XoaTaiKhoan")]
        [HttpGet]
        public IActionResult XoaTaiKhoan(string maTaiKhoan)
        {
            TempData["Message"] = "";
            var taiKhoan = db.TUsers.Where(x => x.Username == maTaiKhoan).ToList();
            if (taiKhoan.Count() > 0)
            {
                TempData["Message"] = "Không xóa được tài khoản này";

                return RedirectToAction("QuanLyNguoiDung", "HomeAdmin");
            }

            db.Remove(db.TDanhMucRauCus.Find(maTaiKhoan));
            db.SaveChanges();
            TempData["Message"] = "Tài khoản đã được xóa";

            return RedirectToAction("QuanLyNguoiDung", "HomeAdmin");
        }
    }
}
