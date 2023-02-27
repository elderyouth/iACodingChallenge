using iACodingChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace iACodingChallenge.Controllers
{
	[Route("/api/[controller]")]
	[ApiController]
	public class FacilityController : ControllerBase
	{
		private readonly IFacilityRepository _facilityRepository;
		public FacilityController(IFacilityRepository facilityRepository) {
			_facilityRepository = facilityRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetFacilities()
		{
			try
			{
				var facilities = await _facilityRepository.GetAllFacilitiesAsync();
				if (facilities == null)
				{
					return NotFound();
				}
				return Ok(facilities);
			}
			catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
			
		}

		[HttpGet]
        public async Task<IActionResult> GetTopFacilities(int x, int y)
		{
            try
            {
                var facilities = await _facilityRepository.GetTopThreeFacilities(x, y);
                if (facilities == null)
                {
                    return NotFound();
                }
                return Ok(facilities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}
