using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface IStorage
    {
        void SaveString(string key, string value);
        string LoadString(string key, string defaultValue = "");
    }
    // 2. ʵ�ֽӿ�
    // ����ʱ�洢
    public class PlayerPrefsStorage : IStorage
    {
        public void SaveString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public string LoadString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
    }
    // 3. ʵ�ֽӿ�
    // �༭���洢
    public class EditorPrefsStorage : IStorage
    {
        public void SaveString(string key, string value)
        {
#if UNITY_EDITOR
            EditorPrefs.SetString(key, value);
#endif
        }

        public string LoadString(string key, string defaultValue = "")
        {
#if UNITY_EDITOR
            return EditorPrefs.GetString(key, defaultValue);
#else
                return ""
#endif
        }
    }

    /// <summary>
    /// �������ã��������ӿ�����
    /// </summary>
    public class DIPExample : MonoBehaviour
    {
        // 4. ʹ��
        private void Start()
        {
            // ����һ�� IOC ����
            var container = new IOCContainer();

            // ע������ʱģ��
            container.Register<IStorage>(new PlayerPrefsStorage());

            var storage = container.Get<IStorage>();

            storage.SaveString("name", "����ʱ�洢");

            Debug.Log(storage.LoadString("name"));

            // �л�ʵ��
            container.Register<IStorage>(new EditorPrefsStorage());

            storage = container.Get<IStorage>();

            Debug.Log(storage.LoadString("name"));
        }
    }
}