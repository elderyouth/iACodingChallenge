using iACodingChallenge.Data;
using iACodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace iACodingChallenge.Repositories
{
	public class FacilityRepository : IFacilityRepository
	{
		private readonly FacilityContext _facilityContext;

		public FacilityRepository(FacilityContext facilityContext) { 
			_facilityContext= facilityContext;
		}

		/// <summary>
        /// Fetch all existing facilities without any previous filtering, use this to test we can retrieve all items in the FacilityDB
        /// </summary>
        /// <returns>List of all Facilities ordered by default</returns>
        public async Task<IEnumerable<Facility>> GetAllFacilitiesAsync()
		{
            return await _facilityContext.Facilities.Include(m => m.Medications)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieve the top 3 facilities ordered by the shortest manhattan distance between their XY coordinates and the parameter coordinates. In addition, it will order the internal list of all medications by price.
        /// </summary>
        /// <param name="x_c">X Coordinate being fed</param>
        /// <param name="y_c">Y Coordinate</param>
        /// <returns>List of 3 facilities</returns>
        public async Task<IEnumerable<Facility>> GetTopThreeFacilities(int x_c, int y_c)
        {
            return await _facilityContext.Facilities.OrderBy(f =>
                Math.Abs(f.FacilityCoordinateX - x_c) + Math.Abs(f.FacilityCoordinateY - y_c)
            ).Include(m => m.Medications.OrderBy(med => med.MedicationPrice)).Take(3)
                .ToListAsync();
        }
    }
}
