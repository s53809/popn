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
        StartSpawning(note); //�ӽ� �ڵ�
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
            
            if(temp.type == NoteType.SpeedChange) //������ ��� ���� ó��
                curSpeed = 1 / temp.otherInfo;

            MonoPooledObject pooledObject = _pooler.SpawnObject(temp.type.ToString(), new Vector3(0, 5, 0)); //������Ʈ Ǯ��
            pooledObject.GetComponent<Note>().SpawnNote(temp.line, temp.timing, temp.otherInfo); //��Ʈ ���� �־��ֱ�
            _notes[temp.line].Enqueue(pooledObject);
            index++;
        }
        yield return null;
    }
}
