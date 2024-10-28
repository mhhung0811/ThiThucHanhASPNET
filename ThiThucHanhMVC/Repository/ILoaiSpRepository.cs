using ThiThucHanhMVC.Models;
namespace ThiThucHanhMVC.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiRauCu Add(TLoaiRauCu loaiSp);
        TLoaiRauCu Update(TLoaiRauCu loaiSp);
        TLoaiRauCu Delete(string maloaiSp);
        TLoaiRauCu GetLoaiSp(string maloaiSp);
        IEnumerable<TLoaiRauCu> GetAllLoaiSp();

    }
}
