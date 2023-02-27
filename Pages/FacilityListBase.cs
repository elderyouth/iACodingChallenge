using iACodingChallenge.Repositories;
using Microsoft.AspNetCore.Components;

namespace iACodingChallenge.Pages
{
	public class FacilityListBase : ComponentBase
	{
		[Inject]
		public IFacilityRepository FacilityRepository { get; set; }
		public int xCoordinate { get; set; } = 0;
		public int yCoordinate { get; set; } = 0;

	}
}
