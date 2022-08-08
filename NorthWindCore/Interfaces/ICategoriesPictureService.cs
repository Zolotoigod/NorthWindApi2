namespace NorthWindApi2.Services
{
    public interface ICategoriesPictureService
    {
        /// <summary>
        /// Try to show a product category picture.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <param name="bytes">An array of picture bytes.</param>
        /// <returns>True if a product category is exist; otherwise false.</returns>
        Task<Stream> ShowPicture(int categoryId);

        /// <summary>
        /// Update a product category picture.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <param name="stream">A <see cref="Stream"/>Stream</param>
        /// <returns>True if a product category is exist; otherwise false.</returns>
        Task UpdatePicture(int categoryId, Stream stream, int contentLenth);

        /// <summary>
        /// Destroy a product category picture.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <returns>True if a product category is exist; otherwise false.</returns>
        Task DestroyPicture(int categoryId);
    }
}
