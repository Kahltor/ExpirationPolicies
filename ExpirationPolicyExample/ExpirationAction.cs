using Microsoft.Office.RecordsManagement.PolicyFeatures;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Administration;

namespace ExpirationPolicies.ExpirationPolicyExample
{
    public class ExpirationAction : BaseExpirationPolicyActionExpirationAction
    {
        public ExpirationAction()
            : base()
        { }

        public ExpirationAction(string id, string name = "", string description = "")
            : base(id, ActionType.Action, name, description)
        { }

        public override void OnExpiration(SPListItem item, XmlNode parametersData, DateTime expiredDate)
        {
           item["Status"] = "Expired";
		   item["ExpiredDate"] = expiredDate;
		   
		   item.Update();
        }
    }
}
