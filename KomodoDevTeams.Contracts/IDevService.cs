using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Contracts
{
	public interface IDevService
	{
		bool CreateDev(DevCreate model);
		IEnumerable<DevListItem> GetDevs();
		DevDetails GetDevById(int id);
		bool UpdateDev(DevEdit devEdit);
		bool DeleteDev(int id);
	}
}
