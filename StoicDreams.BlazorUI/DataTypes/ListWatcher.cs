namespace StoicDreams.BlazorUI.DataTypes;

public class ListWatcher<TItem> : List<TItem>
{
	public ListWatcher(Action changeHandler)
	{
		ChangeHandler = changeHandler;
	}

	public new void Add(TItem item)
	{
		base.Add(item);
		TriggerChange();
	}

	public new void Remove(TItem item)
	{
		base.Remove(item);
		TriggerChange();
	}

	public new void RemoveAt(int index)
	{
		base.RemoveAt(index);
		TriggerChange();
	}

	public new void RemoveRange(int index, int count)
	{
		base.RemoveRange(index, count);
		TriggerChange();
	}

	public new void Clear()
	{
		base.Clear();
		TriggerChange();
	}

	public new void AddRange(IEnumerable<TItem> collection)
	{
		base.AddRange(collection);
		TriggerChange();
	}

	public void TriggerChange()
	{
		ChangeHandler.Invoke();
	}

	private Action ChangeHandler { get; }
}
