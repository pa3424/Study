
namespace Clone
{
    public static class CloneHelper
    {
        public static T GetClone<T>(this T @this) where T : ICloneable, new()
        {
            T clone = new();

            foreach (System.Reflection.PropertyInfo propInfo in typeof(T).GetProperties())
            {
                object? propValue = propInfo.GetValue(@this);
                if (propValue is ICloneable cloneable)
                {
                    propInfo.SetValue(clone, cloneable.Clone());
                }
                else if (propValue?.GetType().IsValueType ?? false)
                {
                    propInfo.SetValue(clone, propValue);
                }
            }

            return clone;
        }
    }
}
