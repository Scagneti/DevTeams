using KomodoDevTeams.Contracts;
using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Services.MockServices
{
	public class MockDevTeamService : IDevTeamService
	{
		public bool ReturnValue { get; set; }
		public int CallCount { get; set; }

		public bool CreateDevTeam(DevTeamCreate model)
		{
			CallCount++;
			return ReturnValue;
		}

		public bool DeleteDevTeam(int id)
		{
			CallCount++;
			return ReturnValue;
		}

		public DevTeamDetails GetDevTeamById(int id)
		{
			CallCount++;
			return new DevTeamDetails { TeamId = 1, TeamName = "XML Team" };
		}

		public IEnumerable<DevTeamListItem> GetDevTeams()
		{
			CallCount++;
			var result = new List<DevTeamListItem>
			{
				new DevTeamListItem{TeamId = 1, TeamName = "C# Team"}
			};
			return result;
		}

		public bool UpdateDevTeam(DevTeamEdit model)
		{
			CallCount++;
			return ReturnValue;
		}
	}
}
