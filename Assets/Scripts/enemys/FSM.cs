using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    State currentState;

    public List<State> nextStates;
    private void Awake()
    {
        nextStates = new List<State>(GetComponents<State>());
        currentState = GetComponent<AppearState>();
        currentState.OnEnter();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public void ChangeState<T>() where T : Component
    {
        currentState.OnExit();
        currentState = GetState<T>();
        currentState.OnEnter();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTrigger(collision);
    }

    State GetState<T>() where T : Component
    {
        foreach (var item in nextStates)
        {
            if (item.GetType() == typeof(T))
            {
                return item;
            }
        }
        return null;
    }
}
