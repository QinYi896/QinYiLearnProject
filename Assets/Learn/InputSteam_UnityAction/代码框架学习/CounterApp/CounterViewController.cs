using UnityEngine;
using UnityEngine.UI;
namespace FrameworkDesign.CountApp
{
    public class CounterViewController : MonoBehaviour
    {
        // private    CounterModel mCounterModel;
        private ICounterModel mCounterModel;
        void Start()
        {
            //从容器中注册后获取
            //  mCounterModel = CounterApp.Get<CounterModel>();

            //从接口容器中获取
            mCounterModel = CounterApp.Get<ICounterModel>();

            // 注册
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // 交互逻辑：这个会自动触发表现逻辑
                    //   CounterModel.Count.Value++;
                    new AddCountCommand().Execute();
                });

            transform.Find("BtnSub").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // 交互逻辑：这个会自动触发表现逻辑
                    //  CounterModel.Count.Value--;
                    new SubCountCommand().Execute();
                });

            OnCountChanged(mCounterModel.Count.Value);
        }

        // 表现逻辑
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            // 注销
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }


    public interface ICounterModel
    {
        BindableProperty<int> Count { get; }
    }

    /// <summary>
    /// 实现容器接口
    /// </summary>

    public class CounterModel : ICounterModel
    {
        //  private CounterModel() { }
        //public  BindableProperty<int> Count = new BindableProperty<int>()
        //{
        //    Value = 0
        //};

        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
        public IArchitecture Architecture { get; set; }
        public CounterModel()
        {
            //   var storage = CounterApp.Get<IStorage>();
            // 通过 Architrecture 获取
            var storage = Architecture.GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTTER_COUNT", 0);

            Count.OnValueChanged += count =>
              {
                  storage.SaveInt("COUNTTER_COUNT", count);
              };

        }



    }

}