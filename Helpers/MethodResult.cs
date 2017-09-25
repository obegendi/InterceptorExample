using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class MethodResult
    {
        public bool IsSuccessfull { get; set; }
        public string ExceptionDetail { get; set; }

        public MethodResult()
        {
        }

        public MethodResult(bool isSuccessfull)
        {
            IsSuccessfull = isSuccessfull;
        }
    }

    public class MethodResult<T> : MethodResult where T : class
    {
        public T Result { get; set; }

        public MethodResult()
        {
        }

        public MethodResult(bool isSuccessfull)
        {
            IsSuccessfull = isSuccessfull;
        }
    }

    public class SuccessResult : MethodResult<object>
    {
        public SuccessResult()
            : base(true)
        { }
    }

    public class SuccessResult<T> : MethodResult<T> where T : class
    {
        public SuccessResult()
            : base(true)
        { }
    }
}
