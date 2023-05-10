using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //string defaultu null
        //int defaultu 0
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data, bool success) : base(data, false)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
