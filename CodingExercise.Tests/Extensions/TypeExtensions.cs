using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodingExercise.Tests.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the value of a private field on an object instance.
        /// </summary>
        /// <remarks>
        /// Normally we could use the PrivateObject class to do this,
        /// but it is unavailable in .NET Core 2.0.
        /// See: https://github.com/Microsoft/testfx/issues/366
        /// Instead, use reflection to get the value directly.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetPrivateFieldValue<T>(this T instance, string fieldName)
        {
            var type = instance.GetType();

            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

            var fieldInfo = type.GetField(fieldName, bindingFlags);

            return fieldInfo.GetValue(instance);
        }


        /// <summary>
        /// Gets the integer value of a private field on an object instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static int? GetPrivateFieldValueInteger<T>(this T instance, string fieldName)
        {
            var value = GetPrivateFieldValue<T>(instance, fieldName);

            if (value == null) { return null; }

            return (int)value;
        }

    }
}
