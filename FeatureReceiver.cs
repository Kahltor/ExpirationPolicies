using Microsoft.Office.RecordsManagement.InformationPolicy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using ExpirationPolicies.ExpirationPolicyExample;

namespace ExpirationPolicies
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("12c5a856-9f4d-46ff-9a09-be3565411c41")]
    public class FeatureReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = properties.Feature.Parent as SPWebApplication;

            ExpirationPolicy ItemExpirationPolicy = new ExpirationPolicy();

            ItemExpirationPolicy.TryAddPolicy();
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            ExpirationPolicy ItemExpirationPolicy = new ExpirationPolicy();

            ItemExpirationPolicy.TryDeletePolicy();
        }

        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
