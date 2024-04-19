namespace UserValidationApi.Extension
{
    public static class StringExtention
    {
        /// <summary>
        /// Extention to tranform from string to EnumType
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enum type");
            }

            if (Enum.TryParse<TEnum>(value, true, out TEnum result))
            {
                return result;
            }

            throw new ArgumentException($"Failed to parse {value} to {typeof(TEnum).Name}");
        }
    }
}
