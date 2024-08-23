using System;

public abstract class Note : MonoPooledObject
{
    protected Boolean isActive = false;
    public virtual void SpawnNote(Int32 num, Single timing, Single otherInfo)
    {
        isActive = true;
    }

    protected virtual void Update()
    {
        if (!isActive) return;
    }
}
