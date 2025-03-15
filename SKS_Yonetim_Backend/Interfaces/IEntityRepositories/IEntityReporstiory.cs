namespace SKS_Yonetim_Backend.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
