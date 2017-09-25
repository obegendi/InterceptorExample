using System.Collections.Generic;

namespace ValidationModule.Base
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Items = new List<ValidationResultItem>();
        }

        public List<ValidationResultItem> Items { get; set; }

        public bool HasItem
        {
            get
            {
                return Items != null && Items.Count > 0;
            }
        }
    }
}