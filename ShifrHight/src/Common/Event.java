package common;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;

public class Event<TEventArgs extends Object> implements IEvent<TEventArgs>
{
    private final List<Consumer<TEventArgs>> _listeners = new ArrayList<>();
    
    @Override
    public void addCallback(Consumer<TEventArgs> listener)
    {
        _listeners.add(listener);
    }
    @Override
    public void removeCallback(Consumer<TEventArgs> listener)
    {
        _listeners.remove(listener);
    }
    public void invoke(TEventArgs eventArgs)
    {
        _listeners.forEach(p -> p.accept(eventArgs));
    }
    
    public void clear()
    {
        _listeners.clear();
    }
}
