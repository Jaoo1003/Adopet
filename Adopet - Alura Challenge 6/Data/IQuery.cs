namespace Adopet___Alura_Challenge_6.Data {
    public interface IQuery<T> {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }
}
