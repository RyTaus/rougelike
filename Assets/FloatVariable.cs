using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variable/FloatVariable")]
public class FloatVariable : ScriptableObject {
    
    private float _value;
    public float _defaultValue;

    List<Action<float>> _listeners;

    private void OnEnable() {
        _value = _defaultValue;
        _listeners = new List<Action<float>>();
    }

    public void SetValue(float value) {
        _value = value;
        foreach (Action<float> listener in _listeners) {
            listener(_value);
        }
    }

    public float GetValue() {
        return _value;
    }

    public void RegisterListener(Action<float> listener) {
        _listeners.Add(listener);
    }

    public void UnRegisterListener(Action<float> listener) {
        _listeners.Remove(listener);
    }
}
