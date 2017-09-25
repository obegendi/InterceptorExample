namespace ValidationModule.Base
{
    public class ValidateContext
    {
        public IValidate Strategy { get; set; }

        public ValidateContext(IValidate strategy)
        {
            Strategy = strategy;
        }

        public ValidationResult DoValidation(params object[] parameters)
        {
            return Strategy.DoValidation(parameters);
        }

        public void HandleResults()
        {
            Strategy.HandleResults();
        }
    }
}