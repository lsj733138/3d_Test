
public interface IWeaponObservable<T>
{
    public void Subscribe(IWeaponObserver<T> observer);
    public void UnSubscribe(IWeaponObserver<T> observer);
    public void Notify(T value);
}
