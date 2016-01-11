using Microsoft.Office.RecordsManagement.InformationPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpirationPolicies
{
    public abstract class BaseExpirationPolicy
    {
        protected BaseExpirationPolicyActionExpirationDateCalculator _expirationDateCalculator = null;
        protected BaseExpirationPolicyActionExpirationAction _expirationAction = null;

        public BaseExpirationPolicyActionExpirationDateCalculator ExpirationDateCalculator
        {
            get
            {
                return _expirationDateCalculator;
            }
            set
            {
                _expirationDateCalculator = value;
            }
        }
        public BaseExpirationPolicyActionExpirationAction ExpirationAction
        {
            get
            {
                return _expirationAction;
            }
            set
            {
                _expirationAction = value;
            }
        }

        public BaseExpirationPolicy()
        { }

        public bool TryAddPolicy()
        {
            bool result = true;

            if (ExpirationDateCalculator != null)
            {
                result = ExpirationDateCalculator.TryAddPolicy();
            }

            if (result && ExpirationAction != null)
            {
                result = ExpirationAction.TryAddPolicy();
            }

            return result;
        }

        public bool TryDeletePolicy()
        {
            bool result = true;

            if (ExpirationDateCalculator != null)
            {
                result = ExpirationDateCalculator.TryDeletePolicy();
            }

            if (result && ExpirationAction != null)
            {
                result = ExpirationAction.TryDeletePolicy();
            }

            return result;
        }
    }
}
