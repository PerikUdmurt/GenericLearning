using System.Collections;
using UnityEngine;
using GenericLearning;

public class Object : MonoBehaviour, IPoolObject
{
    void IPoolObject.Deinit()
    {
        Debug.Log("Deinit");
    }

    void IPoolObject.Init()
    {
        Debug.Log("Init");
    }
}
