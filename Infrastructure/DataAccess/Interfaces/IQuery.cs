namespace Infrastructure.DataAccess.Interfaces
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
