namespace ValidationModule.Base
{
    public interface IValidate
    {
        ValidationResult DoValidation(params object[] parameters);
        void HandleResults();
    }
}