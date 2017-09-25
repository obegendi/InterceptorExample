using System;
using System.Linq;
using System.Text;

namespace ValidationModule.Base
{
    [Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly",
        Justification = "SecurityTransparent types cannot override GetObjectData, and this type does not serialize its instance fields anyway.")]
    public class ValidationException : Exception
    {
        private ValidationResult Result;

        public bool IsRequired
        {
            get
            {
                return Result.Items.Count(x => x.IsRequired == true) > 0;
            }
        }

        public ValidationException(ValidationResult result)
            : base()
        {
            this.Result = result;
        }

        public override string Message
        {
            get
            {
                var message = new StringBuilder();
                Result.Items.ForEach(r => message.Append(r.Message + Environment.NewLine));
                return message.ToString().TrimEnd(Environment.NewLine.ToCharArray());
            }
        }
    }
}