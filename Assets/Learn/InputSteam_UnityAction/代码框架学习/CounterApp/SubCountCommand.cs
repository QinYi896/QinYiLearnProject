using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.CountApp
{

    public struct SubCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<ICounterModel>().Count.Value--;
        }


    }

}