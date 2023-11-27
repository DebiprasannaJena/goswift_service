#region
//******************************************************************************************************************
// File Name             :   ForestLicense/ForestLicenseDAL.cs
// Description           :   Call different services for different methods for Integration of Forest Department
// Created by            :   Pranay Kumar
// Created on            :   05-Sept-2017
// Modified by           :  
// Created on            :   
// Modification History  :
//       <CR no.>                      <Date>             <Modified by>                <Modification Summary>'                                                          
//         
//********************************************************************************************************************
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SWP_Services.DAL.Data;
using System.Configuration;
using System.Web.Script.Serialization;
using DataAcessLayer.SWPIntegrationDAL;
using EntityLayer.ForestLicenseEntity;
using DataAcessLayer.ForestLicenseDAL;

/// <summary>
/// Summary description for ForestLicenseDAL
/// </summary>


namespace DataAcessLayer.ForestLicenseDAL
{

    public class ForestLicenseDAL : IForestLicenseDAL
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;

        string RetValue;
        object param = new object();

        readonly string strFORESTSecurityKey = ConfigurationManager.AppSettings["FORESTSecurityKey"].ToString();



        //#region  "Fetch User Profile Details For Tree Felling"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details For Tree Felling
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //public List<ForestLicenseUserProfile> GetUserProfilesTF(ForestAuthStatus objUser)
        //{
        //    SqlDataReader reader;
        //    List<ForestLicenseUserProfile> list = new List<ForestLicenseUserProfile>();
        //    object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
        //                                     "P_vch_UserID",objUser.strUserID,
        //                                };
        //    try
        //    {

        //        reader = SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_FOREST_LICENSE", arr);
        //        list = reader.DataReaderMapToList<ForestLicenseUserProfile>(MappingDirection.Auto);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    finally
        //    {
        //        reader = null;
        //    }

        //    return list;

        //}
        //#endregion
        //#region "Push User Data For Tree Felling"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Tree Felling
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //public List<ForestPushDataStatus> SWPPushDataTreeF(ForestPushData objDATA)
        //{
        //    ForestPushDataStatus objResponse = new ForestPushDataStatus();
        //    List<ForestPushDataStatus> lstResponse = new List<ForestPushDataStatus>();

        //    try
        //    {
        //        object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
        //                                           "P_vch_ProposalID",objDATA.strIndustryCode,
        //                                           "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
        //                                           "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
        //                                           "P_SERVICEID",objDATA.intServiceID,
        //                                           "P_INT_STATUS",objDATA.intApplicationStatus,
        //                                           "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
        //                                           "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
        //                                           "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
        //                                           "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
        //                                           "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
        //                                           "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
        //                                           "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
        //                                           "P_VCH_REMARK",objDATA.strRemark,
        //                                           "P_INT_ESCALATION_ID",objDATA.strEscalationID,
        //                                           "P_VCH_ULB_CODE",objDATA.strULBCode,
        //                                           "P_INT_CREATEDBY",objDATA.strUserID
        //         };

        //        RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_FOREST_LICENSE", out param, objArray).ToString();
        //        if (param.ToString() == "1")
        //        {
        //            objResponse.intStatus = 1;
        //            objResponse.strStatusMsg = "Success";
        //        }
        //        else
        //        {
        //            objResponse.intStatus = 0;
        //            objResponse.strStatusMsg = "Fail";
        //        }
        //        lstResponse.Add(objResponse);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }

        //    return lstResponse;
        //}
        //#endregion
        //#region  "Fetch User Profile Details for Tree Transit"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details for Tree Transit
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //public List<ForestLicenseUserProfile> GetUserProfilesTT(ForestAuthStatus objUser)
        //{
        //    SqlDataReader reader;
        //    List<ForestLicenseUserProfile> list = new List<ForestLicenseUserProfile>();
        //    object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
        //                                     "P_vch_UserID",objUser.strUserID,
        //                                };
        //    try
        //    {

        //        reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_FOREST_LICENSE", arr);
        //        list = reader.DataReaderMapToList<ForestLicenseUserProfile>(MappingDirection.Auto);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    finally
        //    {
        //        reader = null;
        //    }

        //    return list;

        //}
        //#endregion
        //#region "Push User Data For Tree Transit"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Tree Transit
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //public List<ForestPushDataStatus> SWPPushDataTreeTransit(ForestPushData objDATA)
        //{
        //    ForestPushDataStatus objResponse = new ForestPushDataStatus();
        //    List<ForestPushDataStatus> lstResponse = new List<ForestPushDataStatus>();
        //    try
        //    {
        //        object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
        //                                           "P_vch_ProposalID",objDATA.strIndustryCode,
        //                                           "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
        //                                           "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
        //                                           "P_SERVICEID",objDATA.intServiceID,
        //                                           "P_INT_STATUS",objDATA.intApplicationStatus,
        //                                           "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
        //                                           "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
        //                                           "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
        //                                           "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
        //                                           "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
        //                                           "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
        //                                           "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
        //                                           "P_VCH_REMARK",objDATA.strRemark,
        //                                           "P_INT_ESCALATION_ID",objDATA.strEscalationID,
        //                                           "P_VCH_ULB_CODE",objDATA.strULBCode,
        //                                           "P_INT_CREATEDBY",objDATA.strUserID
        //         };

        //        RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_FOREST_LICENSE", out param, objArray).ToString();
        //        if (param.ToString() == "1")
        //        {
        //            objResponse.intStatus = 1;
        //            objResponse.strStatusMsg = "Success";
        //        }
        //        else
        //        {
        //            objResponse.intStatus = 0;
        //            objResponse.strStatusMsg = "Fail";
        //        }
        //        lstResponse.Add(objResponse);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }

        //    return lstResponse;
        //}
        //#endregion
        //#region  "Fetch User Profile Details for Felling Tree"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Felling Tree
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //public List<ForestLicenseUserProfile> GetUserProfilesFellT(ForestAuthStatus objUser)
        //{
        //    SqlDataReader reader;
        //    List<ForestLicenseUserProfile> list = new List<ForestLicenseUserProfile>();
        //    object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
        //                                     "P_vch_UserID",objUser.strUserID,
        //                                };
        //    try
        //    {

        //        reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_FOREST_LICENSE", arr);
        //        list = reader.DataReaderMapToList<ForestLicenseUserProfile>(MappingDirection.Auto);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    finally
        //    {
        //        reader = null;
        //    }

        //    return list;

        //}
        //#endregion
        //#region "Push User Data For Felling Tree"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Felling Tree
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //public List<ForestPushDataStatus> SWPPushDataFellT(ForestPushData objDATA)
        //{
        //    ForestPushDataStatus objResponse = new ForestPushDataStatus();
        //    List<ForestPushDataStatus> lstResponse = new List<ForestPushDataStatus>();
        //    try
        //    {
        //        object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
        //                                           "P_vch_ProposalID",objDATA.strIndustryCode,
        //                                           "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
        //                                           "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
        //                                           "P_SERVICEID",objDATA.intServiceID,
        //                                           "P_INT_STATUS",objDATA.intApplicationStatus,
        //                                           "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
        //                                           "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
        //                                           "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
        //                                           "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
        //                                           "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
        //                                           "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
        //                                           "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
        //                                           "P_VCH_REMARK",objDATA.strRemark,
        //                                           "P_INT_ESCALATION_ID",objDATA.strEscalationID,
        //                                           "P_VCH_ULB_CODE",objDATA.strULBCode,
        //                                           "P_INT_CREATEDBY",objDATA.strUserID
        //         };

        //        RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_FOREST_LICENSE", out param, objArray).ToString();
        //        if (param.ToString() == "1")
        //        {
        //            objResponse.intStatus = 1;
        //            objResponse.strStatusMsg = "Success";
        //        }
        //        else
        //        {
        //            objResponse.intStatus = 0;
        //            objResponse.strStatusMsg = "Fail";
        //        }
        //        lstResponse.Add(objResponse);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }

        //    return lstResponse;
        //}


        //#endregion


        #region Forest Department New Integration Logic add by anil
        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) application status update through FOREST Portal.
        /// </summary>

        public List<ClsOutput> FEDApplicationStatusUpdate(ForestLicense_Entity ObjParam)
        {
            ClsOutput objResponse = new ClsOutput();
            List<ClsOutput> lstResponse = new List<ClsOutput>();
            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim();
                Util.LogRequestResponse("FOREST", "FEDApplicationStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (ObjParam.SecurityKey.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Security key should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.SecurityKey.Trim() != strFORESTSecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (ObjParam.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.Status.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Status should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.Remarks.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Remarks should not be blank.";
                    intValid = 1;
                }

                if (ObjParam.Status.ToString().Trim() == "3") //// Rejected
                {
                    if (ObjParam.ReferenceDocFileLink.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Reference document link should not be blank.";
                        intValid = 1;
                    }
                }

                if (ObjParam.Status.ToString().Trim() == "2") //// Approved
                {
                    if (ObjParam.ApprovalDocFileLink.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Approval document link should not be blank.";
                        intValid = 1;
                    }
                }


                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { "@P_VCH_ACTION", "ASU",
                                                       "@P_VCH_APPLICATION_UNQ_KEY",ObjParam.ApplicationNo,
                                                       "@P_INT_SERVICEID",ObjParam.ServiceId,
                                                       "@P_INT_STATUS",ObjParam.Status,
                                                       "@P_VCH_CERTIFICATE_FILENAME",ObjParam.ApprovalDocFileLink,
                                                       "@P_VCH_REMARK",ObjParam.Remarks,
                                                       "@P_VCH_REFERENCE_DOC_NAME",ObjParam.ReferenceDocFileLink
                                                    };

                    RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FOREST_ALLOTMENT", out param, objArray).ToString();

                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 2;
                        objResponse.OutMessage = "Success";
                    }
                    else if (param.ToString() == "4")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "Invalid Application Number.";
                    }
                    else if (param.ToString() == "5")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "Invalid Service Id.";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.OutMessage = "Some Error Occured.Please Contact Administrator.";
                    }
                }

                /*-----------------------------------------------------------*/
                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("FOREST", "FEDApplicationStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "FOREST");
            }
            lstResponse.Add(objResponse);
            return lstResponse;
        }

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) payment status update through FOREST Portal.
        /// </summary>

        public List<ClsOutput> FEDPaymentStatusUpdate(ForestLicense_Entity ObjParam)
        {
            ClsOutput objResponse = new ClsOutput();
            List<ClsOutput> lstResponse = new List<ClsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim() + "Service Id :- " + ObjParam.ServiceId.ToString() + "Payment Status :- " + ObjParam.PaymentStatus.ToString();
                Util.LogRequestResponse("FOREST", "FEDPaymentStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/

                int intValid = 0;

                #region Validation

                if (ObjParam.SecurityKey.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Security key should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.SecurityKey.Trim() != strFORESTSecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (ObjParam.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.PaymentStatus.ToString().Trim() != "1")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid payment status.";
                    intValid = 1;
                }
                else if (ObjParam.PaymentAmount.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Payment amount should not be blank.";
                    intValid = 1;
                }



                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] arr = new object[] { "@P_VCH_ACTION","PU",
                                                  "@P_VCH_APPLICATION_UNQ_KEY",ObjParam.ApplicationNo,
                                                  "@P_INT_SERVICEID",ObjParam.ServiceId,
                                                  "@P_INT_PAYMENT_STATUS",ObjParam.PaymentStatus,
                                                  "@P_NUM_PAYMENT_AMOUNT",ObjParam.PaymentAmount,
                                                  "@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",ObjParam.BankTransId,
                                                  "@P_VCH_CHALLAN_NO",ObjParam.ChallanNo
                                                };

                    RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FOREST_ALLOTMENT", out param, arr).ToString();

                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 2;
                        objResponse.OutMessage = "Success";
                    }
                    else if (param.ToString() == "4")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "Invalid Application Number.";
                    }
                    else if (param.ToString() == "5")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "Invalid Service Id.";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.OutMessage = "Some Error Occured.Please Contact Administrator.";
                    }
                }

                /*-----------------------------------------------------------*/
                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("FOREST", "FEDPaymentStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "FOREST");
            }
            lstResponse.Add(objResponse);
            return lstResponse;
        }

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) Query raise update through FOREST Portal.
        /// </summary>

        //public List<ClsOutput> FEDQueryStatusUpdate(ForestLicense_Entity ObjParam)
        //{
        //    ClsOutput objResponse = new ClsOutput();
        //    List<ClsOutput> lstResponse = new List<ClsOutput>();

        //    try
        //    {
        //        ///// Write request log for each request.
        //        string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim();
        //        Util.LogRequestResponse("FOREST", "FEDQueryStatusUpdate", strInput);

        //        /*--------------------------------------------------------------------*/
        //        ////// Validation Section
        //        /*--------------------------------------------------------------------*/
        //        int intValid = 0;

        //        #region Validation

        //        if (ObjParam.SecurityKey.Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Security key should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (ObjParam.SecurityKey.Trim() != strFORESTSecurityKey)
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Invalid security key.";
        //            intValid = 1;
        //        }
        //        else if (ObjParam.ApplicationNo.Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Application number should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (ObjParam.ServiceId.ToString().Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Service id should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (ObjParam.QueryStatus.ToString().Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Query status should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (ObjParam.QueryStatus.ToString().Trim() != "5" && ObjParam.QueryStatus.ToString().Trim() != "6")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Invalid query status.";
        //            intValid = 1;
        //        }

        //        #endregion

        //        /*--------------------------------------------------------------------*/

        //        if (intValid == 0)
        //        {
        //            object[] arr = new object[] {  "@P_VCH_ACTION","QU",
        //                                           "@P_VCH_APPLICATION_UNQ_KEY",ObjParam.ApplicationNo,
        //                                           "@P_INT_SERVICEID",ObjParam.ServiceId,
        //                                           "@P_INT_QUERY_STATUS",ObjParam.QueryStatus
        //                                        };

        //            RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FOREST_ALLOTMENT", out param, arr).ToString();

        //            if (param.ToString() == "1")
        //            {
        //                objResponse.Status = 2;
        //                objResponse.OutMessage = "Success";
        //            }
        //            else if (param.ToString() == "4")
        //            {
        //                objResponse.Status = 4;
        //                objResponse.OutMessage = "Invalid Application Number.";
        //            }
        //            else if (param.ToString() == "5")
        //            {
        //                objResponse.Status = 5;
        //                objResponse.OutMessage = "Invalid Service Id.";
        //            }
        //            else
        //            {
        //                objResponse.Status = 0;
        //                objResponse.OutMessage = "Some Error Occured.Please Contact Administrator.";
        //            }
        //        }

        //        /*-----------------------------------------------------------*/
        //        ///// Write response log for each request.
        //        JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
        //        var json = jsonSerialiser.Serialize(objResponse);
        //        string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
        //        Util.LogRequestResponse("FOREST", "FEDQueryStatusUpdate", strOutput);
        //        /*-----------------------------------------------------------*/
        //    }
        //    catch (SqlException ex)
        //    {
        //        objResponse.Status = 3;
        //        objResponse.OutMessage = ex.Message;
        //        Util.LogError(ex, "FOREST");
        //    }

        //    lstResponse.Add(objResponse);
        //    return lstResponse;
        //}

        #endregion
    }
}