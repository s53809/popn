using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteClass;

public class PopNoteSpawner : MonoBehaviour
{
    //#todo: ��Ʈ�� ������ �Ǵ� �Լ��� ¥�� �� �Ű������� �����ؾ��ϴ� �ð��� �޴´�.
    //#todo: �ӽ� Object Pooling�� �����Ѵ�.

    private ObjectPool _pooler;
    private Queue<MonoPooledObject> _notes = new Queue<MonoPooledObject>();
    public List<NoteData> note;

    private void Awake()
    {
        _pooler = GetComponent<ObjectPool>();
        StartSpawning(note);
    }

    public void StartSpawning(List<NoteData> notes)
    {
        notes.Sort();
        foreach (NoteData note in notes)
            Debug.Log(note);
    }

    [InspectorButton("Spawn Note")]
    private void SpawnImsiNote()
    {
        MonoPooledObject pooledObject = _pooler.SpawnObject("PopNote", new Vector3(0, 5, 0));
        pooledObject.GetComponent<Note>().SpawnNote(5, GameOptionMemorizer.Instance.songTime + 1.5f, 0f);
        _notes.Enqueue(pooledObject);
    }

    [InspectorButton("Destroy Note")]
    private void DestroyImsiNote()
    {
        MonoPooledObject obj = _notes.Dequeue();
        obj.RemovePooledObject();
    }
}
