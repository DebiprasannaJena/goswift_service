using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CMDashboard
/// </summary>
namespace EntityLayer.CMDashboard
{
	public class CMDashboardEntity
	{
		public string SecurityKey { get; set; }
		public string FromDate { get; set; }
		public string ToDate { get; set; }
		public int DistrictId { get; set; }
	}

	
	public class YearWiseCompanyRegistered
	{
		public string RegistrationYear { get; set; }
		public int NoOfRegistrationInYear { get; set; }
			
	}

	public class ClsOutput1
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<YearWiseCompanyRegistered> YearWiseCompanyRegistered { get; set; }
	}


	public class TotalNoOfCompaniesRegistered
	{
		public int TotalCompanyRegistered { get; set; }
		
	}

	public class ClsOutput2
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<TotalNoOfCompaniesRegistered> TotalNoOfCompaniesRegistered { get; set; }
	}

	public class SectorWiseCompanyRegistered
	{
		public string SectorName { get; set; }
		public int SectorId { get; set; }
		public int NoOfRegistration { get; set; }
				
	}

	public class ClsOutput3
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<SectorWiseCompanyRegistered> SectorWiseCompanyRegistered { get; set; }
		
	}

	public class IndustryDetailsReport
    {
		public string CompanyName { get; set; }
        public string SectorName { get; set; }
        public int SectorId { get; set; }
		public int SubSectorId { get; set; }
        public string SubSectorName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string MobileNo { get; set; }
		public string Address { get; set; }
		public string ApprovedDate { get; set; }

	}
	public class ClsOutput4
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<IndustryDetailsReport> IndustryDetailsReport { get; set; }

	}
}
