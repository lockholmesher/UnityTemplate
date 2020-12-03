using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClampRotation : MonoBehaviour
{
    [SerializeField]
    GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Target.transform.position - transform.position;
        Quaternion quaternion = Quaternion.LookRotation(direction);
        Quaternion LocalRotation = Quaternion.Inverse(transform.parent.transform.rotation) * quaternion;

        //if (LocalRotation.eulerAngles.y >= 0 && LocalRotation.eulerAngles.y <= 90)
        //{
            this.transform.localRotation = LocalRotation;
        //}

    }
}
