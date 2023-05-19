using UnityEngine;

namespace FrameworkDesign.Example
{
    /// <summary>
    /// �������ӽӿ�
    /// </summary>
    public interface IBluetoothManager
    {
        void Connect();
    }

    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            // ����һ�� IOC ����
            var container = new IOCContainer();

            // ע��һ��������������ʵ��
            //   container.Register(new BluetoothManager());

            //���ݽӿ�ע��ʵ��
            container.Register<IBluetoothManager>(new BluetoothManager());

            //// �������ͻ�ȡ������������ʵ��
            //var bluetoothManager = container.Get<BluetoothManager>();

            //���ݽӿڻ��������������ʵ��
            var bluetoothManager = container.Get<IBluetoothManager>();


            //��������
            bluetoothManager.Connect();
        }

        public class BluetoothManager:IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("�������ӳɹ�");
            }
        }
    }
}