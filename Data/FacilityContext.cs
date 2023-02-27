using iACodingChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iACodingChallenge.Data
{
	public class FacilityContext : DbContext
	{
		public FacilityContext(DbContextOptions<FacilityContext> options) : base(options) { 
		}
		public DbSet<Facility> Facilities { get; set; }
		public DbSet<Medication> Medication { get; set; }
	}
}
