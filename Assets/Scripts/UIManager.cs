using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG;

public class UIManager : MonoBehaviour
{
    #region
    // 静态实例  
    private static UIManager _instance;

    // 公共属性，用于访问实例  
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // 如果实例不存在，查找场景中的UIManager对象  
                _instance = FindObjectOfType<UIManager>();

                // 如果没有找到，则创建一个新的UIManager对象  
                if (_instance == null)
                {
                    GameObject uiManagerObject = new GameObject("UIManager");
                    _instance = uiManagerObject.AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // 如果实例已经存在且不是当前对象，则销毁当前对象  
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

      
    }

    private void OnDestroy()
    { 
        _instance= null;
    }
    #endregion
    // 示例: 显示指定的面板  
    [Header("左右导航")]
    public Button leftBtn;
    public Button rightBtn;

    [Header("数字导航")]
    public Toggle navToggle0;
    public Toggle navToggle1;
    public Toggle navToggle2;
    public Toggle navToggle3;
    public Toggle navToggle4;
    public Toggle navToggle5;

    [Header("播放文本")]
    public Button playBtn;
    public Button playAllBtn;

    [Header("数据相关")]
    [SerializeField]
    private int _nowPlayScene;
    public int nowPlayScene
    {
        get
        {
            return _nowPlayScene;
        }
        set
        {
            _nowPlayScene = value;
            OnNowPlaySceneChanged?.Invoke();
        }
    }
    [Header("事件")]
    private UnityAction OnNowPlaySceneChanged;

    private void Start()
    {
        leftBtn.onClick.AddListener(OnLeftBtnDown);
        rightBtn.onClick.AddListener(OnRightBtnDown);
        navToggle0.onValueChanged.AddListener(OnNavToggle0Changed);
        navToggle1.onValueChanged.AddListener(OnNavToggle1Changed);
        navToggle2.onValueChanged.AddListener(OnNavToggle2Changed);
        navToggle3.onValueChanged.AddListener(OnNavToggle3Changed);
        navToggle4.onValueChanged.AddListener(OnNavToggle4Changed);
        navToggle5.onValueChanged.AddListener(OnNavToggle5Changed);
        playBtn.onClick.AddListener(OnPlayBtnDown);
        playAllBtn.onClick.AddListener(OnPlayAllBtnDown);



    }

 
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    // 示例: 隐藏指定的面板  
    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }


    public void UpdateText(Text textComponent, string newText)
    {
        if (textComponent != null)
        {
            textComponent.text = newText;
        }
    }
    public void OnLeftBtnDown()
    {
        if (nowPlayScene >= 0)
        { 
       
            SceneManager.LoadScene(nowPlayScene - 1, LoadSceneMode.Single);
        }

    }
     
    public void OnRightBtnDown()
    {
        if (nowPlayScene <=5)
        {
            SceneManager.LoadScene(nowPlayScene +1, LoadSceneMode.Single);
        }
    }




    public void OnNavToggle0Changed(bool value)
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void OnNavToggle1Changed(bool value)
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void OnNavToggle2Changed(bool value)
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void OnNavToggle3Changed(bool value)
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    public void OnNavToggle4Changed(bool value)
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
    public void OnNavToggle5Changed(bool value)
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void OnPlayBtnDown()
    {
       AudioManager.Instance.PlayTextSound(AudioManager.Instance.GetTextAudioClipByNowScene());
     


    }

    public void OnPlayAllBtnDown()
    {
        AudioManager.Instance.PlayTextSound(AudioManager.Instance.GetTextAudioClipByNowScene());
        DirectorPlay();
    }
    /// <summary>
    /// 播放动画
    /// </summary>

    public void DirectorPlay()
    {
        if (GameObject.Find("Director"))
        {
            GameObject director = GameObject.Find("Director");
            director.GetComponent<PlayableDirector>().Play();
        }
    }
    /// <summary>
    /// 当ValueChange的时候 改变场景
    /// </summary>
    public void ChangeScene()
    { 
    
    }
   


    /*public Toggle GetNowSceneButton()
    {
        switch (nowPlayScene)
        {
            case 0:
                return navToggle0;
                break;
            case 1:
                return navToggle1;
                break;
            case 2:
                return navToggle2;
                break;
            case 3:
                return navToggle3;
                break;
            case 4:
                return navToggle4;
                break;
            case 5:
                return navToggle5;
                break;
            default:
                return null;
                break;
        }
    }*/

   


    

    // 其他UI管理相关的方法...  
}