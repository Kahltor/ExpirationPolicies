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
    public abstract class BaseExpirationPolicyActionExpirationDateCalculator: BaseExpirationPolicyAction, IExpirationFormula
    {
        public BaseExpirationPolicyActionExpirationDateCalculator()
            : base()
        { }

        public BaseExpirationPolicyActionExpirationDateCalculator(string id, ActionType type, string name = "", string description = "")
            : base(id, type, name, description)
        { }

        public abstract DateTime? ComputeExpireDate(SPListItem item, XmlNode parametersData);
    }
}
