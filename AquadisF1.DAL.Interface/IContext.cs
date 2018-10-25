namespace AquadisF1.DAL.Interface
{
    public interface IContext<T> where T : class
    {
        bool Create(T entity);

        T Read(int id);

        bool Update(T entity);

        bool Delete(int id);
    }
}