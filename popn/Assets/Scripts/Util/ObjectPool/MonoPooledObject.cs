using System;
using UnityEngine;

public class MonoPooledObject : MonoBehaviour
{
    public ObjectPool Parent { get; private set; }
    public String ParentName { get; private set; }

    public void SetParent(ObjectPool parent, String name)
    {
        Parent = parent;
        ParentName = name;
    } 

    public void RemovePooledObject()
    {
        Parent.RemoveObject(this);
    }
}
