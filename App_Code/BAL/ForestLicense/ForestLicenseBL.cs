#region
//******************************************************************************************************************
// File Name             :   ForestLicense/ForestLicenseBL.cs
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
using SWP_Services.DAL;
using System.ServiceModel.Web;
using EntityLayer.ForestLicenseEntity;
using DataAcessLayer.ForestLicenseDAL;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace BusinessLogicLayer.ForestBAL
{
    public class ForestLicenseBL : IForestLicenseBL
    {

        ForestLicenseDAL obj = new ForestLicenseDAL();

        
        //#region "Fetch User Profile Details For Tree Felling"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details For Tree Felling
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesTF")]
        //public List<ForestLicenseUserProfile> GetUserProfilesTF(ForestAuthStatus objUser)
        //{
        //    return obj.GetUserProfilesTF(objUser);
        //}
        //#endregion
        //#region "Push User Data For Tree Felling"
        ///// <summary>
        ///// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Tree Felling
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataTF")]
        //public List<ForestPushDataStatus> SWPPushDataTreeF(ForestPushData objDATA)
        //{
        //    return obj.SWPPushDataTreeF(objDATA);
        //}
        //#endregion
        //#region "Fetch User Profile Details for Tree Transit"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Tree Transit
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesTT")]
        //public List<ForestLicenseUserProfile> GetUserProfilesTT(ForestAuthStatus objUser)
        //{
        //    return obj.GetUserProfilesTT(objUser);
        //}
        //#endregion
        //#region "Push User Data For Tree Transit"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Tree Transit
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataTT")]
        //public List<ForestPushDataStatus> SWPPushDataTreeTransit(ForestPushData objDATA)
        //{
        //    return obj.SWPPushDataTreeTransit(objDATA);
        //}
        //#endregion
        //#region "Fetch User Profile Details for Felling Tree"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Felling Tree
        ///// </summary>
        ///// <param name="objUser"></param>
        ///// <returns></returns>
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesFT")]
        //public List<ForestLicenseUserProfile> GetUserProfilesFellT(ForestAuthStatus objUser)
        //{
        //    return obj.GetUserProfilesFellT(objUser);
        //}
        //#endregion
        //#region "Push User Data For Felling Tree"
        ///// <summary>
        ///// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Felling Tree
        ///// </summary>
        ///// <param name="objDATA"></param>
        ///// <returns></returns>
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataFT")]
        //public List<ForestPushDataStatus> SWPPushDataFellT(ForestPushData objDATA)
        //{
        //    return obj.SWPPushDataFellT(objDATA);
        //}

        //#endregion

        #region Forest Department New Integration Logic add by anil

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) application status update through FOREST Portal.
        /// </summary>

        public List<ClsOutput> FEDApplicationStatusUpdate(ForestLicense_Entity ObjParam)
        {
            return obj.FEDApplicationStatusUpdate(ObjParam);
        }

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) payment status update through FOREST Portal.
        /// </summary>


        public List<ClsOutput> FEDPaymentStatusUpdate(ForestLicense_Entity ObjParam)
        {
            return obj.FEDPaymentStatusUpdate(ObjParam);
        }

        /// <summary>
        /// Created By Anil Sahoo on 12-May-2023 for (TF & TT) Query raise update through FOREST Portal.
        /// </summary>
        //public List<ClsOutput> FEDQueryStatusUpdate(ForestLicense_Entity ObjParam)
        //{
        //    return obj.FEDQueryStatusUpdate(ObjParam);
        //}
        #endregion
    }
}