using System;
using System.Collections.Generic;
using UnityEngine;
using OnlyInObjectPool;

namespace OnlyInObjectPool
{
    [System.Serializable]
    public struct PooledObject
    {
        public MonoPooledObject obj;
        public Int32 num;
    }
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<PooledObject> _pooledObject;

    private Dictionary<String, Queue<MonoPooledObject>> _dic = new Dictionary<String, Queue<MonoPooledObject>>();
    private Dictionary<String, Int32> _indexSearch = new Dictionary<String, Int32>();

    private void Awake()
    {
        if (_pooledObject == null) return;

        for (Int32 i = 0, listSize = _pooledObject.Count; i < listSize; i++)
        {
            var element = _pooledObject[i];
            if (element.obj.gameObject == null) continue;
            
            Transform parent = new GameObject(element.obj.name + 's').transform;
            parent.SetParent(transform);

            var list = new Queue<MonoPooledObject>();
            _dic.Add(element.obj.name, list);
            _indexSearch.Add(element.obj.name, i);

            for (Int32 j = 0; j < element.num; j++)
            {
                MonoPooledObject obj = Instantiate(element.obj.gameObject, parent).GetComponent<MonoPooledObject>();
                obj.gameObject.SetActive(false);
                obj.SetParent(this, element.obj.name);
                list.Enqueue(obj);
            }
        }
    }

    public MonoPooledObject SpawnObject(String name, Vector3 pos)
    {
        if (!_dic.ContainsKey(name)) 
            throw new Exception($"\"{name}\"에 해당하는 오브젝트 이름이 없습니다.");

        if (_dic[name].Count == 0)
        {
            Int32 size = _pooledObject[_indexSearch[name]].num * 2;
            if (size == 0) size = 1;
            PooledObject temp = _pooledObject[_indexSearch[name]];
            temp.num = size;
            _pooledObject[_indexSearch[name]] = temp;
            Transform parent = transform.Find(name + 's');

            for(int i = 0; i < size; i++)
            {
                MonoPooledObject obj = Instantiate(temp.obj.gameObject, parent).GetComponent<MonoPooledObject>();
                obj.gameObject.SetActive(false);
                obj.SetParent(this, name);
                _dic[name].Enqueue(obj);
            }
        }

        MonoPooledObject pooledObject = _dic[name].Dequeue();
        pooledObject.gameObject.SetActive(true);
        pooledObject.transform.position = pos;
        return pooledObject;
    }

    public void RemoveObject(MonoPooledObject obj)
    {
        if (obj.Parent != this) throw new Exception($"{gameObject.name}은 {obj}를 회수할 수 있는 객체가 아닙니다.");
        obj.gameObject.SetActive(false);
        _dic[obj.ParentName].Enqueue(obj);
    }
    public MonoPooledObject SpawnObject(Int32 index, Vector3 pos)
    {
        return SpawnObject(_pooledObject[index].obj.name, pos);
    }
}