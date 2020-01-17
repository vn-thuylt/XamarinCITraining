using System.Collections;
using XamarinCI.Core.Shared;
using System;
using XamarinCI.Core.Infrastructure.Validations.Base;

namespace XamarinCI.Core.Infrastructure.Validations.DefinedRules
{
    /// <summary>
    /// [String | Collection] Is not null or empty rule.
    /// </summary>
    public class RequiredRule<T> : IValidationRule<T>
    {
        public RequiredRule()
        {
            var type = typeof(T);
            if (type != typeof(string) && !TypeHelper.IsEnumerableType(type))
                throw new NotSupportedException($"The rule {GetType().Name} was not support for type {type.FullName}");
        }

        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            var inputType = typeof(T);
            /* ==================================================================================================
             * for string value. return directly
             * ================================================================================================*/
            if (inputType == typeof(string))
            {
                var str = value as string;
                return !string.IsNullOrWhiteSpace(str);
            }

            /* ==================================================================================================
             * for collection type values.
             * ================================================================================================*/
            if (TypeHelper.IsEnumerableType(inputType))
            {
                var enumerable = value as IEnumerable;
                var enumerator = enumerable.GetEnumerator();
                var toReturn = enumerator.MoveNext();
                /* ==================================================================================================
                 * Cleanup. We can not use 'using' directly here. Just manual cast
                 * bc IEnumberable does not implement IDisposable like IEnumerable<>
                 * ================================================================================================*/
                var disposable = enumerator as IDisposable;
                disposable?.Dispose();
                return toReturn;
            }
            /* ==================================================================================================
             * other wise => false
             * ================================================================================================*/
            return false;
        }
    }
}
