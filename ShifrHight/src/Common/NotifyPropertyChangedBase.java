package common;

/**
 * @author zhaka
 */
public abstract class NotifyPropertyChangedBase implements INotifyPropertyChanged
{
    private final Event<String> _propertyChanged = new Event<>();
    
    protected void onPropertyChanged(String propertyName)
    {
        _propertyChanged.invoke(propertyName);
    }

    @Override
    public IEvent<String> getPropertyChanged()
    {
        return _propertyChanged;
    }
}
