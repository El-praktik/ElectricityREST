namespace ElectricityREST.InterFaces
{
    public interface IDbService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddObjectAsync(T obj);
        Task DeleteObjectAsync(T obj);
        Task<T> GetObjectByIdAsync(int id);

    }
}
