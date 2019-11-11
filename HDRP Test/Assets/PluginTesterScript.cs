using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginTesterScript : MonoBehaviour
{

    const string DLL_NAME = "Tutorial DLL";

    [DllImport(DLL_NAME)]
    private static extern void InputDLL(float x, float y, float z);

    [DllImport(DLL_NAME)]
    private static extern void Undo();

    [DllImport(DLL_NAME)]
    private static extern void Redo();

    [DllImport(DLL_NAME)]
    private static extern void History();

    [DllImport(DLL_NAME)]
    private static extern float X();

    [DllImport(DLL_NAME)]
    private static extern float Y();

    [DllImport(DLL_NAME)]
    private static extern float Z();

    // Update is called once per frame
    void Update()
    {
        

    }
}
