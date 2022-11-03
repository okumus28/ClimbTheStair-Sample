using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generic
{    public class ObjectPooling<T> : MonoSingleton<ObjectPooling<T>> where T : MonoBehaviour
    {
        public GameObject prefab;
        public int startNum;
        public int allocateNum;
        public Stack<T> poolStack = new Stack<T>();
        public Transform anchor;

        private void OnEnable()
        {
            Init();
        }
        public void Init()
        {
            Allocate(startNum);
        }

        public T Spawn()
        {
            if (poolStack.Count == 0)
            {
                Allocate(allocateNum);
            }
            T t = poolStack.Pop();
            t.gameObject.SetActive(true);
            print(poolStack.Count);
            return t;
        }

        public T Spawn(Vector3 position)
        {
            T t = Spawn();
            t.transform.position = position;
            return t;
        }

        public T Spawn(Vector3 position, Quaternion quaternion)
        {
            T t = Spawn();
            t.transform.SetPositionAndRotation(position, quaternion);
            return t;
        }

        public T Spawn(Vector3 position, Vector3 eulerAngles)
        {
            T t = Spawn();
            t.transform.position = position;
            t.transform.eulerAngles = eulerAngles;
            return t;
        }

        public void Recycle(T t)
        {
            poolStack.Push(t);
        }

        private void Allocate(int number)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                go.name = prefab.name;
                go.transform.parent = anchor;
                var t = go.GetComponent<T>();
                //poolStack.Push(t);
                t.gameObject.SetActive(false);
            }
        }
    }
}
