using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Room : MonoBehaviour
{
    public GameObject[] tankImg;
    private int nowProcess;
    private int tProcess;
    private static AsyncOperation async;

    [HideInInspector]
    public static bool isStartLoading = false;
    [HideInInspector]
    public static int playerNum = 0;

    void Start()
    {
        for (int i = 0; i < tankImg.Length; i++)
        {
            tankImg[i].SetActive(false);
        }
        playerNum = 0;
    }

    void Update()
    {
        for (int i = 0; i < playerNum; i++)
        {
            tankImg[i].SetActive(true);
        }

        if (isStartLoading)
        {
            isStartLoading = false;
            StartCoroutine(LoadingScene());
        }

        if (async == null)
        {
            return;
        }

        // async.progress 你正在读取的场景的进度值  0---0.9  
        // 如果当前的进度小于0.9，说明它还没有加载完成，就说明进度条还需要移动  
        // 如果，场景的数据加载完毕，async.progress 的值就会等于0.9
        if (async.progress < 0.9f)
        {
            tProcess = (int)async.progress * 100;
        }
        else
        {
            tProcess = 100;
        }

        ServerEvents.Instance.UpdateLoadingProgress(tProcess);
    }

    public IEnumerator LoadingScene()
    {
        async = SceneManager.LoadSceneAsync("World");
        async.allowSceneActivation = false;
        yield return async;
    }

    public static void onLoadingFinish()
    {
        async.allowSceneActivation = true;
    }
}
