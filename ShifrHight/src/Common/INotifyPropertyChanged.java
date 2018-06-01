package common;

/**
 * @author zhaka
 */
public interface INotifyPropertyChanged
{
    IEvent<String> getPropertyChanged();
}
