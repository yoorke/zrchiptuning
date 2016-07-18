using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Utility.ExceptionHandling
{
    [Serializable]
    public class BLException : BaseException
    {
        public BLException()
            : base()
        {

        }

        public BLException(string message)
            : base(message)
        {

        }

        public BLException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public BLException(string format, params object[] args)
            : base(string.Format(format, args))
        {

        }

        public BLException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {

        }

        protected BLException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
