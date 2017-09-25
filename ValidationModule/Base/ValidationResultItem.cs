using System;

namespace ValidationModule.Base
{
    [Serializable]
    public class ValidationResultItem
    {
        public string Message { get; set; }
        public bool IsRequired { get; set; }

        public ValidationResultItem(string message, bool isRequired)
        {
            this.Message = message;
            this.IsRequired = isRequired;
        }
    }
}