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
    public class ExpirationPolicy : BaseExpirationPolicy
    {
		public static readonly string AOPDocumentExpirationFormulaId = "ExpirationPolicy.Formula";
        public static readonly string AOPDocumentExpirationFormulaName = "ExpirationPolicy.DateCalculator";
        public static readonly string AOPDocumentExpirationFormulaDescription = "Checks if item is expired";

        public static readonly string AOPDocumentExpirationActionId = "ExpirationPolicy.Action";
        public static readonly string AOPDocumentExpirationActionName = "ExpirationPolicy.Action";
        public static readonly string AOPDocumentExpirationActionDescription = "Perform item expiration action";
		
        public ExpirationPolicy()
            : base()
        {
            _expirationDateCalculator = new ExpirationDateCalculator(
               ExpirationPolicy.AOPDocumentExpirationFormulaId,
               ExpirationPolicy.AOPDocumentExpirationFormulaName,
               ExpirationPolicy.AOPDocumentExpirationFormulaDescription);

            _expirationAction = new ExpirationAction(
                ExpirationPolicy.AOPDocumentExpirationActionId,
                ExpirationPolicy.AOPDocumentExpirationActionName,
                ExpirationPolicy.AOPDocumentExpirationActionDescription);
        }
    }
}