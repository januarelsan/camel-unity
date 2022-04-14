using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;
using UnityEngine.SceneManagement;

public class PintuBuka : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Animator anim;
    [SerializeField] CameraDetection objDetection;
    [SerializeField] Material doorMat;
    [SerializeField] Texture2D doorTex;
    bool isEnable;

    private string identity_no;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (objDetection.isFinish)
        {
            isEnable = true;
        }
    }
    public void OnMouseDown()
    {
        if (isEnable)
        {
            doorMat.mainTexture = doorTex;
            anim.SetTrigger("pintu");
            door.SetActive(true);

            Invoke("Delayss", 1);

            //List<string> parameter_id = new List<string>();                                 
            //parameter_id.Add("20");


            //identity_no = PlayerPrefController.Instance.GetIdentityNumber();
            //Debug.Log(identity_no);
            //APIController.Instance.Get("link/get", CallGetLinkLobbyAPIResponse, parameter_id);

        }
            //m_Mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            //SceneManager.LoadScene("lobby");
    }
    public void Delayss() {
        List<string> parameter_id = new List<string>();
        parameter_id.Add("20");


        identity_no = PlayerPrefController.Instance.GetIdentityNumber();
        Debug.Log(identity_no);
        //APIController.Instance.Get("link/get", CallGetLinkLobbyAPIResponse, parameter_id);//

        SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
       // sceneManager.GoToScene("ArtPilar1");
        sceneManager.GoToScene("Lobby");
    }
    void CallGetLinkLobbyAPIResponse(Client http)
    {

        if (http.IsSuccessful())
        {
            Response resp = http.Response();

            if (resp.IsOK())
            {

                Debug.Log(resp.ToString());

                GeneralResponse generalResponse = JsonUtility.FromJson<GeneralResponse>(resp.ToString());


                if (generalResponse.status == "success")
                {
                    LinkItem link = generalResponse.link_item;                    
                    Debug.Log(link.value);

                     

                    string url = link.value + "?" + "identity_no=" + identity_no ;
                    Debug.Log(url);
                    // url = "www.google.com";

                    URLOpener.Instance._OpenURL(url);

                }
                else
                {
                    MessageController.Instance.ShowMessage(generalResponse.message);
                }

            }
            else
            {
                Debug.Log(resp.ToString());
            }

        }
        else
        {
            Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
        }
    }
}
