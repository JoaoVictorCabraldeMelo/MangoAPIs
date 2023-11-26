using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }


        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? coupons = new();

            ResponseDto? response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess)
            {
                coupons = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(coupons);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDTO couponDTO)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(couponDTO);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Cupom criado com successo!";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response.Message;
                }

            }
            return View(couponDTO);
        }

        public async Task<IActionResult> CouponDelete(Guid id)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                CouponDTO coupon = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
                return View(coupon);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDTO couponDTO)
        {

            ResponseDto? response = await _couponService.DeleteCouponAsync(couponDTO.couponId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cupom Deletado com sucesso!";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            
            return View(couponDTO);
        }
    }
}
