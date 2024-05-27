using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GenericLearning
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolObject
    {
        private T _prefab;
        private List<T> _objects;
        public ObjectPool(T prefab, int count)
        {
            _prefab = prefab;
            _objects = new List<T>();

            for (int i = 0; i < count; i++)
            {
                Create(prefab);
            }
        }

        public T Get()
        {
            var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

            if (obj == null)
            {
                obj = Create(_prefab);
            }

            obj.gameObject.SetActive(true);
            obj.Init();
            return obj;
        }

        private T Create(T prefab)
        {
            var obj = GameObject.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            _objects.Add(obj);
            return obj;
        }

        public void Release(T obj)
        {
            obj.Deinit();
            obj.gameObject.SetActive(false);
        }
    }

    public interface IPoolObject
    {
        public void Init();
        public void Deinit();
    }
}
