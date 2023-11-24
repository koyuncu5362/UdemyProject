using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            // Sınıf üzerine eklenmiş MethodInterceptionBaseAttribute'ları al
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            // Metot üzerine eklenmiş MethodInterceptionBaseAttribute'ları al
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            // Sınıf ve metot üzerine eklenmiş MethodInterceptionBaseAttribute'ları birleştir
            classAttributes.AddRange(methodAttributes);

            // Priority özelliğine göre sırala ve döndür
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
