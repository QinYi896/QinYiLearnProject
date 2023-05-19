using System;
using UnityEngine;

namespace FrameworkDesign
{

    /// <summary>
    /// 绑定的资产
    /// 用处：只需要
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue;

        public T Value
        {
            get => mValue;
            set
            {
                if (!mValue.Equals(value))
                {
                    mValue = value;
                    OnValueChanged?.Invoke(value);
                }
            }
        }

        public Action<T> OnValueChanged;
    }

}