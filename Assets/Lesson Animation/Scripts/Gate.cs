using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gate : MonoBehaviour
{
    [SerializeField] private string _openAnimationName;
    [SerializeField] private string _closeAnimationName;
    private Animator _animator;
    private bool _opened = false;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Open()
    {
        _animator.Play(_openAnimationName);
    }

    private void Close()
    {
        _animator.Play(_closeAnimationName);
    }

    public void Toggle()
    {
        if (_coroutine != null)
            return;

        if (_opened)
            Close();
        else
            Open();

        float duration = _animator.GetCurrentAnimatorStateInfo(0).length;
        _coroutine = StartCoroutine(SwitchOpened(duration));
    }

    private IEnumerator SwitchOpened(float time)
    {
        yield return new WaitForSeconds(time);
        _coroutine = null;
        _opened = !_opened;
    }
}