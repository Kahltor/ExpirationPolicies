using Microsoft.Office.RecordsManagement.PolicyFeatures;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExpirationPolicies
{
    public abstract class BaseExpirationPolicyActionExpirationAction : BaseExpirationPolicyAction, IExpirationAction
    {
        public BaseExpirationPolicyActionExpirationAction()
            : base()
        { }

        public BaseExpirationPolicyActionExpirationAction(string id, ActionType type, string name = "", string description = "")
            : base(id, type, name, description)
        { }

        public abstract void OnExpiration(SPListItem item, XmlNode parametersData, DateTime expiredDate);
    }
}
