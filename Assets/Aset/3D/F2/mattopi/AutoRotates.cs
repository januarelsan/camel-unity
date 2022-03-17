using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AutoRotates : MonoBehaviour
{
    // Start is called before the first frame update
    public float durations;
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0,0, 359), durations, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
