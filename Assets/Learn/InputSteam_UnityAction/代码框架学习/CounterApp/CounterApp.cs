
namespace FrameworkDesign.CountApp
{
    public class CounterApp : Architecture<CounterApp>
    {
       
        protected override void Init()
        {
            //   Register(new CounterModel());
            Register<ICounterModel>(new CounterModel());
            Register<IStorage>(new PlayerPrefsStorage());
        }
    }
}

