﻿using System;
using UnityEngine;

public interface IInputManager
{
    void AddListenerOnPointerDownEvent(Action<Vector3> listener);
    void AddListenerOnPointerUpEvent(Action listener);
    void AddListenerOnPointerChangeEvent(Action<Vector3> listener);
    void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
    void AddListenerOnPointerSecondUpEvent(Action listener);
    void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerUpEvent(Action listener);
    void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerSecondUpEvent(Action listener);
}