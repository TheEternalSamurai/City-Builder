using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button buildResidentialAreaBtn;
    public Button cancleActionBtn;
    public GameObject cancleActionPanel;

    private Action OnBuildAreaHandler;
    private Action OnCancleActionHandler;
    
    void Start()
    {
        cancleActionPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancleActionBtn.onClick.AddListener(OnCancleActionCallback);
    }

    private void OnBuildAreaCallback()
    {
        cancleActionPanel.SetActive(true);
        OnBuildAreaHandler?.Invoke();
    }

    private void OnCancleActionCallback()
    {
        cancleActionPanel.SetActive(false);
        OnCancleActionHandler?.Invoke();
    }

    public void AddListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler += listener;
    }

    public void RemoveListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler -= listener;
    }

    public void AddListenerOnCancleActionEvent(Action listener)
    {
        OnCancleActionHandler += listener;
    }

    public void RemoveListenerOnCancleActionEvent(Action listener)
    {
        OnCancleActionHandler -= listener;
    }
}
