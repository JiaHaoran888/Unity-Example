using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region 单例模式
    // 静态实例  
    private static AudioManager _instance;

    // 公共属性，用于访问实例  
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // 如果实例不存在，查找场景中的AudioManager对象  
                _instance = FindObjectOfType<AudioManager>();

                // 如果没有找到，则创建一个新的AudioManager对象  
                if (_instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    _instance = audioManagerObject.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    // 在这个类中添加你的音频管理逻辑，例如播放和停止音效  

    private void Awake()
    {
        // 如果实例已经存在并且不是当前对象，则销毁当前对象  
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

     
    }

    private void OnDestroy()
    {
        _instance = null;
    }
    #endregion

    [Header("场景0")]
    public AudioClip ClipScene0;
    public AudioClip ClipText0;
    [Header("场景1")]
    public AudioClip ClipScene1;
    public AudioClip ClipText1;
    [Header("场景2")]
    public AudioClip ClipScene2;
    public AudioClip ClipText2;
    [Header("场景3")]
    public AudioClip ClipScene3;
    public AudioClip ClipText3;
    [Header("场景4")]
    public AudioClip ClipScene4;
    public AudioClip ClipText4;
    [Header("场景5")]
    public AudioClip ClipScene5;
    public AudioClip ClipText5;
    [Header("AudioSource")]
    public AudioSource SceneAudioSource;
    public AudioSource TextAudioSource;


    private void Start()
    {
    PlaySceneSound(GetSceneAudioClipByNowScene());

    }

    public void PlaySceneSound(AudioClip clip)
    {
       
        SceneAudioSource.clip = clip;
        SceneAudioSource.loop = true;
        SceneAudioSource.Play();

       
    }

    public void PlayTextSound(AudioClip clip)
    {

        TextAudioSource.clip = clip;
        TextAudioSource.Play();


    }


    public AudioClip GetTextAudioClipByNowScene()
    {
        switch (UIManager.Instance.nowPlayScene)
        {
            case 0:
                return Instance.ClipText0;
                break;
            case 1:
                return Instance.ClipText1;
                break;
            case 2:
                return Instance.ClipText2;
                break;
            case 3:
                return Instance.ClipText3;
                break;
            case 4:
                return Instance.ClipText4;
                break;
            case 5:
                return Instance.ClipText5;
                break;
            default:
                return null;
                break;
        }
    }

    public AudioClip GetSceneAudioClipByNowScene()
    {

        switch (UIManager.Instance.nowPlayScene)
        {
            case 0:
                return ClipScene0;
                break;
            case 1:
                return ClipScene1;
                break;
            case 2:
                return ClipScene2;
                break;
            case 3:
                return ClipScene3;
                break;
            case 4:
                return ClipScene4;
                break;
            case 5:
                return ClipScene5;
                break;
            default:
                return null;
                break;
        }

    }
    // 其他音频管理相关的方法...  
}