
using UnityEngine;
using System.Reflection;
using System;

namespace FrameworkDesign
{

    public class Singleton<T> where T : class
    {
        //��Ҫ��ѯC#�����֪ʶ
        private static T mInstance;
        public static T Instance
        {
        get
            {
                if(mInstance==null)
                {
                    //ͨ�������ù���
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance
                        |BindingFlags.NonPublic);
                    //����޲η�public d�Ĺ���

                    var ctor = Array.Find(ctors,c=>c.GetParameters().Length==0);

                    if(ctor==null )
                    {
                        throw new Exception("Non-Public Constructor() not found in " + typeof(T));
                    }

                    mInstance = ctor.Invoke(null) as T;
                }

                return mInstance;
            }

            
        }
    }
}