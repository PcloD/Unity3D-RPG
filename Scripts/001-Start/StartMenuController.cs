using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour
{
    public static StartMenuController _Instance;


    public TweenScale startTween;
    public TweenScale loginTween;
    public TweenScale registerTween;
    public TweenScale serverTween;
    public TweenAlpha charselectTween;
    public TweenPosition charSelectShowTween;
    //start
    public UILabel usernameStartLabel;
    public UILabel serverStartLabel;
    //login
    public UIInput usernameLoginInput;
    public UIInput passwordLoginInput;
    //register
    public UIInput usernameRegisterInput;
    public UIInput passwordRegisterInput;
    public UIInput passwordAgainRegisterInput;
    //server
    public GameObject serverBtnRed;
    public GameObject serverBtnGreen;
    public UIGrid serverGrid;
    public GameObject serverSelected;

    public static string username;
    public static string password;
    private ServerProperty serverProperty;
    private bool hasInitServerList = false;

    //charSelect
    public UILabel label_char_name;//角色名字

    //charSelectshow
    public GameObject[] CharacterArray;
    public GameObject[] CharacterSelectArray;
    public GameObject characterSelected;
    public UIInput input_name;

    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        InitServerList();
    }

    public void OnUsernameClick()
    {
        //1隐藏start
        startTween.PlayForward();
        StartCoroutine(HidePanel(startTween.gameObject));


        //2显示login
        loginTween.gameObject.SetActive(true);
        loginTween.PlayForward();
    }

    public void OnSeverSelectClick()
    {
        //1隐藏start
        startTween.PlayForward();
        StartCoroutine(HidePanel(startTween.gameObject));

        //显示Server
        serverTween.gameObject.SetActive(true);
        serverTween.PlayForward();

        //InitServerList();
    }

    //初始化服务器列表
    private void InitServerList()
    {
        if (hasInitServerList) return;

        for (int i = 0; i < 20; i++)
        {
            


            string ip = "192.168.1." + i;
            string name = (i+1) + "区 盘龙";
            int playerCount = Random.Range(0, 100);


            GameObject newServer = null;
            if(playerCount>=50)
            {
                //火爆
                newServer=NGUITools.AddChild(serverGrid.gameObject, serverBtnRed);
            }
            else
            {
                //流畅
                newServer = NGUITools.AddChild(serverGrid.gameObject, serverBtnGreen);
            }

            ServerProperty serverInfo=newServer.GetComponent<ServerProperty>();
            serverInfo.ip = ip;
            serverInfo.name = name;
            serverInfo.count = playerCount;

            serverGrid.AddChild(newServer.transform);


        }





        hasInitServerList = true;
    }

    public void OnEnterGameClick()
    {
        //1隐藏start
        startTween.PlayForward();
        StartCoroutine(HidePanel(startTween.gameObject));

        //显示Server
        charselectTween.gameObject.SetActive(true);
        charselectTween.PlayForward();
    }

    IEnumerator HidePanel(GameObject go)
    {
        yield return new WaitForSeconds(0.4f);
        go.SetActive(false);

    }


    //登录按钮
    public void OnLoginClick()
    {
        username = usernameLoginInput.value;
        password = passwordLoginInput.value;

        //验证账号密码

        //跳转
        FromLoginToStart();

        usernameStartLabel.text = username;
    }

    public void OnRegisterShowClick()
    {
        loginTween.PlayReverse();
        StartCoroutine(HidePanel(loginTween.gameObject));

        registerTween.gameObject.SetActive(true);
        registerTween.PlayForward();
    }

    public void OnLoginCloseClick()
    {
        FromLoginToStart();
    }

    public void OnRegisterClick()
    {
        username = usernameRegisterInput.value;
        password = usernameRegisterInput.value;

        usernameStartLabel.text = usernameRegisterInput.value;


        //从注册到start
        registerTween.PlayReverse();
        StartCoroutine(HidePanel(registerTween.gameObject));

        startTween.gameObject.SetActive(true);
        startTween.PlayReverse();
    }

    public void OnRegisterCancelClick()
    {
        FromRegisterToLogin();
    }

    public void OnRegisterCloseClick()
    {

        FromRegisterToLogin();
    }

    public void OnServerSelectCloseClick()
    {
        serverTween.PlayReverse();
        StartCoroutine(HidePanel(serverTween.gameObject));



        startTween.gameObject.SetActive(true);
        startTween.PlayReverse();
    }

    private void FromLoginToStart()
    {
        //跳转start界面--隐藏login界面 显示start界面
        loginTween.PlayReverse();
        StartCoroutine(HidePanel(loginTween.gameObject));

        startTween.gameObject.SetActive(true);
        startTween.PlayReverse();
    }

    private void FromRegisterToLogin()
    {
        //从注册返回到登录
        registerTween.PlayReverse();
        StartCoroutine(HidePanel(registerTween.gameObject));

        loginTween.gameObject.SetActive(true);
        loginTween.PlayForward();


    }


    public void OnServerSelected(GameObject server)
    {
        Debug.Log("OnServerSelected");
        serverProperty = server.GetComponent<ServerProperty>();
        if(serverProperty!=null)
        {
            //更新图片
            serverSelected.GetComponent<UISprite>().spriteName = server.GetComponent<UISprite>().spriteName;
            serverSelected.GetComponentInChildren<UILabel>().text = server.GetComponentInChildren<UILabel>().text;

            //serverSelected.GetComponent<ServerProperty>().ip = server.GetComponent<ServerProperty>().ip;
            //serverSelected.GetComponent<ServerProperty>().name = server.GetComponent<ServerProperty>().name;
        }
    }

    //服务器选择完毕
    public void OnServerSelectedOver()
    {
        OnServerSelectCloseClick();//关闭服务器显示 

        //更改start界面的服务器名
        serverStartLabel.text = serverSelected.GetComponentInChildren<UILabel>().text;
    }

    public void OnCharacterSelect(GameObject go)
    {
        //将选择的角色变大，并把其他的角色还原大小
        //iTween.ScaleTo(go, new Vector3(1.5f, 1.5f, 1.5f), 0.3f);

        float scale = 1.2f;

        if(characterSelected!=null&&characterSelected!=go)
        {
            iTween.ScaleBy(characterSelected, new Vector3(1 / scale, 1 / scale, 1 / scale), 0.3f);
        }

        if (characterSelected != go)
        {
            iTween.ScaleBy(go, new Vector3(scale, scale, scale), 0.3f);
        }

        characterSelected = go;
    }


    //显示角色显示界面
    public void OnCharacterSelectShow()
    {
        StartCoroutine(HidePanel(charselectTween.gameObject));
        charselectTween.PlayReverse();


        charSelectShowTween.gameObject.SetActive(true);
        charSelectShowTween.PlayForward();

        
    }


    
    public void OnCharacterSelectShowBack()
    {
        StartCoroutine(HidePanel(charSelectShowTween.gameObject));
        charSelectShowTween.PlayReverse();

        charselectTween.gameObject.SetActive(true);
        charselectTween.PlayForward();

       
    }

    //角色选择界面的确定按钮事件
    public void OnCharacterShowButtonSure()
    {
        //1判断名字输入是否正确
        //2角色是否被选择
        if (input_name.value == "") return;
        if (characterSelected == null) return;
        

        

        //TODO 改变charselect上的模型
        //记录当前选择的模型
        //if(characterSelected.tag==Tags.BoyPrefeb)
        //{

        //}else if(characterSelected.tag==Tags.GirlPrefeb)
        //{

        //}
        int index = -1;
        for (int i = 0; i < CharacterArray.Length;i++ )
        {
            if(characterSelected==CharacterArray[i])
            {
                //Debug.Log("OnCharacterShowButtonSure");
                index = i;
                break;
            }
        }

        Debug.Log(index);

        if(index!=-1)
        {
            //将其他模型enActive
            //CharacterSelectArray[index].SetActive(true);

            for(int i=0;i<CharacterSelectArray.Length;i++)
            {           

                if (i == index)
                    CharacterSelectArray[i].SetActive(true);
                else//将其他模型enActive
                    CharacterSelectArray[i].SetActive(false);
                
            }
        }

        //TODO 改变角色名字
        label_char_name.text = input_name.value;

        //返回角色界面
        OnCharacterSelectShowBack();
    }


}
