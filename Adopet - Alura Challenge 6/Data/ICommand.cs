namespace Adopet___Alura_Challenge_6.Data {
    public interface ICommand<T> {
        void Create(T entity);
        void Update(T entity, int id);
        void Delete(int id);
    }
}
