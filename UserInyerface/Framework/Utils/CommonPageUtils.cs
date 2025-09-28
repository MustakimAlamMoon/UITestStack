using UserInyerface.Framework.Pages;

namespace UserInyerface.Framework.Utils
{
    /// <summary>
    /// Provides utility methods for common page-related operations.
    /// </summary>
    internal class CommonPageUtils
    {
        /// <summary>
        /// Creates a page object based on the given page number.
        /// </summary>
        /// <param name="pageNumber">The page number to create the corresponding page object for.</param>
        /// <returns>A page object corresponding to the specified page number.</returns>
        /// <exception cref="ArgumentException">Thrown when an unknown page number is provided.</exception>
        public static object CreatePage(int pageNumber)
        {
            return pageNumber switch
            {
                1 => new Card1Page(),
                2 => new Card2Page(),
                3 => new Card3Page(),
                _ => throw new ArgumentException($"Unknown page number: {pageNumber}"),
            };
        }
    }
}
