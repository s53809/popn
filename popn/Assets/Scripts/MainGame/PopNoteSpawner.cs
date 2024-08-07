using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteClass;
using System;

public class PopNoteSpawner : MonoBehaviour
{
    //#todo: 노트가 스폰이 되는 함수를 짜고 그 매개변수로 도착해야하는 시간을 받는다.
    //#todo: 임시 Object Pooling을 구현한다.

    private ObjectPool _pooler;
    private Queue<MonoPooledObject> _notes = new Queue<MonoPooledObject>();
    public List<NoteData> note;
    private Single curSpeed = 0;

    private void Awake()
    {
        _pooler = GetComponent<ObjectPool>();
        curSpeed = 0;
        StartSpawning(note);
    }

    public void StartSpawning(List<NoteData> notes)
    {
        notes.Sort();
        foreach (NoteData note in notes)
            Debug.Log(note);
    }

    private void Update()
    {
        
    }

    [InspectorButton("Spawn Note")]
    private void SpawnImsiNote()
    {
        MonoPooledObject pooledObject = _pooler.SpawnObject("PopNote", new Vector3(0, 5, 0));
        pooledObject.GetComponent<Note>().SpawnNote(5, GameOptionMemorizer.Instance.songTime + 1f, 0f);
        _notes.Enqueue(pooledObject);
    }

    [InspectorButton("Destroy Note")]
    private void DestroyImsiNote()
    {
        MonoPooledObject obj = _notes.Dequeue();
        obj.RemovePooledObject();
    }
}
