using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using KomodoDevTeams.Controllers;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services.MockServices;
using KomodoDevTeams.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoDevTeams.MockTests
{
	[TestClass]
	public class DevTests
	{
		private MockDevService _mockService;
		private DevController _controller;

		[TestInitialize]
		public void Initialize()
		{
			_mockService = new MockDevService { ReturnValue = true };
			_controller = new DevController(_mockService);
		}

		[TestMethod]
		public void DevService_PostDev_ReturnsOk()
		{
			var dev = new DevCreate { DevName = "Zach" };
			var result = _controller.Post(dev);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void DevService_GetDev_ReturnsCorrectInt()
		{
			var result = _controller.GetAll();

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<DevListItem>>));
		}
		[TestMethod]
		public void DevService_GetDevById_ReturnsCorrectInt()
		{
			var result = _controller.Get(1);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, (typeof(OkNegotiatedContentResult<DevDetails>)));
		}
		[TestMethod]
		public void DevService_DeleteDev_ReturnsOk()
		{
			var result = _controller.Delete(1);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void DevService_DeleteDev_ThrowsException()
		{
			_mockService.CallCount = 1;
			_mockService.ReturnValue = false;
			var result = _controller.Delete(1);

			Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
		}
		[TestMethod]
		public void DevService_DevEdit_ReturnsOk()
		{
			var dev = new DevEdit { DevId = 1, DevName = "Zach" };
			var result = _controller.Put(dev);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
	}
}
