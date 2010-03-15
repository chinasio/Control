using System.Runtime.Remoting.Messaging;
using System.Web;
namespace Artech.ApplicationContexts
{
    public class ContextHttpModule:IHttpModule
    {

        public void Dispose(){}
        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += (sender, args) =>
                {
                    CallContext.SetData(ApplicationContext.ContextKey, ApplicationContext.Current);
                };
            context.PreSendRequestContent += (sender, args) =>
            {
                CallContext.SetData(ApplicationContext.ContextKey, null);
            };
        }
    }
}
