using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A2QManager : MonoBehaviour
{
    public Image toChange;
    public List<Sprite> images;

    // Start is called before the first frame update
    void Start()
    {
        randomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomize() {
        int rand = Random.Range(0, images.Count);
        Debug.Log(rand);
        toChange.sprite = images[rand];
    
    }
}
