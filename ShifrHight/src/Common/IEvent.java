package common;

import java.util.function.Consumer;

public interface IEvent<TEventArgs extends Object>
{
    void addCallback(Consumer<TEventArgs> listener);
    
    void removeCallback(Consumer<TEventArgs> listener);
}