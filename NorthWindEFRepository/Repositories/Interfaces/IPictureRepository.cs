namespace NorthWindEFRepository.Repositories.Interfaces
{
    public interface IPictureRepository
    {
        Task UpdatePicture(int id, byte[]? newPicture);

        Task<Stream> ShowPicture(int id);
    }
}
