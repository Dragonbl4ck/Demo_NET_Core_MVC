using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
	public class TimerTrackerAssemblyInsert
	{
		public int Id { get; set; }

		public string Tstart { get; set; }

		public string Tstop { get; set; }

		public string Difference { get; set; }

		public string AssemblyNameA { get; set; }

		public string AssemblyNameB { get; set; }

		public string FamilyName { get; set; }

		public string Line { get; set; }

		public string Shift { get; set; }

		public string Comments { get; set; }

		public DateTime Date { get; set; }
	}
}
