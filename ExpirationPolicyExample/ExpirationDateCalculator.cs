using Microsoft.Office.RecordsManagement.PolicyFeatures;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExpirationPolicies.ExpirationPolicyExample
{
    public class ExpirationDateCalculator : BaseExpirationPolicyActionExpirationDateCalculator
    {
        public ExpirationDateCalculator()
            : base()
        { }

        public ExpirationDateCalculator(string id, string name = "", string description = "")
            : base(id, ActionType.DateCalculator, name, description)
        { }

        public override DateTime? ComputeExpireDate(SPListItem item, XmlNode parametersData)
        {
            if (item["Status"] == "Completed")
			{
				return DateTime.Now;
			}
			else
			{
				return null;
			}
        }
    }
}