using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotate : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject pivotObject;
    public Vector3 defaultePos;
    // Start is called before the first frame update
    void Start()
    {
        //pivotObject.transform.DORotate(new Vector3(0, 359, 0), 5, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        defaultePos = transform.localPosition;
    }
    private void Awake()
    {
        defaultePos = transform.localPosition;

    }
    private void OnEnable()
    {
        ReRotate();
    }
    private void OnDisable()
    {
        transform.DOKill();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);

    }
    public void ReRotate()
    {
        pivotObject.transform.DOKill();
        transform.DOKill();
        transform.DOLocalMove(defaultePos, 0);
        pivotObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0).OnComplete(
            delegate
            {
                pivotObject.transform.DOLocalRotate(new Vector3(0, 359, 0), 7, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

            }
            );

    }
}
