using System;

namespace Gradebook.Business.Helpers
{
    public static class AssertHelper
    {
        public static void AssertNotNull(string parameter, string parameterName, string errorMessage)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                throw new ArgumentNullException(parameterName, errorMessage);
            }
        }

        public static void AssertNotNull(object parameter, string parameterName, string errorMessage)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, errorMessage);
            }
        }
    }
}
