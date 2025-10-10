namespace MRP.Database
{
    /// <summary>
    /// Repository-Interface for specified Model
    /// </summary>
    /// <typeparam name="TModel">Model</typeparam>
    internal interface IRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel? GetById(Guid id);
        bool Add(TModel entity);
        bool Update(TModel entity);
        bool DeleteById(Guid id);
    }
}
