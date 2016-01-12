using Microsoft.Office.RecordsManagement.InformationPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpirationPolicies
{
    public abstract class BaseExpirationPolicy<TFormula, TAction>
        where TFormula : BaseExpirationPolicyActionExpirationDateCalculator, new()
        where TAction : BaseExpirationPolicyActionExpirationAction, new()
    {
        protected TFormula _expirationDateCalculator = null;
        protected TAction _expirationAction = null;

        public TFormula ExpirationDateCalculator
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
        public TAction ExpirationAction
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
