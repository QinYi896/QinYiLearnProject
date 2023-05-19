using System;
using System.Collections.Generic;

namespace FrameworkDesign
{
    /// <summary>
    /// ICO容器
    /// IOC 容器，大家可以理解为是一个字典，这个字典以 Type 为 key，以对象即 Instance 为 value，非常简单
    /// 而 IOC 容器最少有两个核心的 API，即根据 Type 注册实例，根据 Type 获取实例。
    /// </summary>
    public class IOCContainer
    {
        public Dictionary<Type, object> mInstance = new Dictionary<Type, object>();

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public void Register<T>(T instance)

        {
            var key = typeof(T);

            if (mInstance.ContainsKey(key))
            {
                mInstance[key] = instance;
            }
            else
            {
                mInstance.Add(key, instance);
            }
        }

        public T Get<T>() where T :class
        {
            var key = typeof(T);

            Object reobj;
            if(mInstance.TryGetValue(key,out reobj))
            {
                return reobj as T;
            }

            return null;
        }
    }
}