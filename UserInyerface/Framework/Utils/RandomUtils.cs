using System.Text;

namespace UserInyerface.Framework.Utils
{
    /// <summary>
    /// Provides utility methods for generating random email addresses and passwords
    /// with specific rules and criteria.
    /// </summary>
    internal class RandomUtils
    {
        private static Random random = new Random();

        /// <summary>
        /// Generates a random email string without a domain.
        /// </summary>
        /// <returns>A randomly generated email string without a domain.</returns>
        public static string GenerateRandomEmail()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789"; // Characters allowed in the email.
            const int length = 10; // Length of the email string.

            // StringBuilder instance to construct the email string.
            StringBuilder email = new StringBuilder(length);

            // Loop to append random characters to the email StringBuilder.
            for (int i = 0; i < length; i++)
            {
                email.Append(chars[random.Next(chars.Length)]);
            }

            return email.ToString(); // Returns the generated email string.
        }

        /// <summary>
        /// Generates a password based on the local part of the email.
        /// </summary>
        /// <remarks>
        /// Password Rules:
        /// - Requires at least 10 characters.
        /// - Should have at least 1 capital letter.
        /// - Must have at least 1 numeral.
        /// - Needs at least 1 letter from the email.
        /// - Can include at least 1 Cyrillic character.
        /// </remarks>
        /// <param name="emailString">The local part of the email address used to influence the password generation.</param>
        /// <returns>A random password fulfilling the specified rules.</returns>
        public static string GenerateRandomPassword(string emailString)
        {
            const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Capital letters.
            const string smallLetters = "abcdefghijklmnopqrstuvwxyz"; // Small letters.
            const string numerals = "0123456789"; // Numerals.
            const string cyrillics = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; // Cyrillic characters.

            // Extracts distinct letters from the email string.
            string emailLetters = new string(emailString.Where(char.IsLetter).Distinct().ToArray());

            // StringBuilder instance to construct the password.
            StringBuilder password = new StringBuilder();

            // Appends required characters to the password StringBuilder.
            password.Append(capitalLetters[random.Next(capitalLetters.Length)]);
            password.Append(smallLetters[random.Next(smallLetters.Length)]);
            password.Append(numerals[random.Next(numerals.Length)]);
            password.Append(emailLetters[random.Next(emailLetters.Length)]);
            password.Append(cyrillics[random.Next(cyrillics.Length)]);

            // Ensures the password is at least 10 characters long.
            while (password.Length < 10)
            {
                const string allChars = capitalLetters + smallLetters + numerals + cyrillics;
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            // Returns the generated password string with characters in random order.
            return new string(password.ToString().ToCharArray().OrderBy(s => random.Next()).ToArray());
        }
    }
}
