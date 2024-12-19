using PetShop.Models;

namespace PetShop.Logic
{
    public interface IMailLogic
    {
        Task GoiEmail(MailInfo mailInfo);
        Task GoiEmailDatHangThanhCong(DatHang datHang, MailInfo mailInfo);
    }
}
