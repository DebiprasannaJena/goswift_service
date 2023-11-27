using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer.CNETEntity;
using SWP_Services.DAL.Data;
using System.Data;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for CnetDAL
/// </summary>

namespace DataAcessLayer.CnetDAL
{
    public class CnetDAL : ICnetDAL
    {
        string Str_RetValue = "";
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString());
        object param = new object();

        public List<CNETPushDataStatus> UpdatePEALIngrationWithIDCOStatus(CNET objDATA)
        {
            CNETPushDataStatus objResponse = new CNETPushDataStatus();
            List<CNETPushDataStatus> lstResponse = new List<CNETPushDataStatus>();
            try
            {
                int intValid = 0;

                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser1 = new JavaScriptSerializer();
                var json1 = jsonSerialiser1.Serialize(objDATA);
                string strInput = "(REQUEST_FROM_ERP)--[REQUEST_JSON_STRING]:- " + json1;
                Util.LogRequestResponse("ERPtoGOSWIFT", "UpdatePEALIngrationWithIDCOStatus", strInput);

                /*--------------------------------------------------------------------*/


                /*--------------------------------------------------------------------*/
                /// Validation Section
                /*--------------------------------------------------------------------*/

                #region Validation

                ///// CAF number is not generated immdiately after landing at idco portal

                if (objDATA.ProposalNo.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Proposal number can not be blank !";
                    intValid = 1;
                }
                //else if (objDATA.IndustryCode.Trim() == "")
                //{
                //    objResponse.Status = 4;
                //    objResponse.StatusMsg = "Industry code can not be blank !";
                //    intValid = 1;
                //}
                else if (objDATA.successmessage.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Success message can not be blank !";
                    intValid = 1;
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { 
                                                   "@PvchAction", "B",
                                                   "@Pvch_unique_application_id_from_swp",objDATA.ProposalNo,
                                                   "@Pvch_oas_cafno",objDATA.CAFNo,
                                                   "@Pvch_industry_code",objDATA.IndustryCode,
                                                   "@Pvch_success_message",objDATA.successmessage                                               
                                                 };

                    Str_RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_PEAL_CNET_SUCC_DET", out param, objArray).ToString();
                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 1;
                        objResponse.StatusMsg = "Success";
                    }
                    else if (param.ToString() == "3")
                    {
                        objResponse.Status = 3;
                        objResponse.StatusMsg = "Invalid Proposal Number";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.StatusMsg = param.ToString();
                    }
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("ERPtoGOSWIFT", "UpdatePEALIngrationWithIDCOStatus", strOutput);
                /*--------------------------------------------------------------------*/

                lstResponse.Add(objResponse);
            }
            catch (Exception ex)
            {
                objResponse.Status = 2;
                objResponse.StatusMsg = "Some Error Occured,Please try again.";
                lstResponse.Add(objResponse);
                Util.LogError(ex, "ERPtoGOSWIFT");
               
            }

            return lstResponse;
        }
        public List<CNETPushDataStatus> SWPPushDataCNET(CNET objDATA)
        {
            CNETPushDataStatus objResponse = new CNETPushDataStatus();
            List<CNETPushDataStatus> lstResponse = new List<CNETPushDataStatus>();
            try
            {
                int intValid = 0;


                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
               
                JavaScriptSerializer jsonSerialiser1 = new JavaScriptSerializer();
                var json1 = jsonSerialiser1.Serialize(objDATA);
                string strInput = "(REQUEST_FROM_ERP)--[REQUEST_JSON_STRING]:- " + json1;
                Util.LogRequestResponse("ERPtoGOSWIFT", "SWPPushDataCNET", strInput);

                /*--------------------------------------------------------------------*/


                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                #region Validation

                if (objDATA.ProposalNo.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Proposal number can not be blank !";
                    intValid = 1;
                }
                else if (objDATA.CAFNo.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "CAF number can not be blank !";
                    intValid = 1;
                }
                else if (objDATA.IndustryCode.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Industry code can not be blank !";
                    intValid = 1;
                }
                else if (objDATA.statuscode.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Status code can not be blank !";
                    intValid = 1;
                }
                else if (objDATA.ProcessingFeeRealizationStatus.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Processing fee realization status can not be blank !";
                    intValid = 1;
                }
                //else if (objDATA.DemandNoteLink.Trim() == "")
                //{
                //    objResponse.Status = 4;
                //    objResponse.StatusMsg = "Demand note link can not be blank !";
                //    intValid = 1;
                //}
                else if (objDATA.DemandReceipt.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Demand receipt link can not be blank !";
                    intValid = 1;
                }
                else if (objDATA.DemandStatus.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Demand status can not be blank !";
                    intValid = 1;
                }
                else if (objDATA.IDCOStatus.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "IDCO status can not be blank !";
                    intValid = 1;
                }                

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { 
                                                   "@PvchAction", "A",
                                                   "@PvchProposalNo",objDATA.ProposalNo,
                                                   "@PvchCAFNo",objDATA.CAFNo,
                                                   "@PvchIndustryCode",objDATA.IndustryCode,
                                                   "@Pvchstatuscode",objDATA.statuscode,
                                                   "@PvchProcessingFeeAmount",objDATA.ProcessingFeeAmount,
                                                   "@PvchProcessingFeeStatus",objDATA.ProcessingFeeStatus,
                                                   "@PvchPaymentReferenceNo",objDATA.PaymentReferenceNo,
                                                   "@PvchProcessingFeeRealizationStatus",objDATA.ProcessingFeeRealizationStatus,
                                                   "@PvchDemandNoteLink",objDATA.DemandNoteLink,
                                                   "@PvchDemandStatus", objDATA.DemandStatus,
                                                   "@PvchDemandReceipt",objDATA.DemandReceipt,
                                                   "@PvchAllotmentOrderLink",objDATA.AllotmentOrderLink,
                                                   "@PvchPaymentRealizationReferenceNo",objDATA.PaymentRealizationReferenceNo,
                                                   "@PIDCOStatus",objDATA.IDCOStatus,
                                                   "@PIDCOLandAllotment", objDATA.IDCOLandAllotment, 
                                                   "@PIDCOAmount", objDATA.IDCOAmount
                                                 };

                    Str_RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_PEAL_CNET_STATUS_ADD", out param, objArray).ToString();
                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 1;
                        objResponse.StatusMsg = "Success";
                    }
                    else if (param.ToString() == "3")
                    {
                        objResponse.Status = 3;
                        objResponse.StatusMsg = "Invalid Proposal Number";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.StatusMsg = "Unsuccess"; //param.ToString();
                    }
                }

                lstResponse.Add(objResponse);

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("ERPtoGOSWIFT", "SWPPushDataCNET", strOutput);
                /*--------------------------------------------------------------------*/

            }
            catch (Exception ex)
            {
                objResponse.Status = 2;
                objResponse.StatusMsg = "Some Error Occured,Please try again.";
                lstResponse.Add(objResponse);
                Util.LogError(ex, "ERPtoGOSWIFT");
                
            }

            return lstResponse;
        }
        public List<CNETPushDataStatus> SWPPushQuery(CNETPushQueryEntity objData)
        {
            CNETPushDataStatus objResponse = new CNETPushDataStatus();
            List<CNETPushDataStatus> lstResponse = new List<CNETPushDataStatus>();
            try
            {
                int intValid = 0;

                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser1 = new JavaScriptSerializer();
                var json1 = jsonSerialiser1.Serialize(objData);
                string strInput = "(REQUEST_FROM_ERP)--[REQUEST_JSON_STRING]:- " + json1;
                Util.LogRequestResponse("ERPtoGOSWIFT", "SWPPushQuery", strInput);

                /*--------------------------------------------------------------------*/


                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                #region Validation

                if (objData.strApplicationNumber.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Application number can not be blank !";
                    intValid = 1;
                }
                else if (objData.intNoOfTime == 0)
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Number of time query raised should be greater than Zero !";
                    intValid = 1;
                }
                else if (objData.strRemark.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Remarks can not be blank !";
                    intValid = 1;
                }
                else if (objData.strStatusCode.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Status code can not be blank !";
                    intValid = 1;
                }
                else if (objData.strIdcoStatus.Trim() == "")
                {
                    objResponse.Status = 4;
                    objResponse.StatusMsg = "Idco status code can not be blank !";
                    intValid = 1;
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { 
                                                "@P_VCH_APPLICATION_NO",objData.strApplicationNumber,
                                                "@P_INT_NO_OF_TIME",objData.intNoOfTime,
                                                "@P_VCH_REMARK",objData.strRemark,
                                                "@P_VCH_KEY",objData.strKey,
                                                "@P_VCH_IDCO_STATUS_CODE",objData.strStatusCode,
                                                "@P_VCH_IDCO_STATUS",objData.strIdcoStatus,
                                                 };

                    Str_RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_PUSHQUERY", out param, objArray).ToString();
                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 1;
                        objResponse.StatusMsg = "Success";
                    }
                    else if (param.ToString() == "3")
                    {
                        objResponse.Status = 3;
                        objResponse.StatusMsg = "Invalid Key";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.StatusMsg = "Unsuccess"; //param.ToString();
                    }
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("ERPtoGOSWIFT", "SWPPushQuery", strOutput);
                /*--------------------------------------------------------------------*/

                lstResponse.Add(objResponse);
            }
            catch (Exception ex)
            {
                objResponse.Status = 2;
                objResponse.StatusMsg = "Some Error Occured,Please try again.";
                lstResponse.Add(objResponse);
                Util.LogError(ex, "ERPtoGOSWIFT");
                
            }

            return lstResponse;
        }

        public List<DashboardDtl> DashboardCount(string strYr)
        {
            /*--------------------------------------------------------------------*/
            ///Write request log for each request.
            /*--------------------------------------------------------------------*/
            //JavaScriptSerializer jsonSerialiser1 = new JavaScriptSerializer();
            //var json1 = jsonSerialiser1.Serialize(objDATA);
            string strInput = "(REQUEST_FROM_ERP)--[REQUEST_JSON_STRING]:- " + strYr;
            Util.LogRequestResponse("ERPtoGOSWIFT", "DashboardCount", strYr);

            /*--------------------------------------------------------------------*/

            List<DashboardDtl> list = new List<DashboardDtl>();
            DashboardDtl objDash = new DashboardDtl();

            SqlDataReader sqlReader = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_CMS_DETAILS";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_CHAR_ACTION", "VP");
                cmd.Parameters.AddWithValue("@YEARVal", strYr);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sqlReader = cmd.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        //objInvestor.proposalid = "1";
                        objDash.Received = sqlReader["TotApplRec"].ToString();
                        objDash.Approved = sqlReader["Approved"].ToString();
                        objDash.TotEmpProp = sqlReader["TotPropEmpApproved"].ToString();
                        objDash.TotCapital = sqlReader["TotCapitalApprove"].ToString();

                        list.Add(objDash);
                    }
                }
                sqlReader.Close();
                
                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                
                //JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                //var json2 = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + " " + " <----> [RESPONSE_JSON_STRING_NO_OF_RECORDS]:- " + list.Count;
                Util.LogRequestResponse("ERPtoGOSWIFT", "DashboardCount", strOutput);
                /*--------------------------------------------------------------------*/

                //return list;

            }
            
            //catch (NullReferenceException ex) {
            //    Util.LogError(ex, "DashboardCount");
            //}
            catch (Exception ex)
            {
                Util.LogError(ex, "DashboardCount");
            }
            //finally { cmd = null; conn.Close(); }
            return list;
        }
    }
}