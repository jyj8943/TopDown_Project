using System;
using UnityEngine;

public interface IPoolable
{
    void Initialize(Action<GameObject> returnAction);
    void OnSpawn();
    void OnDespawn();
}
