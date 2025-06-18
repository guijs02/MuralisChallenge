using FluentValidation;
using Muralis.Domain.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Factory
{
    public class ValidationFactory
    {
        public static void Validate<T>(T entity, IValidator<T> validator) where T : Entity
        {
            var context = new ValidationContext<T>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    entity.Notification.AddErro(entity.GetType().Name, item.ErrorMessage);
                }
            }
        }
    }
}
