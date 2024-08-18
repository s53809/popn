using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteClass;
using System;

public class NoteSpawner : MonoBehaviour
{
    private ObjectPool _pooler;
    private List<Queue<MonoPooledObject>> _notes = new();
    public List<NoteData> note;
    private Single curSpeed = 0;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
            _notes.Add(new());

        _pooler = GetComponent<ObjectPool>();
        curSpeed = 0;
    }

    private void Start()
    {
        StartSpawning(note); //임시 코드
    }

    public void StartSpawning(List<NoteData> notes)
    {
        curSpeed = GameOptionMemorizer.Instance.noteSpeed;
        notes.Sort();

        StartCoroutine(SpawningNote(notes));
    }

    private void Update()
    {
        
    }

    private IEnumerator SpawningNote(List<NoteData> notes)
    {
        Debug.Log($"{notes.Count}");
        int index = 0;
        while (index < notes.Count)
        {
            if (notes[index].timing - curSpeed > GameOptionMemorizer.Instance.songTime) { yield return null; continue; }
            Debug.Log(index);
            NoteData temp = notes[index];
            
            if(temp.type == NoteType.SpeedChange) //변속일 경우 예외 처리
                curSpeed = 1 / temp.otherInfo;

            MonoPooledObject pooledObject = _pooler.SpawnObject(temp.type.ToString(), new Vector3(0, 5, 0)); //오브젝트 풀러
            pooledObject.GetComponent<Note>().SpawnNote(temp.line, temp.timing, temp.otherInfo); //노트 정보 넣어주기
            _notes[temp.line].Enqueue(pooledObject);
            index++;
        }
        yield return null;
    }
}
