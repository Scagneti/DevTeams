using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Contracts
{
	public interface IDevTeamService
	{
		bool CreateDevTeam(DevTeamCreate model);
		IEnumerable<DevTeamListItem> GetDevTeams();
		DevTeamDetails GetDevTeamById(int id);
		bool UpdateDevTeam(DevTeamEdit model);
		bool DeleteDevTeam(int id);
	}
}
