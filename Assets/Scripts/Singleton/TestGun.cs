using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour
{
    [SerializeField]
    Transform gun1,gun2;
    // Update is called once per frame
    void Update()
    {
        Vector3 direction1 = gun1.position - this.transform.position;
        Vector3 direction2 = gun2.position - this.transform.position;

        Vector3 direction = direction1+ direction2;
        this.transform.forward = direction;
    }
}
