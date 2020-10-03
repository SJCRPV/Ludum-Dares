using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyContainer : MonoBehaviour
{
    public static DependencyContainer Instance;

    [SerializeField]
    private List<Component> componentList = null;

    public T Get<T>()
    {
        foreach (dynamic component in componentList)
        {
            if(typeof(T) == component.GetType())
            {
                return component;
            }
        }
        Debug.LogError($"I did not find an instance for {typeof(T)}. Returning a default.");
        return default;
    }

    private void initialiseComponents()
    {
        foreach (dynamic component in componentList)
        {
            try
            {
                component.Initialise();
            }
            catch (System.Exception) {}
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        initialiseComponents();
    }
}

public abstract class DCComponent : MonoBehaviour, IAmInitialisable
{
    public abstract void Initialise();
}