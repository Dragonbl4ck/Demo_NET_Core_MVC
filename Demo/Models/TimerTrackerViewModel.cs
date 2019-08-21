using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
	public class TimerTrackerViewModel
	{
		public TimerTrackerAssemblyInsert Insert {get;set;}

		public IEnumerable<TimerTrackerAssemblyParts> Parts { get; set;}
	}
}
