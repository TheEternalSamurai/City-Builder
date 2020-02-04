﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button buildResidentialAreaBtn;
    public Button cancleActionBtn;
    public GameObject cancleActionPanel;
    public GameObject buildingMenuPanel;
    public Button openBuildMenuBtn;
    public Button demolishBtn;

    private Action OnBuildAreaHandler;
    private Action OnCancleActionHandler;
    private Action OnDemolishActionHandler;

    void Start()
    {
        cancleActionPanel.SetActive(false);
        buildingMenuPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancleActionBtn.onClick.AddListener(OnCancleActionCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        demolishBtn.onClick.AddListener(OnDemolishHandler);
    }

    private void OnDemolishHandler()
    {
        cancleActionPanel.SetActive(true);
        OnDemolishActionHandler?.Invoke();
        buildingMenuPanel.SetActive(false);
    }

    private void OnOpenBuildMenu()
    {
        buildingMenuPanel.SetActive(true);
    }

    private void OnBuildAreaCallback()
    {
        cancleActionPanel.SetActive(true);
        buildingMenuPanel.SetActive(false);
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

    public void AddListenerOnDemolishActionEvent(Action listener)
    {
        OnDemolishActionHandler += listener;
    }

    public void RemoveListenerOnDemolishActionEvent(Action listener)
    {
        OnDemolishActionHandler -= listener;
    }
}
