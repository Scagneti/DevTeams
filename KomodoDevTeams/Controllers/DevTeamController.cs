using KomodoDevTeams.Contracts;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KomodoDevTeams.Controllers
{
	[Authorize]
	public class DevTeamController : ApiController
	{
		private IDevTeamService _devTeamService;
		public DevTeamController() { }
		public DevTeamController(IDevTeamService mockService)
		{
			_devTeamService = mockService;
		}
		public IHttpActionResult GetAll()
		{
			CreateDevTeamService();
			var devTeam = _devTeamService.GetDevTeams();
			return Ok(devTeam);
		}
		public IHttpActionResult Get(int id)
		{
			CreateDevTeamService();
			var devTeam = _devTeamService.GetDevTeamById(id);
			return Ok(devTeam);
		}
		public IHttpActionResult Post(DevTeamCreate dev)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!_devTeamService.CreateDevTeam(dev))
				return InternalServerError();
			return Ok();
		}
		public IHttpActionResult Put(DevTeamEdit devTeam)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!_devTeamService.UpdateDevTeam(devTeam))
				return InternalServerError();

			return Ok();
		}
		public IHttpActionResult Delete(int id)
		{
			if (!_devTeamService.DeleteDevTeam(id))
				return InternalServerError();

			return Ok();
		}
		private void CreateDevTeamService()
		{
			if(_devTeamService == null)
			{
				var userId = Guid.Parse(User.Identity.GetUserId());
				_devTeamService = new DevTeamServices(userId);
			}
		}
	}
}
