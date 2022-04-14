using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HofManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = true ;

        Invoke("RemoveShader", 5);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RemoveShader() {
        GetComponent<MeshRenderer>().material.DOFade(0, 1).OnComplete(delegate {
            gameObject.SetActive(false);
        });
        
    }
}
