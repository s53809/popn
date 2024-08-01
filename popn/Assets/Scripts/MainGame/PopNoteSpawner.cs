using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopNoteSpawner : MonoBehaviour
{
    //#todo: 노트가 스폰이 되는 함수를 짜고 그 매개변수로 도착해야하는 시간을 받는다.
    //#todo: 임시 Object Pooling을 구현한다.

    private ObjectPool _pooler;
    private Queue<MonoPooledObject> _notes = new Queue<MonoPooledObject>();

    private void Awake()
    {
        _pooler = GetComponent<ObjectPool>();
    }

    [InspectorButton("Spawn Note")]
    private void SpawnImsiNote()
    {
        MonoPooledObject pooledObject = _pooler.SpawnObject("PopNote", new Vector3(0, 5, 0));
        _notes.Enqueue(pooledObject);
    }

    [InspectorButton("Destroy Note")]
    private void DestroyImsiNote()
    {
        MonoPooledObject obj = _notes.Dequeue();
        obj.RemovePooledObject();
    }
}
