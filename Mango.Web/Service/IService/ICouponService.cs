using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(Guid id);
        Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDto?> DeleteCouponAsync(Guid? id);
    }
}
