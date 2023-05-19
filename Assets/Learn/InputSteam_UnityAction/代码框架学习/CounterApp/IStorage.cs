using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace FrameworkDesign.CountApp
{
    public interface IStorage
    {
        void SaveInt(string key, int value);
        int LoadInt(string key, int deafavalue = 0);
    }

    public class PlayerPrefsStorage : IStorage
    {
        public int LoadInt(string key, int deafavalue=0)
        {
         return   PlayerPrefs.GetInt(key, deafavalue);
        }

        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }

    public class EditorOPrfesStorage : IStorage
    {
        public int LoadInt(string key, int deafavalue = 0)
        {
#if UNITY_EDITOR
        return    EditorPrefs.GetInt(key, deafavalue);
#endif
        }

        public void SaveInt(string key, int value)
        {
#if UNITY_EDITOR
            PlayerPrefs.SetInt(key, value);
#endif
        }
    }
}