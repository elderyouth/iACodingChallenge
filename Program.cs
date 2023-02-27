using iACodingChallenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using iACodingChallenge.Repositories;
using iACodingChallenge.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<FacilityContext>(options =>
{
	options.UseInMemoryDatabase("FacilityDB");
});
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
SeedFaciltyDB();
//SeedFacilityData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


// Create FacilityDB as an in memory option (This can be replaced with an actual DB CS)
void SeedFaciltyDB()
{
	new FacilityDataSeeder(
		new FacilityContext(
		new DbContextOptionsBuilder<FacilityContext>().UseInMemoryDatabase("FacilityDB").Options
	)).Seed().Wait();
}

app.Run();

///Seeding Method for random items (Not being used)
//void SeedRandomFacilityData(WebApplication app)
//{
//	var scope = app.Services.CreateScope();
//	var db = scope.ServiceProvider.GetService<FacilityContext>();

//	var f1 = new Facility
//	{
//		FacilityID = 1,
//		FacilityCoordinateX = -8,
//		FacilityCoordinateY = -4,
//		Medications = new List<Medication> { 
//			new Medication { MedicationID= 1, MedicationPrice = 102.20m },
//			new Medication { MedicationID= 2, MedicationPrice = 56.76m },
//			new Medication { MedicationID= 3, MedicationPrice = 199.42m }
//		}
//	};

//	var f2 = new Facility
//	{
//		FacilityID = 2,
//		FacilityCoordinateX = 5,
//		FacilityCoordinateY = -5,
//		Medications = new List<Medication> {
//			new Medication { MedicationID= 12, MedicationPrice = 616.20m },
//			new Medication { MedicationID= 22, MedicationPrice = 100.61m },
//		}
//	};

//	var f3 = new Facility
//	{
//		FacilityID = 3,
//		FacilityCoordinateX = -3,
//		FacilityCoordinateY = -9,
//		Medications = new List<Medication> {
//			new Medication { MedicationID= 13, MedicationPrice = 133.59m },
//			new Medication { MedicationID= 23, MedicationPrice = 39.16m },
//			new Medication { MedicationID= 33, MedicationPrice = 199.42m },
//			new Medication { MedicationID= 43, MedicationPrice = 199.42m },
//			new Medication { MedicationID= 53, MedicationPrice = 9.20m }
//		}
//	};

//	db.Facilities.Add(f1);
//	db.Facilities.Add(f2); 
//	db.Facilities.Add(f3);

//	db.SaveChanges();
//}
