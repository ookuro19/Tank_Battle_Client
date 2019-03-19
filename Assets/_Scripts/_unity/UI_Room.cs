using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Room : MonoBehaviour
{
    public UI_PlayerRoomItem[] playerUIItem;
    private int nowProcess = 0;
    private int tProcess = 0;
    private static AsyncOperation async;

    [HideInInspector]
    public static bool isStartLoading = false;

    public static UI_Room Instance;

    void Start()
    {
        Instance = this;

        for (int i = 0; i < playerUIItem.Length; i++)
        {
            playerUIItem[i].Reset();
        }
    }

    void Update()
    {
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
            tProcess = (int)(async.progress * 100);
        }
        else
        {
            tProcess = 100;
        }

        // Debug.LogFormat("Cur Player progress is: {0}", tProcess);
        if (nowProcess < tProcess)
        {
            nowProcess = tProcess;
            ServerEvents.Instance.UpdateLoadingProgress(nowProcess);
        }
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

    public void PlayerEnterin()
    {
        Debug.Log("ClientCore.g_tankList.count: " + ClientCore.g_tankList.Count);
        for (int i = 0; i < ClientCore.g_tankList.Count; i++)
        {
            playerUIItem[i].SetItem(ClientCore.g_tankList[i]);
        }
    }
}
