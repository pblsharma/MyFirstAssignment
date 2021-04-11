using MyFirstAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstAssessment.Controllers
{
	public class EmployeeController : ApiController
	{
		[Route("api/Employee/GetEmployee")]
		[HttpGet]
		public List<clsEmployee> GetEmployee(employeeInput input)
		{
			List<clsEmployee> objList = new List<clsEmployee>();
			objList  = FileterEmployee( input);
			return objList;
		}	
		public List<clsEmployee> FileterEmployee(employeeInput input)
		{
			string userName = input.userName;
			DateTime StartDate = input.startDate;
			DateTime EndDate = input.endDate;
			List<clsEmployee> objList = new List<clsEmployee>();
			objList.Add(new clsEmployee { Age = 30, FirstName = "Parvesh", JobTitle = "Software Engg", EndDate = Convert.ToDateTime("01-Oct-2021"), LastName = "Kumar", StartDate = Convert.ToDateTime("01-Jan-2021") });
			objList.Add(new clsEmployee { Age = 30, FirstName = "Sanjay", JobTitle = "Software Engg", EndDate = Convert.ToDateTime("01-Nov-2021"), LastName = "Arora", StartDate = Convert.ToDateTime("01-Feb-2021") });
			objList.Add(new clsEmployee { Age = 30, FirstName = "Sumit", JobTitle = "Software Engg", EndDate = Convert.ToDateTime("01-Dec-2021"), LastName = "Sharma", StartDate = Convert.ToDateTime("01-Mar-2021") });
			objList.Add(new clsEmployee { Age = 30, FirstName = "Ankit", JobTitle = "Software Engg", EndDate = Convert.ToDateTime("01-Jan-2022"), LastName = "Khanna", StartDate = Convert.ToDateTime("01-Apr-2021") });

			var result =  objList.Where(x => x.FirstName == userName || x.LastName == userName).ToList<clsEmployee>();
			if (!string.IsNullOrEmpty(StartDate.ToString()) && !string.IsNullOrEmpty(EndDate.ToString()))
			{
				return result.Where(x => x.StartDate >= StartDate && x.EndDate <= EndDate).ToList<clsEmployee>();
			}
			else if (!string.IsNullOrEmpty(StartDate.ToString()))
			{
				return result.Where(x => x.StartDate >= StartDate).ToList<clsEmployee>();
			}
			else
			{
				return result.Where(x => x.EndDate <= EndDate).ToList<clsEmployee>();
			}
		}
	}
	
}