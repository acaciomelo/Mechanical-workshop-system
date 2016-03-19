namespace MechTech.Interfaces
{
    public interface IDados<T>
    {
        int Insert(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
