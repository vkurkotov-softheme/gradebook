using System;
using System.Runtime.Serialization;

namespace Gradebook.Business.Exceptions
{
    public class SubjectAlreadyExistsException : Exception
    {
        public SubjectAlreadyExistsException()
        {
        }

        public SubjectAlreadyExistsException(string message)
            : base(message)
        {
        }

        public SubjectAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SubjectAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
