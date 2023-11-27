using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.CMDashboard;

/// <summary>
/// Summary description for ICMDashboardBAL
/// </summary>
namespace BusinessLogicLayer.CMDashboardBAL
{
    [ServiceContract]
    public interface ICMDashboardBAL
    {
        #region   "Get Year WiseCompany Registration Count Report"
        [OperationContract]
        List<ClsOutput1> GetYearWiseCompanyRegdReport(CMDashboardEntity objUser);
        #endregion

        #region   "Get Total No. Of Companies Registration Count Report"
        [OperationContract]
        List<ClsOutput2> GetTotalNoOfCompaniesRegd(CMDashboardEntity objUser);
        #endregion

        #region   "Get Sector Wise No. Of  Companies Registration Count Report"
        [OperationContract]
        List<ClsOutput3> GetSectorWiseNoOfCompany(CMDashboardEntity objUser);
        #endregion

        #region   "Get Industry Details Report"
        [OperationContract]
        List<ClsOutput4> GetIndustryDetailsReport(CMDashboardEntity objUser);
        #endregion
    }
}
