namespace MRP.Database
{
    /// <summary>
    /// Interface for Database Repositorys with specified Model
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(Guid id);
    }
}
