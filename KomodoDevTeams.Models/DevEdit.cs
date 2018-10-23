﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Models
{
	public class DevEdit
	{
		public int DevId { get; set; }
		public Guid OwnerId { get; set; }
		public string DevName { get; set; }
		public DateTimeOffset HireDate { get; set; }
	}
}
