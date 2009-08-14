using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleDriver
{
  class Program
  {
    private static bool _quit = false;

    static void Main(string[] args)
    {
      _quit = false;
      Console.TreatControlCAsInput = false;
      Console.CancelKeyPress += Console_CancelKeyPress;
      try
      {
        using (RunnableProgram run = new RunnableProgram())
        {
          if (run.TheApp == null)
            throw new InvalidOperationException("Cannot start without runnable application.");

          run.TheApp.Start();

          int pulse = run.TheApp.PulseMs;
          Func<bool> onPulse = run.TheApp.OnPulse ?? (() => { return false; });

          try
          {
            while (!_quit)
            {
              Thread.Sleep(pulse);
              if (onPulse() || run.TheApp.ShouldQuit)
                break;
            }
          }
          finally
          {
            run.TheApp.Stop();
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Global Exception: {0}", ex.Message);
      }
      finally
      {
        Console.CancelKeyPress -= Console_CancelKeyPress;
      }
    }

    #region CTRL-C Handler
    static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
      _quit = true;
      e.Cancel = true;
    }
    #endregion
  }
}
