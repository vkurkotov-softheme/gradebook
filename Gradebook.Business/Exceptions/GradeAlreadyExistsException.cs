using System;
using System.Runtime.Serialization;

namespace Gradebook.Business.Exceptions
{
    public class GradeAlreadyExistsException: Exception
    {
        public GradeAlreadyExistsException()
        {
        }

        public GradeAlreadyExistsException(string message)
            : base(message)
        {
        }

        public GradeAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GradeAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
