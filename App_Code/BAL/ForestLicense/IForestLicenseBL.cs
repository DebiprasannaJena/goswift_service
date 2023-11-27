#region
//******************************************************************************************************************
// File Name             :   ForestLicense/IForestLicenseBL.cs
// Description           :   Call different services and service contract for different methods for Integration of Forest Department
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
using System.ServiceModel;
using SWP_Services.DAL;
using System.Web.Script.Services;
using System.ServiceModel.Web;
using EntityLayer.ForestLicenseEntity;

/// <summary>
/// Summary description for IForestLicenseBL
/// </summary>
namespace BusinessLogicLayer.ForestBAL
{
    [ServiceContract]
    public interface IForestLicenseBL
    {
        //#region "Fetch User Profile Details For Tree Felling"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details For Tree Felling
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //[OperationContract]
        //List<ForestLicenseUserProfile> GetUserProfilesTF(ForestAuthStatus objUser);
        //#endregion
        //#region "Push User Data For Tree Felling"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Tree Felling
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //[OperationContract]
        //List<ForestPushDataStatus> SWPPushDataTreeF(ForestPushData objDATA);
        //#endregion
        //#region "Fetch User Profile Details for Tree Transit"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Tree Transit
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //[OperationContract]
        //List<ForestLicenseUserProfile> GetUserProfilesTT(ForestAuthStatus objUser);
        //#endregion
        //#region "Push User Data For Tree Transit"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Tree Transit
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //[OperationContract]
        //List<ForestPushDataStatus> SWPPushDataTreeTransit(ForestPushData objDATA);
        //#endregion
        //#region "Fetch User Profile Details for Felling Tree"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Felling Tree
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //[OperationContract]
        //List<ForestLicenseUserProfile> GetUserProfilesFellT(ForestAuthStatus objUser);
        //#endregion
        //#region "Push User Data For Felling Tree"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Felling Tree
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //[OperationContract]
        //List<ForestPushDataStatus> SWPPushDataFellT(ForestPushData objDATA);
        //#endregion

        #region Forest Department New Integration Logic add by anil

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) application status update through FOREST Portal.
        /// </summary>

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FEDApplicationStatusUpdate")]
        List<ClsOutput> FEDApplicationStatusUpdate(ForestLicense_Entity ObjParam);

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) payment status update through FOREST Portal.
        /// </summary>

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "FEDPaymentStatusUpdate")]
        List<ClsOutput> FEDPaymentStatusUpdate(ForestLicense_Entity ObjParam);

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) Query raise update through FOREST Portal.
        /// </summary>

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "FEDQueryStatusUpdate")]
        //List<ClsOutput> FEDQueryStatusUpdate(ForestLicense_Entity  ObjParam);

        #endregion
    }
}