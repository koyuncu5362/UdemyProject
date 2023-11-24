using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
            //virtual olarak işaretlenmesi,
            //bu metodun bir üst sınıfta tanımlandığında alt sınıflar tarafından ezilebileceği anlamına gelir.
        }
        #region Description
        //**AttributeUsage(AttributeTargets.Class | AttributeTargets.Method**
        //Bu kod, bir özniteliğin sadece sınıflara(AttributeTargets.Class) ve 
        //metodlara(AttributeTargets.Method) uygulanabileceğini belirtir.
        //Yani, bu özniteliği bir sınıfın veya bir metodun üzerine yerleştirebilirsiniz,
        //ancak örneğin bir property üzerine yerleştiremezsiniz.
        // **AllowMultiple = true,**
        //Ayrıca, AllowMultiple = true ifadesi,
        //bu özniteliğin aynı program elemanı üzerine birden fazla kez uygulanabileceğini ifade eder.
        //Yani, aynı sınıf veya metodun üzerine bu özniteliği birden fazla kez ekleyebilirsiniz.
        // **Inherited = true**
        //Son olarak, Inherited = true ifadesi,
        //bu özniteliğin türetilmiş sınıflara miras olarak geçebileceğini belirtir.
        //Yani, eğer bir sınıfın üzerine bu özniteliği eklerseniz,
        //bu öznitelik türetilmiş sınıfların üzerine de otomatik olarak eklenir.
        //**public int Priority { get; set; }:**
        //Bu satır, Priority adında bir özellik (property) tanımlar.
        //Bu özellik, özniteliğin öncelik sırasını belirlemek için kullanılır.
        //**Intercept**
        // Bu metot, Castle.DynamicProxy kütüphanesinin IInterceptor arayüzünden türetilen sınıflar tarafından uygulanır.
        // Metot, bir IInvocation nesnesi alır, bu nesne çağrılan metot hakkında bilgi sağlar.

        // IInvocation nesnesi üzerinden çeşitli bilgilere erişebilirsiniz:
        // - invocation.Method: Çağrılan metodun bilgisini içerir.
        // - invocation.Arguments: Metoda geçilen argümanları içerir.
        // - invocation.ReturnValue: Metodun dönüş değerini alır veya ayarlar.
        // - invocation.TargetType: Hedef nesnenin tipini içerir.
        // - vb.

        // Bu noktada, bu metodu saran sınıflar, çağrılan metodu özelleştirebilir veya değiştirebilir.
        // Örneğin, belirli bir şart sağlanıyorsa metodu çağırmadan önce farklı bir işlem ekleyebilirsiniz.

        //Console.WriteLine($"Before invoking {invocation.Method.Name} method.");

        //// Metodu çağırma işlemi
        //invocation.Proceed();

        //// Metot çağrıldıktan sonra yapılacak işlemler
        //Console.WriteLine($"After invoking {invocation.Method.Name} method.");

        // Metotun dönüş değerini alabilir veya değiştirebilirsiniz.
        // Örneğin: invocation.ReturnValue = "Yeni Dönüş Değeri";
        #endregion
    }
}
