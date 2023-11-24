using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        //protected olarak işaretlenmesi,
        //bu metodun sadece kendi sınıfı ve bu sınıftan türetilen alt sınıflar tarafından erişilebilir olduğu anlamına gelir.
        protected virtual void OnBefore(IInvocation ınvocation) { }
        protected virtual void OnSuccess(IInvocation ınvocation) { }
        protected virtual void OnException(IInvocation ınvocation,System.Exception e) { }
        protected virtual void OnAfter(IInvocation ınvocation) { }
        protected virtual void OnAfterTransaction(IInvocation ınvocation) { }
        //Virtual ı ezmek için override kullanıyoruz
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);
                throw;
            }
            finally 
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
                
            }
            OnAfter(invocation);
        }
    }
}
