namespace Adopet___Alura_Challenge_6.Data {
    public interface ICommand<T> {
        bool Create(T entity);
        bool Update(T entity, int id);
        bool Delete(int id);
    }
}
