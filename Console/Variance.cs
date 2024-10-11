namespace Variance;

public interface IGoOut<out T>
{
    T Func();
}
public interface IComeIn<in T>
{
    void Action(T obj);
}
public class GoOutClass<T>:IGoOut<T>
{
    public T Func()
    {
        return default(T)!;
    }
}

public class ComeInClass<T> : IComeIn<T>
{
    public void Action(T obj) {  }
}