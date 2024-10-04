using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void SpawnAction();
    public static event SpawnAction OnSpawnRequested;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnSpawnRequested?.Invoke();
        }
    }
}
