using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] MeshRenderer groundMesh;
    [SerializeField] BoxCollider groundCollider;

    private void Start()
    {
        if(groundMesh == null) groundMesh = GetComponent<MeshRenderer>();
        if(groundCollider == null) groundCollider = GetComponent<BoxCollider>();
    }
}
