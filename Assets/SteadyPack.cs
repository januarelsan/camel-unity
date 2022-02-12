using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyPack : MonoBehaviour
{
    [SerializeField] Transform cameraObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(cameraObj.localRotation.eulerAngles.x, 0,0);
        this.gameObject.transform.localRotation = Quaternion.Euler(rot);
        Debug.Log(transform.rotation);
    }
}
