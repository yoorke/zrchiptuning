using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Utility.ExceptionHandling
{
    [Serializable]
    public class DLException : BaseException
    {
        public DLException()
            : base()
        {

        }

        public DLException(string message)
            : base(message)
        {

        }

        public DLException(string format, params object[] args)
            : base(string.Format(format, args))
        {

        }

        public DLException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public DLException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {

        }

        protected DLException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
