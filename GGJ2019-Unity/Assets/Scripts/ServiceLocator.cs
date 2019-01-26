using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour {

    public static ServiceLocator Instance { get; private set; }

    public EventManager EventManager { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager = FindObjectOfType<EventManager>();
    }
}
