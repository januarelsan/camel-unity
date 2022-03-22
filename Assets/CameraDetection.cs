using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CameraDetection : MonoBehaviour
{
    Camera cam;
    [SerializeField] Material pintu;
    [SerializeField] Texture2D pintuTexture;
    [SerializeField] Texture2D pintuTextureDefault;
    public bool isFinish;
    [SerializeField] List<ContentHoF> contentHoFs = new List<ContentHoF>();
    public GameObject lightDoor;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        pintu.mainTexture = pintuTextureDefault;
        pintu.SetTexture("_EmissionMap", pintuTextureDefault);
        lightDoor.SetActive(false);
    }
    public void OnDestroy()
    {
        pintu.mainTexture = pintuTextureDefault;
        pintu.SetTexture("_EmissionMap", pintuTextureDefault);
        //lightDoor.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        checkData();
    }

    void checkData()
    {
        foreach(ContentHoF hof in contentHoFs)
        {
            if (IsInView(gameObject, hof.obj))
                hof.isSeen = true;
        }

        int index = contentHoFs.Where(s => s.isSeen == true).Count();
        if (index >= contentHoFs.Count())
        {
            if (!isFinish)
            {
                pintu.mainTexture = pintuTexture;
                             
                pintu.SetTexture("_EmissionMap", pintuTexture);
                lightDoor.SetActive(true);

                isFinish = true;
            }
        }
    }

    private bool IsInView(GameObject origin, GameObject toCheck)
    {
        Vector3 pointOnScreen = cam.WorldToScreenPoint(toCheck.GetComponentInChildren<Renderer>().bounds.center);

        //Is in front
        if (pointOnScreen.z < 0)
        {
            //Debug.Log("Behind: " + toCheck.name);
            return false;
        }

        //Is in FOV
        if ((pointOnScreen.x < 0) || (pointOnScreen.x > Screen.width) ||
                (pointOnScreen.y < 0) || (pointOnScreen.y > Screen.height))
        {
            //Debug.Log("OutOfBounds: " + toCheck.name);
            return false;
        }

        RaycastHit hit;
        Vector3 heading = toCheck.transform.position - origin.transform.position;
        Vector3 direction = heading.normalized;// / heading.magnitude;

        if (Physics.Linecast(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, out hit))
        {
            if (hit.transform.name != toCheck.name)
            {
                /* -->
                Debug.DrawLine(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, Color.red);
                Debug.LogError(toCheck.name + " occluded by " + hit.transform.name);
                */
                Debug.Log(toCheck.name + " occluded by " + hit.transform.name);
                return false;
            }
        }
        return true;
    }

}


[Serializable]
public class ContentHoF
{
    public GameObject obj;
    public bool isSeen;
}