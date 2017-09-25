using System.Diagnostics;
using System.Threading.Tasks;

namespace ValidationModule.Base
{
    public abstract class Validate : IValidate
    {
        public ValidationResult Result { get; private set; }

        protected Validate(ValidationResult previosResult)
        {
            this.Result = previosResult;

            if (Result == null)
            {
                Result = new ValidationResult();
            }
        }

        public void Add(bool isValid, ValidationResultItem validationResultItem)
        {
            if (!isValid)
            {
                Result.Items.Add(validationResultItem);
            }
        }

        public void HandleResults()
        {
            if (Result.Items.Count > 0)
            {
                var ex = new ValidationException(Result);

                //INFO:OK: if there is a required validation then throw exception else just log it as warning
                if (ex.IsRequired)
                {
                    throw ex;
                }
                else
                {
                    Debug.WriteLine(ex.Message);
                }
            }

        }

        public abstract ValidationResult DoValidation(params object[] parameters);
    }
}
