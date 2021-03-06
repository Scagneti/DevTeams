﻿using KomodoDevTeams.Contracts;
using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Services.MockServices
{
	public class MockContractService : IContractService
	{
		public bool ReturnValue { get; set; }
		public int CallCount { get; set; }

		public bool CreateContract(ContractCreate model)
		{
			CallCount++;
			return ReturnValue;
		}

		public bool DeleteContracts(int id)
		{
			CallCount--;
			return ReturnValue;
		}

		public ContractDetails GetContractById(int id)
		{
			CallCount++;
			return new ContractDetails { ContractId = id };
		}

		public IEnumerable<ContractListItem> GetContracts()
		{
			CallCount++;
			var result = new List<ContractListItem>
			{
				new ContractListItem {ContractId = 1}
			};
			return result;
		}

		public bool UpdateContracts(ContractEdit model)
		{
			CallCount++;
			return ReturnValue;
		}
	}
}
