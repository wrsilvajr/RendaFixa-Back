namespace RendaFixa.Domain
{
    public interface ICalcular<T> where T: class
    {
        T Calcular(T t);
    }
}
