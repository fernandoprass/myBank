using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API.Helpers
{
    public abstract class BaseResponse : IComparable
    {
        public string Message { get; private set; }

        public int Code { get; private set; }

        protected BaseResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public override string ToString() => Message;

        public static IEnumerable<T> GetAll<T>() where T : BaseResponse
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as BaseResponse;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Code.Equals(otherValue.Code);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Code.CompareTo(((BaseResponse)other).Code);
    }
}
