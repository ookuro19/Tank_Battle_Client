using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Props2Pydata : MonoBehaviour
{
    public int mapNum;

    private static string m_allPropInfoStr = string.Empty;
    private static Dictionary<string, Vector3> propDict = new Dictionary<string, Vector3>();

    /// <summary>
    /// 添加道具进行统计
    /// </summary>
    /// <param name="propKey">道具键值</param>
    /// <param name="pos">位置坐标</param>
    /// <param name="type">道具类型</param>
    public static void AppendProps(string propKey, Vector3 pos, int type)
    {
        if (propDict.ContainsKey(propKey))
        {
            Debug.LogErrorFormat("the prop {0} already added", propKey);
            return;
        }

        if (propDict.Count != 0)
        {
            m_allPropInfoStr += ",\n";
        }

        string tStr = string.Format("'{2}' : {0}'posx' : {3:0.000}, 'posy' : {4:0.000}, 'posz' : {5:0.000}, 'type':{6}{1}", "{", "}", propKey, pos.x, pos.y, pos.z, type);
        Debug.Log(tStr);

        propDict.Add(propKey, pos);

        m_allPropInfoStr += tStr;
    }

    public void WriteFile(string dataPath, string data)
    {
        if (File.Exists(dataPath))
        {
            File.Delete(dataPath);
        }

        FileStream fs = new FileStream(dataPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        sw.WriteLine(data);
        sw.Close();
        sw.Dispose();

        Debug.Log("save succeed ... ");
    }

    private void OnApplicationFocus(bool focus)
    {
        //进游戏
        if (focus)
        {

        }
        //出游戏
        else
        {
            string path = Path.Combine(Application.persistentDataPath, string.Format("PropData_{0}.py", mapNum));
            Debug.Log("path is : " + path);
            string tStr = string.Format("datas={0}\n{2}\n{1}", "{", "}", m_allPropInfoStr);
            WriteFile(path, tStr);
            // Application.Quit();
        }
    }
}
