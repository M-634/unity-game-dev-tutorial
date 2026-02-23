using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test File for Connecting IDE, And Explain Unity C# Script
/// </summary>
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if APP_DEBUG
        Debug.Log("Scripting Define Symbolsに'APP_DEBUG'を追加した際にコンパイルされる");
#else
        Debug.Log("Scripting Define Symbolsに'APP_DEBUG'が存在しない際にコンパイルされる");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
