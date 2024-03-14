using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Protocol : Item
{
    [SerializeField] private string _protocolDescription;
    [SerializeField] private string _protocolID;
    [SerializeField] private TextMeshProUGUI _descriptionObject;
    [SerializeField] private TextMeshProUGUI _IDObject;

    public override void DropThis()
    {
        this.gameObject.SetActive(true);
        _playerScript.storageItem = null;
    }

    public override void TakeThis()
    {
        if (_playerScript.storageItem == null)
        {
            this.gameObject.SetActive(false);
            _playerScript.storageItem = this;
        }
    }

    public override void Use()
    {
        _descriptionObject.text = _protocolDescription;
        _IDObject.text = _protocolID;
        _UI.SetActive(true);
    }
}
