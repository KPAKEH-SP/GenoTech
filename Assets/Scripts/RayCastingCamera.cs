using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RayCastingCamera : MonoBehaviour
{
    [SerializeField] private float _rayLength = 1;
    [SerializeField] private float _intensity = 10.0f; 
    [SerializeField] private float _amplitude = 5.0f; 
    [SerializeField] private SC_FPSController _playerScript;
    Vector3 nextSwayVector;
    Vector3 nextSwayPosition;
    Vector3 startLocalPosition;

    void Start()
    {
        nextSwayVector = Vector3.up * _amplitude;
        nextSwayPosition = transform.localPosition + nextSwayVector;
        startLocalPosition = transform.localPosition;
    }

    void Update()
    {
        // Take item
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, _rayLength);

            Item targetObject = null;
            try
            {
                targetObject = hit.collider.gameObject.GetComponent<Item>();
            }
            catch{}
            
            if (targetObject != null)
            {
                targetObject.TakeThis();
            }
        }

        //Camera shake
        if (_playerScript.isMove) // If player movement
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextSwayPosition, _intensity * Time.deltaTime);

            if (Vector3.SqrMagnitude(transform.localPosition - nextSwayPosition) < 0.01f)
            {
                nextSwayVector = -nextSwayVector;

                nextSwayPosition = startLocalPosition + nextSwayVector;
            }
        }

        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startLocalPosition, _intensity * Time.deltaTime);
        }
    }
}
