using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music3Manager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public List<BoxCollider> boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        foreach (BoxCollider box in boxCollider) {
            box.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound() {
        source.clip = clip;
        source.Play();
        foreach (BoxCollider box in boxCollider)
        {
            box.enabled = true;
        }
    }
    public void StopSound()
    {
        source.Stop();
        foreach (BoxCollider box in boxCollider)
        {
            box.enabled = false;
        }
    }
}
