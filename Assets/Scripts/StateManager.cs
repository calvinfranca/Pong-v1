using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        GAME_OVER
    }

    public Dictionary<States, StateBase> dictionaryState;
    public StateBase _currentState;

    

    public static StateManager Instance;

    private void Awake()
    {
        Instance = this;
        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateMainMenu());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.GAME_OVER, new StateGameOver());

        SwitchState(States.MENU);
    }

    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();
        _currentState = dictionaryState[state];
        _currentState.OnStateEnter();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchState(States.PLAYING);
        }
        //Debug.Log(_currentState);
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }

    public void MainMenu()
    {
        SwitchState(States.MENU);
    }

    public void PlayGame()
    {
        SwitchState(States.PLAYING);
    }


}
