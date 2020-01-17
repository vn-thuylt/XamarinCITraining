namespace XamarinCI.Core.Infrastructure.Validations.Base
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }

        bool Check(T value);
    }
}
