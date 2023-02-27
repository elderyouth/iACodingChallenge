using iACodingChallenge.Models;
using Newtonsoft.Json;
using System.Formats.Asn1;

namespace iACodingChallenge.Data
{
	public class FacilityDataSeeder
	{
		private FacilityContext _facilityContext;
		private const string FACILITY_SEED_DATA_FILE = "Resources/FacilitySeedData.json";

		public FacilityDataSeeder(FacilityContext facilityContext)
		{
			_facilityContext = facilityContext;
		}

		/// <summary>
		/// Generate seed of Facilities from teh LoadFacilities method if context is currently empty
		/// </summary>
		/// <returns></returns>
		public async Task Seed()
		{
			if(!_facilityContext.Facilities.Any())
			{
				List<Facility> facilities = LoadFacilities();
				_facilityContext.Facilities.AddRange(facilities);
				SanitizeReferences(facilities);

				await _facilityContext.SaveChangesAsync();
			}
		}

		private void SanitizeReferences(List<Facility> facilities)
		{
			var facilityRefMap = from facility in facilities
								 select new { Id = facility.FacilityID, FacilityRef = facility };
		}

		/// <summary>
		/// Read from a pre-generated list of facilities from an in-memory file
		/// </summary>
		/// <returns></returns>
		private List<Facility> LoadFacilities()
		{
			using (FileStream fs = new FileStream(FACILITY_SEED_DATA_FILE, FileMode.Open))
			using (StreamReader sr = new StreamReader(fs))
			using (JsonReader jr = new JsonTextReader(sr))
			{
				JsonSerializer serializer = new JsonSerializer();

				List<Facility>? facilities = serializer.Deserialize<List<Facility>>(jr);

				return facilities;
			}
		}
	}
}
