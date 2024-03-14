using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected SC_FPSController _playerScript;
    [SerializeField] protected GameObject _UI;
    public abstract void DropThis();

    public abstract void TakeThis();

    public abstract void Use();

    internal void CloseUI()
    {
        _UI.SetActive(false);
        _playerScript.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
