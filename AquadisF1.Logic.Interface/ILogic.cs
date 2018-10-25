namespace AquadisF1.Logic.Interface
{
    public interface ILogic<T> where T : class {
        
        bool Create(T entity);
    
        T Read(int id);
    
        bool Update(T entity);
    
        bool Delete(int id);
    }
}