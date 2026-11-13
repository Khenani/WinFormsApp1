
using System;

namespace WinFormsApp1.Services
{
    internal static class FuzzyMatcher
    {
        public static bool IsSimilar(string input, string keyword)
        {
            if (string.IsNullOrWhiteSpace(input) ||
                string.IsNullOrWhiteSpace(keyword))
                return false;

            input = input.ToLower().Trim();
            keyword = keyword.ToLower().Trim();

            if (input.Contains(keyword))
                return true;

            int distance = GetLevenshteinDistance(input, keyword);

            int allowedErrors = keyword.Length >= 6 ? 2 : 1;

            return distance <= allowedErrors;
        }

        private static int GetLevenshteinDistance(string first, string second)
        {
            int[,] matrix = new int[first.Length + 1, second.Length + 1];

            for (int i = 0; i <= first.Length; i++)
                matrix[i, 0] = i;

            for (int j = 0; j <= second.Length; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    int cost = first[i - 1] == second[j - 1] ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(
                            matrix[i - 1, j] + 1,
                            matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }

            return matrix[first.Length, second.Length];
        }
    }
}
