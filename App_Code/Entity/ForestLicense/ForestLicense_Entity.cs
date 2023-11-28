using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForestLicense_Entity
/// </summary>
/// 

namespace EntityLayer.ForestLicenseEntity
{

    public class ForestLicense_Entity
    {
        public ForestLicense_Entity()
        {
            
        }

        public int Status { get; set; }
        public int PaymentStatus { get; set; }
        public string BankTransId { get; set; }
        public string ChallanNo { get; set; }
        public decimal PaymentAmount { get; set; }
        public string ApprovalDocFileLink { get; set; }
        public string Remarks { get; set; }
        public int QueryStatus { get; set; }
        public string ApplicationNo { get; set; }
        public int ServiceId { get; set; }
        public string SecurityKey { get; set; }
        public string ReferenceDocFileLink { get; set; }
    }

    public class ClsOutput
    {
        public int Status { get; set; }
        public string OutMessage { get; set; }

        
    }
}