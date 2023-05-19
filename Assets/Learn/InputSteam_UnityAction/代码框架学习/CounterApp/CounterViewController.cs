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
            //��������ע����ȡ
            //  mCounterModel = CounterApp.Get<CounterModel>();

            //�ӽӿ������л�ȡ
            mCounterModel = CounterApp.Get<ICounterModel>();

            // ע��
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // �����߼���������Զ����������߼�
                    //   CounterModel.Count.Value++;
                    new AddCountCommand().Execute();
                });

            transform.Find("BtnSub").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // �����߼���������Զ����������߼�
                    //  CounterModel.Count.Value--;
                    new SubCountCommand().Execute();
                });

            OnCountChanged(mCounterModel.Count.Value);
        }

        // �����߼�
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            // ע��
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }


    public interface ICounterModel
    {
        BindableProperty<int> Count { get; }
    }

    /// <summary>
    /// ʵ�������ӿ�
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
            // ͨ�� Architrecture ��ȡ
            var storage = Architecture.GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTTER_COUNT", 0);

            Count.OnValueChanged += count =>
              {
                  storage.SaveInt("COUNTTER_COUNT", count);
              };

        }



    }

}