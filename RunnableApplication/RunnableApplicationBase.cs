using System;

namespace RunnableApplication
{
  public abstract class RunnableApplicationBase : IRunnableApplication
  {
    #region Constants
    private const int DEFAULT_PULSE_TIME = 250;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the RunnableApplicationBase class.
    /// </summary>
    public RunnableApplicationBase()
    {
      PulseMs = DEFAULT_PULSE_TIME;
      ShouldQuit = false;
      OnPulse = () => { return false; };
    }
    #endregion

    #region IRunnableApplication Members
    public int PulseMs
    {
      get;
      protected set;
    }
    public bool ShouldQuit
    {
      get;
      protected set;
    }
    public Func<bool> OnPulse
    {
      get;
      protected set;
    }
    public abstract void Start();
    public abstract void Stop();
    #endregion
  }
}
