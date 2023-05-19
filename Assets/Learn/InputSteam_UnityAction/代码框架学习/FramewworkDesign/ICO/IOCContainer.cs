using System;
using System.Collections.Generic;

namespace FrameworkDesign
{
    /// <summary>
    /// ICO����
    /// IOC ��������ҿ������Ϊ��һ���ֵ䣬����ֵ��� Type Ϊ key���Զ��� Instance Ϊ value���ǳ���
    /// �� IOC �����������������ĵ� API�������� Type ע��ʵ�������� Type ��ȡʵ����
    /// </summary>
    public class IOCContainer
    {
        public Dictionary<Type, object> mInstance = new Dictionary<Type, object>();

        /// <summary>
        /// ע��
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