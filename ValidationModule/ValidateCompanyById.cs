using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationModule.Base;

namespace ValidationModule
{
    public class ValidateCompanyById : Validate
    {
        public ValidateCompanyById(ValidationResult previosResult)
            : base(previosResult)
        {
        }

        public override ValidationResult DoValidation(params object[] parameters)
        {
            ValidateCompanyGroupId(System.Convert.ToInt32(parameters[0]));

            return base.Result;
        }

        private void ValidateCompanyGroupId(int Id)
        {
            var isValid = Id > 0;
            base.Add(isValid, new ValidationResultItem("Id geçersizdir", true));
        }
    }
}
