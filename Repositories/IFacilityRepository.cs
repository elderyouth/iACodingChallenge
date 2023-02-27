using iACodingChallenge.Models;

namespace iACodingChallenge.Repositories
{
	public interface IFacilityRepository
	{
		Task<IEnumerable<Facility>> GetAllFacilitiesAsync();
        Task<IEnumerable<Facility>> GetTopThreeFacilities(int x=0, int y=0);
    }
}
