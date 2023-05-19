using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public interface IArchitecture
    {
        // �ṩһ����ȡ Utility �� API
        T GetUtility<T>() where T : class;
    }
    /// <summary>
    /// �ܹ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // public abstract class Architecture<T> where T : Architecture<T>, new()
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// �Ƿ��Ѿ���ʼ�����
        /// </summary>
        private bool mInited = false;

        /// <summary>
        /// ���ڳ�ʼ���� Models �Ļ���
        /// </summary>
        private List<IModel> mModels = new List<IModel>();

        // �ṩһ��ע�� Model �� API
        public void RegisterModel<T>(T instance) where T : IModel
        {
            // ��Ҫ�� Model ��ֵһ��
            instance.Architecture = this;
            mContainer.Register<T>(instance);

            // �����ʼ������
            if (mInited)
            {
                instance.Init();
            }
            else
            {
                // ��ӵ� Model �����У����ڳ�ʼ��
                mModels.Add(instance);
            }
        }

        #region ���Ƶ���ģʽ ���ǽ����ڲ��η���
        private static T mArchitecture = null;

        // ȷ�� Container ����ʵ����
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                // ��ʼ�� Model
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }

                // ��� Model
                mArchitecture.mModels.Clear();
                mArchitecture.mInited = true;
            }
        }

        #endregion

        private IOCContainer mContainer = new IOCContainer();

        // ��������ע��ģ��
        protected abstract void Init();

        // �ṩһ��ע��ģ��� API
        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        // �ṩһ����ȡģ��� API
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }


        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }
    }
}


