using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer.CMDashboard;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using SWP_Services.DAL.Data;
using System.Globalization;
using System.Text.RegularExpressions;



/// <summary>
/// Summary description for CMDashboardDAL
/// </summary>
namespace DataAcessLayer.CMDashboardDAL
{
    public class CMDashboardDAL : ICMDashboardDAL
    {



        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;

        string strCMdashboardSecurityKey = System.Configuration.ConfigurationManager.AppSettings["CMDashboardSecurityKey"].ToString();

        string RetValue;
        object param = new object();

        #region  "Get Year WiseCompany Registration Count Report"
        /// <summary>
        /// Created By Debiprasanna on 25-Oct-2022 for Get Year Wise Company Registration Count Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ClsOutput1> GetYearWiseCompanyRegdReport(CMDashboardEntity objUser)
        {
            List<ClsOutput1> list = new List<ClsOutput1>();

            try
            {
                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/                 
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objUser);
                string strInput = "(REQUEST_FROM_CM_DASHBOARD)--[REQUEST_JSON_STRING]:- " + json;
                Util.LogRequestResponse("CMDashboard", "GetYearWiseCompanyRegdReport", strInput);

                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;
                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    ClsOutput1 objent = new ClsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid Security Key";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.FromDate == "")
                {
                    ClsOutput1 objent = new ClsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    ClsOutput1 objent = new ClsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    ClsOutput1 objent = new ClsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate)==false)
                {
                    ClsOutput1 objent = new ClsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    ClsOutput1 objent = new ClsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }

                /*--=======================================================================================================================--*/

                if (intValid == 0)
                {
                    SqlDataReader reader;
                   
                    object[] arr = new object[] {  "@P_VCH_ACTION_CODE","YWCRR",
                                                    "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                                    "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                                    "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                                };
                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);
                    ClsOutput1 objent1 = new ClsOutput1
                    {
                        Status = 0,
                        OutMessage = "Success",
                        YearWiseCompanyRegistered = reader.DataReaderMapToList<YearWiseCompanyRegistered>(MappingDirection.Auto)
                    };
                    list.Add(objent1);
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
               // JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(list);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("CMDashboard", "GetYearWiseCompanyRegdReport", strOutput);
                /*--------------------------------------------------------------------*/

            }
            catch (Exception ex)
            {
                Util.LogError(ex, "CMDashboard");
            }
            finally
            {
               // reader = null;
            }

            return list;

        }
        #endregion

        #region  "Get Total No. Of Companies Registration Count Report"
        /// <summary>
        /// Created By Debiprasanna on 25-Oct-2022 for Get Total No. Of Companies Registration Count Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ClsOutput2> GetTotalNoOfCompaniesRegd(CMDashboardEntity objUser)
        {
            List<ClsOutput2> list = new List<ClsOutput2>();

            try
            {
                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objUser);
                string strInput = "(REQUEST_FROM_CM_DASHBOARD)--[REQUEST_JSON_STRING]:- " + json;
                Util.LogRequestResponse("CMDashboard", "GetTotalNoOfCompaniesRegd", strInput);

                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;
                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    ClsOutput2 objent = new ClsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid Security Key";
                    list.Add(objent);
                    intValid = 1;
                }

                else if (objUser.FromDate == "")
                {
                    ClsOutput2 objent = new ClsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    ClsOutput2 objent = new ClsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    ClsOutput2 objent = new ClsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate) == false)
                {
                    ClsOutput2 objent = new ClsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    ClsOutput2 objent = new ClsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }


                /*--=======================================================================================================================--*/

                if (intValid == 0)
                {
                    SqlDataReader reader;
                    
                    object[] arr = new object[] {  "@P_VCH_ACTION_CODE","TNCRR",
                                           "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                           "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                           "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                        };

                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);
                    ClsOutput2 objent2 = new ClsOutput2()
                    {
                        Status = 0,
                        OutMessage = "Success",
                        TotalNoOfCompaniesRegistered = reader.DataReaderMapToList<TotalNoOfCompaniesRegistered>(MappingDirection.Auto)
                    };
                    list.Add(objent2);
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                // JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(list);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("CMDashboard", "GetTotalNoOfCompaniesRegd", strOutput);
                /*--------------------------------------------------------------------*/
            }
            catch (Exception ex)
            {

                Util.LogError(ex, "CMDashboard");
            }
            finally
            {
               // reader = null;
            }

            return list;
        }
        #endregion

        #region  "Get Sector Wise No. Of  Companies Registration Count Report"
        /// <summary>
        /// Created By Debiprasanna on 25-Oct-2022 for Get Sector Wise No. Of  Companies Registration Count Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ClsOutput3> GetSectorWiseNoOfCompany(CMDashboardEntity objUser)
        {
            List<ClsOutput3> list = new List<ClsOutput3>();

            try
            {
                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objUser);
                string strInput = "(REQUEST_FROM_CM_DASHBOARD)--[REQUEST_JSON_STRING]:- " + json;
                Util.LogRequestResponse("CMDashboard", "GetSectorWiseNoOfCompany", strInput);

                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    ClsOutput3 objent = new ClsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid Security Key";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (objUser.FromDate == "")
                {
                    ClsOutput3 objent = new ClsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    ClsOutput3 objent = new ClsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    ClsOutput3 objent = new ClsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate) == false)
                {
                    ClsOutput3 objent = new ClsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    ClsOutput3 objent = new ClsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }

                /*--=======================================================================================================================--*/

                if (intValid == 0)
                {
                    SqlDataReader reader;
                    
                    object[] arr = new object[] {  "@P_VCH_ACTION_CODE","SWNCR",
                                           "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                           "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                           "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                        };
                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);

                    ClsOutput3 objent3 = new ClsOutput3()
                    {
                        Status = 0,
                        OutMessage = "Success",
                        SectorWiseCompanyRegistered = reader.DataReaderMapToList<SectorWiseCompanyRegistered>(MappingDirection.Auto)
                    };
                    list.Add(objent3);                  
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                // JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(list);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("CMDashboard", "GetSectorWiseNoOfCompany", strOutput);
                /*--------------------------------------------------------------------*/
            }
            catch (Exception ex)
            {

                Util.LogError(ex, "CMDashboard");
            }
            finally
            {
                //reader = null;
            }
            return list;
        }
        #endregion


        #region  "Get Industry Details Report"
        /// <summary>
        /// Created By Debiprasanna on 03-Nov-2022 for Get Industry Details Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ClsOutput4> GetIndustryDetailsReport(CMDashboardEntity objUser)
        {
            List<ClsOutput4> list = new List<ClsOutput4>();

            try
            {
                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objUser);
                string strInput = "(REQUEST_FROM_CM_DASHBOARD)--[REQUEST_JSON_STRING]:- " + json;
                Util.LogRequestResponse("CMDashboard", "GetIndustryDetailsReport", strInput);

                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    ClsOutput4 objent = new ClsOutput4();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid Security Key";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (objUser.FromDate == "")
                {
                    ClsOutput4 objent = new ClsOutput4();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    ClsOutput4 objent = new ClsOutput4();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    ClsOutput4 objent = new ClsOutput4();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate) == false)
                {
                    ClsOutput4 objent = new ClsOutput4();
                    objent.Status = 1;
                    objent.OutMessage = "Date format is incorrect.The format must be dd-MMM-yyyy.";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    ClsOutput4 objent = new ClsOutput4();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }

                /*--=======================================================================================================================--*/

                if (intValid == 0)
                {
                    SqlDataReader reader;

                    object[] arr = new object[] {  "@P_VCH_ACTION_CODE","IDR",
                                           "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                           "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                           "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                        };
                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);

                    ClsOutput4 objent4 = new ClsOutput4()
                    {
                        Status = 0,
                        OutMessage = "Success",
                        IndustryDetailsReport = reader.DataReaderMapToList<IndustryDetailsReport>(MappingDirection.Auto)
                    };
                    list.Add(objent4);
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                var json2 = jsonSerialiser.Serialize(list);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("CMDashboard", "GetIndustryDetailsReport", strOutput);
                /*--------------------------------------------------------------------*/
            }
            catch (Exception ex)
            {

                Util.LogError(ex, "CMDashboard");
            }
            finally
            {
                //reader = null;
            }
            return list;
        }
        #endregion
    }
}