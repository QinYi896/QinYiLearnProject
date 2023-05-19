using UnityEngine;

namespace FrameworkDesign.Example
{
    /// <summary>
    /// 蓝牙连接接口
    /// </summary>
    public interface IBluetoothManager
    {
        void Connect();
    }

    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            // 创建一个 IOC 容器
            var container = new IOCContainer();

            // 注册一个蓝牙管理器的实例
            //   container.Register(new BluetoothManager());

            //根据接口注册实例
            container.Register<IBluetoothManager>(new BluetoothManager());

            //// 根据类型获取蓝牙管理器的实例
            //var bluetoothManager = container.Get<BluetoothManager>();

            //根据接口获得蓝牙管理器的实例
            var bluetoothManager = container.Get<IBluetoothManager>();


            //连接蓝牙
            bluetoothManager.Connect();
        }

        public class BluetoothManager:IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("蓝牙连接成功");
            }
        }
    }
}