using System;

namespace Routing.Web.Routing
{
    public static class Guard
    {
        public static void ThrowIfNull(object param, string paramName)
        {
            if(ReferenceEquals(null, param))
                throw new ArgumentNullException(paramName);
        }

        public static void AssertExpression(Func<bool> func)
        {
            if(!func.Invoke())
                throw new InvalidOperationException(func.Method.Name);
        }

    }
}