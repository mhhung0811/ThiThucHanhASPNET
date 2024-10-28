using ThiThucHanhMVC.Models;
namespace ThiThucHanhMVC.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QlbanRauCuContext _context;
        public LoaiSpRepository(QlbanRauCuContext context)
        {
            _context = context;
        }
        public TLoaiRauCu Add(TLoaiRauCu loaiSp)
        {
            _context.TLoaiRauCus.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiRauCu Delete(string maloaiSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiRauCu> GetAllLoaiSp()
        {
            return _context.TLoaiRauCus;
        }

        public TLoaiRauCu GetLoaiSp(string maloaiSp)
        {
            return _context.TLoaiRauCus.Find(maloaiSp);
        }

        public TLoaiRauCu Update(TLoaiRauCu loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
