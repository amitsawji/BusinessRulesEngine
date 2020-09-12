namespace BusinessRulesEngine.Models
{
    public class Book : IProduct
    {
        /// <summary>
        /// Name of Author
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Genre of the book e.g. Thriller,Romance etc. String type
        /// is kept for simplicity
        /// </summary>
        public string Genre { get; set; }
    }
}
