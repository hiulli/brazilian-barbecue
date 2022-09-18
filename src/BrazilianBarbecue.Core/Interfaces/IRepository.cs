namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
