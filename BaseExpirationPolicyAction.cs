using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.RecordsManagement.InformationPolicy;

namespace ExpirationPolicies
{
    public abstract class BaseExpirationPolicyAction
    {
        public enum ActionType { DateCalculator = 1, Action = 2 }

		public static readonly string PolicyResourceManifestFormat = "<PolicyResource xmlns=\"urn:schemas-microsoft-com:office:server:policy\" id=\"{0}\" featureId=\"{1}\" type=\"{2}\"><Name>{3}</Name><Description>{4}</Description><AssemblyName>{5}</AssemblyName><ClassName>{6}</ClassName></PolicyResource>";
        public static readonly string ExpirationPolicyFeatureId = "Microsoft.Office.RecordsManagement.PolicyFeatures.Expiration";
		

        private string _className;
        private string _assemblyName;
		

        public string ID { get; set; }
        public string Name { get; set; }
        public ActionType Type { get; set; }
        public string Description { get; set; }
        public string ClassName
        {
            get
            {
                if (String.IsNullOrEmpty(_className))
                {
                    _className = GetType().FullName;
                }

                return _className;
            }
        }
        public string AssemblyName
        {
            get
            {
                if (String.IsNullOrEmpty(_assemblyName))
                {
                    _assemblyName = GetType().Assembly.FullName;
                }

                return _assemblyName;
            }
        }


        public BaseExpirationPolicyAction()
        {
            this.ID = String.Empty;
            this.Name = String.Empty;
            this.Description = String.Empty;
        }

        public BaseExpirationPolicyAction(string id, ActionType type, string name = "", string description = "")
        {
            this.ID = id;
            this.Name = name;
            this.Type = type;
            this.Description = description;
        }

        public string GetManifest()
        {
            return String.Format(BaseExpirationPolicyAction.PolicyResourceManifestFormat,
                ID,
                BaseExpirationPolicyAction.ExpirationPolicyFeatureId,
                Type.ToString(),
                Name,
                Description,
                AssemblyName,
                ClassName);
        }

        public bool TryAddPolicy()
        {
            try
            {
                PolicyResourceCollection.Add(GetManifest());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TryDeletePolicy()
        {
            try
            {
                PolicyResourceCollection.Delete(ID);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
