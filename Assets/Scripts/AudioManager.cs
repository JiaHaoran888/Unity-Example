using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region ����ģʽ
    // ��̬ʵ��  
    private static AudioManager _instance;

    // �������ԣ����ڷ���ʵ��  
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // ���ʵ�������ڣ����ҳ����е�AudioManager����  
                _instance = FindObjectOfType<AudioManager>();

                // ���û���ҵ����򴴽�һ���µ�AudioManager����  
                if (_instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    _instance = audioManagerObject.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    // �����������������Ƶ�����߼������粥�ź�ֹͣ��Ч  

    private void Awake()
    {
        // ���ʵ���Ѿ����ڲ��Ҳ��ǵ�ǰ���������ٵ�ǰ����  
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

    [Header("����0")]
    public AudioClip ClipScene0;
    public AudioClip ClipText0;
    [Header("����1")]
    public AudioClip ClipScene1;
    public AudioClip ClipText1;
    [Header("����2")]
    public AudioClip ClipScene2;
    public AudioClip ClipText2;
    [Header("����3")]
    public AudioClip ClipScene3;
    public AudioClip ClipText3;
    [Header("����4")]
    public AudioClip ClipScene4;
    public AudioClip ClipText4;
    [Header("����5")]
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
    // ������Ƶ������صķ���...  
}