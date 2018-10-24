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
	public class ContractTests
	{
		private ContractController _controller;
		private MockContractService _mockService;

		[TestInitialize]
		public void Initialize()
		{
			_mockService = new MockContractService { ReturnValue = true };
			_controller = new ContractController(_mockService);
		}

		[TestMethod]
		public void ContractController_PostContract_ShouldReturnOk()
		{
			var contract = new ContractCreate { ContractId = 1 };
			var result = _controller.Post(contract);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void ContractController_PutContract_ShouldReturnOk()
		{
			var contract = new ContractEdit { ContractId = 1 };
			var result = _controller.Put(contract);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void ContractController_DeleteContract_ShouldReturnOk()
		{
			_mockService.CallCount = 1;

			var result = _controller.Delete(1);
			Assert.AreEqual(0, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
		[TestMethod]
		public void ContractController_PostContract_ShouldReturnInternalServerError()
		{
			_mockService.CallCount = 1;
			_mockService.ReturnValue = false;

			var result = _controller.Delete(1);

			Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
		}
		[TestMethod]
		public void ContractController_GetAll_ShouldReturnCorrectInt()
		{
			var result = _controller.GetAll();

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<ContractListItem>>));
		}
		[TestMethod]
		public void ContractController_GetById_ShouldReturnCorrectInt()
		{
			var result = _controller.Get(1);

			Assert.AreEqual(1, _mockService.CallCount);
			Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContractDetails>));
		}
	}
}
