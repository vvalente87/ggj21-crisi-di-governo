using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour {
    [SerializeField] private GameStateEvent onChangeState;

    #region SINGLETON PATTERN

    private static GameState _instance;

    public static GameState Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<GameState>();

                if (_instance == null) {
                    GameObject container = new GameObject("GameState");
                    _instance = container.AddComponent<GameState>();
                }
            }

            return _instance;
        }
    }

    public void OnDestroy() {
        _instance = null;
    }

    #endregion


    public enum State {
        Run,
        GameOver,
        Pause
    }

    private State _state;

    public State CurrentState {
        get => _state;
        set {
            if (_state != value) {
                _state = value;
                onChangeState.Invoke(_state);
                if (_state == State.Pause)
                    Cursor.visible = true;
                else
                {
                    Cursor.visible = false;
                }
            }
        }
    }


    [Serializable]
    public class GameStateEvent : UnityEvent<GameState.State> {
    }
}