using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using KomodoDevTeams.Controllers;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoDevTeams.MockTests
{
	[TestClass]
	public class DevTeamTests
	{
		private MockDevTeamService _mockService;
		private DevTeamController _controller;

		[TestInitialize]
		public void Initialize()
		{
			_mockService = new MockDevTeamService { ReturnValue = true };
			_controller = new DevTeamController(_mockService);
		}

		[TestMethod]
		public void DevTeamService_PostDevTeam_ReturnsOk()
		{
			var devTeam = new DevTeamCreate { TeamName = "Sql Team" };
			var result = _controller.Post(devTeam);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void DevTeamService_PutDevTeam_ReturnsOk()
		{
			var devTeam = new DevTeamEdit { TeamId = 1, TeamName = "XML Team" };
			var result = _controller.Put(devTeam);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void DevTeamService_DeleteDevTeam_ReturnsOk()
		{
			var result = _controller.Delete(1);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void DevTeamService_DeleteDevTeam_ThrowsException()
		{
			_mockService.ReturnValue = false;
			var result = _controller.Delete(1);

			Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
		}
		[TestMethod]
		public void DevTeamService_GetAllDevTeams_ReturnsOk()
		{
			var result = _controller.GetAll();

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<DevTeamListItem>>));
		}
		[TestMethod]
		public void DevTeamService_GetDevTeam_ReturnsOk()
		{
			var result = _controller.Get(1);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<DevTeamDetails>));
		}
	}
}
