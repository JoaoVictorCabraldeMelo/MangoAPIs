using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utilities;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _service;
        public CouponService(IBaseService service)
        {
            _service = service;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _service.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponApiBase+$"/api/coupon",
                Data = couponDTO
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(Guid? id)
        {
            return await _service.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponApiBase + $"/api/coupon/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _service.SendAsync(new RequestDTO()
            { 
                ApiType=Utilities.SD.ApiType.GET,
                Url=SD.CouponApiBase+"/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _service.SendAsync(new RequestDTO()
            {
                ApiType = Utilities.SD.ApiType.GET,
                Url = SD.CouponApiBase+$"/api/coupon/GetByCode/{couponCode}",

            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(Guid id)
        {
            return await _service.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase+$"/api/coupon/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _service.SendAsync(new RequestDTO() { 
                ApiType = SD.ApiType.PUT, 
                Url = SD.CouponApiBase+$"/api/coupon", 
                Data = couponDTO 
            });
        }
    }
}
