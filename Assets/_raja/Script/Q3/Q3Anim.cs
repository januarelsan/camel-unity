using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Q3Anim : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset, duration,delay;
    public Image left, right;



    // Update is called once per frame
    public void OnEnable()
    {
        //DoAnimates();
        Invoke("DoAnimates", delay);
    }
    public void DoAnimates() {
        left.DOKill();
        right.DOKill();
        left.transform.DOLocalMoveX(0, 0);
        left.transform.DOLocalMoveX(0, 0).OnComplete(delegate {
            left.transform.DOLocalMoveX(-1 * offset, duration);

        });


        right.transform.DOLocalMoveX(0, 0).OnComplete(delegate { 
        right.transform.DOLocalMoveX(1 * offset, duration);
        });
    //
    }
    public void OnDisable()
    {
        left.transform.DOLocalMoveX(0, 0);
        right.transform.DOLocalMoveX(0, 0);

    }
}
