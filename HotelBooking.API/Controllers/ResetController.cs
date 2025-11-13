namespace HotelBooking.API.Controllers
{
    using HotelBooking.Components.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]/[action]")]
    public class ResetController : ControllerBase
    {
        private readonly IResetService _resetService;

        public ResetController(IResetService resetService)
        {
            _resetService = resetService;
        }

        [HttpPost(Name = "Clear all data")]
        public async Task<bool> ClearData()
        {
            await _resetService.ResetDatabaseAsync();
            return true;
        }

        [HttpPost(Name = "Reseed all data")]
        public async Task<bool> Reseed()
        {
            await _resetService.ReseedDatabaseAsync(6);
            return true;
        }
    }
}
