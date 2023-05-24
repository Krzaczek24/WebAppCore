using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Shared.Extensions
{
    public static class StringNotationExtensions
    {
        private const string SEPARATOR = "|";

        private static string ParseWords(this string input)
        {
            input = Regex.Replace(input, @"[^\p{L}\d]+", SEPARATOR);
            input = Regex.Replace(input, @"(\p{Ll})(\p{Lu})|(\p{L})(\d)|(\d)(\p{L})", Separate);
            return input.ToLower();
        }

        public static string[] SplitWords(this string input) => input.ParseWords().Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

        public static string ToCamelCase(this Enum input) => ToCamelCase(input.ToString());
        public static string ToCamelCase(this string input)
        {
            string[] words = input.SplitWords();
            string result = words[0];

            for (int i = 1; i < words.Length; i++)
                result += UpperCaseWordFirstLetter(words[i]);

            return result;
        }

        public static string ToSnakeCase(this string input) => string.Join('_', input.SplitWords());

        public static string ToKebabCase(this string input) => string.Join('-', input.SplitWords());

        public static string ToFlatCase(this string input) => string.Join(string.Empty, input.SplitWords());

        public static string ToPascalCase(this string input) => string.Join(string.Empty, input.SplitWords().Select(UpperCaseWordFirstLetter));

        private static string UpperCaseWordFirstLetter(this string input) => char.ToUpper(input[0]) + input.Substring(1);

        private static string Separate(Match match) =>
            match.Groups[1].Value +
            match.Groups[3].Value +
            match.Groups[5].Value +
            SEPARATOR +
            match.Groups[2].Value +
            match.Groups[4].Value +
            match.Groups[6].Value;
    }
}
