using System;

public abstract class Note : MonoPooledObject
{
    public abstract void SpawnNote(Int32 num, Single timing, Single otherInfo);
}
