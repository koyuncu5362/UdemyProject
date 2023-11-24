using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        // FluentValidation kullanarak bir nesneyi doğrulayan metot
        public static void Validate(IValidator validator, object entity)
        {
            // 1. ValidationContext oluşturma
            var context = new ValidationContext<object>(entity);

            // 2. Doğrulama işlemini gerçekleştirme
            var result = validator.Validate(context);

            // 3. Doğrulama sonucunu kontrol etme
            if (!result.IsValid)
            {
                // 4. Eğer doğrulama başarısızsa, ValidationException fırlatma
                throw new ValidationException(result.Errors);
            }
        }
    }
}
