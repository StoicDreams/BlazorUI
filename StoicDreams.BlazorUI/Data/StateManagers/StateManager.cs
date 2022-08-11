namespace StoicDreams.BlazorUI.Data;

public class StateManager : IStateManager
{
    public StateManager(IStorage storage)
    {
        Memory = storage;
    }

    public virtual void SubscribeToDataChanges(Guid subscriberId, Action simpleChangeHandler)
    {
        lock (ChangeHandlerLock)
        {
            SimpleChangeHandlers[subscriberId] = simpleChangeHandler;
        }
    }

    public virtual void SubscribeToDataChanges(Guid subscriberId, Action<IDictionary<string, bool>> changeHandler)
    {
        lock (ChangeHandlerLock)
        {
            ChangeHandlers[subscriberId] = changeHandler;
        }
    }

    public virtual void UnsubscribeToDataChanges(Guid subscriberId)
    {
        lock (ChangeHandlerLock)
        {
            ChangeHandlers.Remove(subscriberId);
            SimpleChangeHandlers.Remove(subscriberId);
        }
    }


    public async ValueTask SetDataAsync<TData>(string name, TData? data)
    {
        UpdatedKey(name);
        if (data == null)
        {
            await Memory.Remove(name);
            return;
        }
        await Memory.SetValue(name, data);
    }

    public ValueTask<TData?> GetDataAsync<TData>(string name)
    {
        return Memory.GetValue<TData>(name);
    }

    public virtual ValueTask TriggerChangeAsync(string? key = null)
    {
        Dictionary<string, bool> currentState;
        lock (ChangeLogLock)
        {
            if (key != null) { Changelog[key] = true; }
            currentState = Changelog.ToDictionary(k => k.Key, v => v.Value);
        }
        Action<IDictionary<string, bool>>[] handlers;
        Action[] simpleHandlers;
        lock (ChangeHandlerLock)
        {
            handlers = ChangeHandlers.Values.ToArray();
            simpleHandlers = SimpleChangeHandlers.Values.ToArray();
        }
        foreach (Action<IDictionary<string, bool>> handler in handlers)
        {
            handler?.Invoke(currentState);
        }
        foreach (Action handler in simpleHandlers)
        {
            handler?.Invoke();
        }
        lock (ChangeLogLock)
        {
            Changelog.Clear();
        }
        return ValueTask.CompletedTask;
    }
    public virtual async ValueTask ApplyChangesAsync(Func<ValueTask> changeHandler)
    {
        await changeHandler.Invoke();
        await TriggerChangeAsync("ApplyChanges");
    }

    public virtual void ApplyChanges(Action changeHandler)
    {
        changeHandler.Invoke();
        _ = TriggerChangeAsync("ApplyChanges");
    }
    protected void UpdatedKey(string key)
    {
        lock (ChangeLogLock)
        {
            Changelog[key] = true;
        }
    }

    protected IStorage Memory { get; }
    protected Dictionary<string, bool> Changelog { get; } = new();
    protected Dictionary<Guid, Action<IDictionary<string, bool>>> ChangeHandlers { get; } = new();
    protected Dictionary<Guid, Action> SimpleChangeHandlers { get; } = new();

    private readonly object DataLock = new();
    private readonly object ChangeLogLock = new();
    private readonly object ChangeHandlerLock = new();
}
