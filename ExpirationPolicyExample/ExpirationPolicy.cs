using Microsoft.Office.RecordsManagement.InformationPolicy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpirationPolicies.ExpirationPolicyExample
{
    public class ExpirationPolicy : BaseExpirationPolicy<ExpirationDateCalculator, ExpirationAction>
    {
		public static readonly string ItemExpirationFormulaId = "ExpirationPolicy.Formula";
        public static readonly string ItemExpirationFormulaName = "ExpirationPolicy.DateCalculator";
        public static readonly string ItemExpirationFormulaDescription = "Checks if item is expired";

        public static readonly string ItemExpirationActionId = "ExpirationPolicy.Action";
        public static readonly string ItemExpirationActionName = "ExpirationPolicy.Action";
        public static readonly string ItemExpirationActionDescription = "Perform item expiration action";
		
        public ExpirationPolicy()
            : base()
        {
            _expirationDateCalculator = new ExpirationDateCalculator(
               ExpirationPolicy.ItemExpirationFormulaId,
               ExpirationPolicy.ItemExpirationFormulaName,
               ExpirationPolicy.ItemExpirationFormulaDescription);

            _expirationAction = new ExpirationAction(
                ExpirationPolicy.ItemExpirationActionId,
                ExpirationPolicy.ItemExpirationActionName,
                ExpirationPolicy.ItemExpirationActionDescription);
        }
    }
}