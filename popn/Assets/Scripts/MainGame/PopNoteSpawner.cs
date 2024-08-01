using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopNoteSpawner : MonoBehaviour
{
    //#todo: ��Ʈ�� ������ �Ǵ� �Լ��� ¥�� �� �Ű������� �����ؾ��ϴ� �ð��� �޴´�.
    //#todo: �ӽ� Object Pooling�� �����Ѵ�.

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
