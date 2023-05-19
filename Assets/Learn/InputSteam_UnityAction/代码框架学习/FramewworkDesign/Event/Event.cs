
using System;
using UnityEngine;
namespace FrameworkDesign
{
    public class Event<T> where T : Event<T>
    {
        public static Action action;

        public static void Register(Action onEvent)
        {
            action += onEvent;
        }

        public static void UnRegister(Action onEvent)
        {
            action -= onEvent;
        }
        public static void Trigger()
        {
            action?.Invoke();


        }
    }

}