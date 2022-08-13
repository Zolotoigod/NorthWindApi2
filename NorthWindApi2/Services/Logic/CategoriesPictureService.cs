using NorthWindEFRepository.Repositories;
using NorthWindEFRepository.Repositories.Interfaces;

namespace NorthWindApi2.Services
{
    public class CategoriesPictureService : IPictureService
    {
        private readonly IPictureRepository repository;

        public CategoriesPictureService(IPictureRepository repository)
        {
            this.repository = repository;
        }

        public async Task DestroyPicture(int categoryId)
        {
            await repository.UpdatePicture(categoryId, null);            
        }

        public async Task<Stream> ShowPicture(int categoryId)
        {
            return await repository.ShowPicture(categoryId);
        }

        public async Task UpdatePicture(int categoryId, Stream stream, int contentLenth)
        {
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes);

            await repository.UpdatePicture(categoryId, bytes);
        }
    }
}
