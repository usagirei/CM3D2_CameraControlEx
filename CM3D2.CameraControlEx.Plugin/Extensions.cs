// --------------------------------------------------
// CM3D2_CameraControlEx - Extensions.cs
// --------------------------------------------------

using System;

namespace COM3D2.CameraControlEx.Plugin
{
    public static class Extensions
    {
        public static T NextEnum<T>(this T value, int start = 0) where T : struct
        {
            if (!typeof (T).IsEnum)
                throw new ArgumentException($"Argumnent {typeof (T).FullName} is not an Enum");

            var array = (T[]) Enum.GetValues(value.GetType());
            var j = Array.IndexOf(array, value) + 1;
            return (array.Length == j)
                       ? array[start]
                       : array[j];
        }
    }
}
