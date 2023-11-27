﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcessLayer.CMDashboardDAL;
using EntityLayer.CMDashboard;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for CMDashboardBAL
/// </summary>
namespace BusinessLogicLayer.CMDashboardBAL
{
	public class CMDashboardBAL:ICMDashboardBAL
	{
		CMDashboardDAL obj = new CMDashboardDAL();

		#region  "Get Year WiseCompany Registration Count Report"
		/// <summary>
		/// Created By Debiprasanna on 25-Oct-2022 for Get Year WiseCompany Registration Count Report
		/// </summary>
		/// <param name="objUser"></param>
		/// <returns></returns>

		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate="getYearWiseCompanyRegdReport")]
		public List<ClsOutput1> GetYearWiseCompanyRegdReport(CMDashboardEntity objUser)
		{
			try
			{
				return obj.GetYearWiseCompanyRegdReport(objUser);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
		#endregion



		#region  "Get Total No. Of Companies Registration Count Report"
		/// <summary>
		/// Created By Debiprasanna on 25-Oct-2022 for Get Total No. Of Companies Registration Count Report
		/// </summary>
		/// <param name="objUser"></param>
		/// <returns></returns>

		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate="getTotalNoOfCompaniesRegd")]
		public List<ClsOutput2> GetTotalNoOfCompaniesRegd(CMDashboardEntity objUser)
		{
			try
            {
				return obj.GetTotalNoOfCompaniesRegd(objUser);
			}
			catch(Exception ex)
            {
				throw ex;
            }
			
		}
		#endregion

		#region  "Get Sector Wise No. Of  Companies Registration Count Report"
		/// <summary>
		/// Created By Debiprasanna on 25-Oct-2022 for Get Sector Wise No. Of  Companies Registration Count Report
		/// </summary>
		/// <param name="objUser"></param>
		/// <returns></returns>

		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate ="getSectorWiseNoOfCompany")]
		public List<ClsOutput3> GetSectorWiseNoOfCompany(CMDashboardEntity objUser)
		{
			try
			{
				return obj.GetSectorWiseNoOfCompany(objUser);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		#endregion

		#region  "Get Industry Details Report"
		/// <summary>
		/// Created By Debiprasanna on 03-Nov-2022 for Get Industry Details Report
		/// </summary>
		/// <param name="objUser"></param>
		/// <returns></returns>

		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getIndustryDetailsReport")]
		public List<ClsOutput4> GetIndustryDetailsReport(CMDashboardEntity objUser)
		{
			try
			{
				return obj.GetIndustryDetailsReport(objUser);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		#endregion
	}
}
