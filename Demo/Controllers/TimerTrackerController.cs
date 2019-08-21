using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Demo.Controllers
{
    public class TimerTrackerController : Controller
    {
		public IConfiguration Configuration { get;}
		public TimerTrackerController(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IActionResult TimerTrackerSelectOptionFamily()
		{
			List<TimerTrackerAssemblyParts> ListParts = new List<TimerTrackerAssemblyParts>();

			string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlDataReader
				connection.Open();
				string sql1 = "SELECT * FROM timerTrackerFamily";

				SqlCommand command1 = new SqlCommand(sql1, connection);

				using (SqlDataReader dataReader = command1.ExecuteReader())
				{
					while (dataReader.Read())
					{
						TimerTrackerAssemblyParts FinalPartsFamily = new TimerTrackerAssemblyParts();
						FinalPartsFamily.Id = Convert.ToInt32(dataReader["Id"]);
						FinalPartsFamily.Family = Convert.ToString(dataReader["Family"]);

						ListParts.Add(FinalPartsFamily);
					}
				}
				connection.Close();
			}
			return View(ListParts);
		}

		public IActionResult TimerTrackerHome(TimerTrackerAssemblyInsert timerTracker)
        {
			if (ModelState.IsValid)
			{
				string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string sql = $"INSERT INTO timerTrackerAssemblyInsert (tstart, tstop, difference, assemblynamea, assemblynameb, familyname, line, shift, comments, date) VALUES ('{timerTracker.Tstart}', '{timerTracker.Tstop}','{timerTracker.Difference}','{timerTracker.AssemblyNameA}','{timerTracker.AssemblyNameB}','{timerTracker.FamilyName}','{timerTracker.Line}','{timerTracker.Shift}','{timerTracker.Comments}','{timerTracker.Date}')";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.CommandType = CommandType.Text;

						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}
				}
			}
			return View();
		}
    }
}