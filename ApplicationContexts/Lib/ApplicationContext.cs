using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Web;
namespace Artech.ApplicationContexts
{
    [Serializable]
    public class ApplicationContext : Dictionary<string, object>, ILogicalThreadAffinative
    {
        public const string ContextKey = "Artech.ApplicationContexts.ApplicationContext";
        public const string ProfileKey = "Artech.ApplicationContexts.ApplicationContext.Profile";

        public static ApplicationContext Current
        {
            get
            {
                if (null != HttpContext.Current)
                {
                    if (null == HttpContext.Current.Session[ContextKey])
                    {
                        HttpContext.Current.Session[ContextKey] = new ApplicationContext();
                    }

                    return HttpContext.Current.Session[ContextKey] as ApplicationContext;
                }

                if (null == CallContext.GetData(ContextKey))
                {
                    CallContext.SetData(ContextKey, new ApplicationContext());
                }
                return CallContext.GetData(ContextKey) as ApplicationContext;                
            }
        }

        public Profile Profile
        {
            get
            {
                if (!this.ContainsKey(ProfileKey))
                {
                    this[ProfileKey] = new Profile();
                }
                return this[ProfileKey] as Profile;  
            }
        }
    }
}







