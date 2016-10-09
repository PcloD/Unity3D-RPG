using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public static LoadScene _Instance;

    private GameObject bg;
    private UISlider processBar;
    private bool isAsyn = false;
    private AsyncOperation ao = null;
    void Awake()
    {
        _Instance = this;
        

        bg = transform.Find("Bg").gameObject;
        processBar = transform.Find("Bg/ProgressBar").GetComponent<UISlider>();

        gameObject.SetActive(false);
        //Application.LoadLevelAsync(2);

    }

    public void Show(AsyncOperation ao)
    {
        this.ao = ao;
        gameObject.SetActive(true);
        bg.SetActive(true);
        isAsyn = true;
    }


    void Hide()
    {

    }


    void Update()
    {
        if (isAsyn)
        {
            processBar.value = ao.progress;
        }
    }
}
