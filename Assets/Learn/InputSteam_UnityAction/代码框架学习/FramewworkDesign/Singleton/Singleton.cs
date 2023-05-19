
using UnityEngine;
using System.Reflection;
using System;

namespace FrameworkDesign
{

    public class Singleton<T> where T : class
    {
        //需要查询C#反射的知识
        private static T mInstance;
        public static T Instance
        {
        get
            {
                if(mInstance==null)
                {
                    //通过反射获得构造
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance
                        |BindingFlags.NonPublic);
                    //获得无参非public d的构造

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