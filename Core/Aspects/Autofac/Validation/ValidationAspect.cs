using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {   //reflection instance oluşturdu çalışma anında
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //productValidator'ın base type'ını bul (AbstractValidator<Product>) onun da sıfırıncı generic type'ını bul
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //eğer oradaki tip bizim entity type'ımıza eşitse onları validate yap
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
