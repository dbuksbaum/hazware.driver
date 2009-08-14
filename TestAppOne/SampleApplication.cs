using System;
using System.ComponentModel.Composition;
using RunnableApplication;

namespace TestAppOne
{
  [Export(typeof(IRunnableApplication))]
  public class SampleApplication : RunnableApplicationBase
  {
    #region RunnableApplicationBase Members
    public override void Start()
    {
      Console.WriteLine("Starting Application");
    }
    public override void Stop()
    {
      Console.WriteLine("Stopping Application");
    }
    #endregion
  }
}
