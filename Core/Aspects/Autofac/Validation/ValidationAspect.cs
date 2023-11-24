using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // Eğer verilen tip bir IValidator değilse hata fırlat
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a validation class");
            }

            // Validator tipini private alana ata
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // Validator tipinden bir örnek oluştur
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            // Validator'ün işlediği entity tipini bul
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            // Metotun argümanları arasında, işlenen entity tipine sahip olanları seç
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            // Seçilen her bir entity için FluentValidation kullanarak doğrulama yap
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
        //public override void OnSuccess(MethodExecutionArgs args)
        //{
        //    // Method başarılı bir şekilde tamamlandığında çalışacak kod
        //    if (args.ReturnValue is string)
        //    {
        //        args.ReturnValue = ((string)args.ReturnValue).ToUpper();
        //    }
        //}
        protected override void OnSuccess(IInvocation invocation)
        {
            LoggerTool.DebugLoggerService(invocation);
        }
        protected override void OnAfter(IInvocation invocation)
        {
            //throw new System.Exception("Using On After Interceptor");
        }
        protected override void OnException(IInvocation invocation, System.Exception exception)
        {
            //throw new System.Exception("Using On Exception Interceptor");
        }
    }
}
