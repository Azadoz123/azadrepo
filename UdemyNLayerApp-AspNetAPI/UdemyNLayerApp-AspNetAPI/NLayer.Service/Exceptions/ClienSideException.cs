using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Exceptions
{
    public class ClienSideException : Exception
    {
        public ClienSideException(string message): base(message) 
        {

        }
    }
}
