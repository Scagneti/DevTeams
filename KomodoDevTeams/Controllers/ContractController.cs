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
    public class ContractController : ApiController
    {
		private IContractService _contractService;
		public ContractController() { }
		public ContractController(IContractService mockService)
		{
			_contractService = mockService;
		}

		public IHttpActionResult GetAll()
		{
			CreateContractService();
			var contract = _contractService.GetContracts();
			return Ok(contract);
		}
		public IHttpActionResult Get(int id)
		{
			CreateContractService();
			var contract = _contractService.GetContractById(id);
			return Ok(contract);
		}
		public IHttpActionResult Post(ContractCreate contract)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);


			if (!_contractService.CreateContract(contract))
				return InternalServerError();
			return Ok();
		}
		public IHttpActionResult Put(ContractEdit contract)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!_contractService.UpdateContracts(contract))
				return InternalServerError();

			return Ok();
		}
		public IHttpActionResult Delete(int id)
		{

			if (!_contractService.DeleteContracts(id))
				return InternalServerError();

			return Ok();
		}
		private void CreateContractService()
		{
			if(_contractService == null)
			{
				var userId = Guid.Parse(User.Identity.GetUserId());
				_contractService = new ContractService(userId);
			}
		}
	}
}
