using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene("Login");
    }
}
