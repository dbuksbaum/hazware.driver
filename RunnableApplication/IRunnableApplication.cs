using System;

namespace RunnableApplication
{
  public interface IRunnableApplication
  {
    /// <summary>
    /// Gets the number of ms to sleep between pulses.
    /// </summary>
    /// <value>The pulse time in ms.</value>
    int PulseMs { get; }

    /// <summary>
    /// Gets a value indicating whether [should quit].
    /// </summary>
    /// <value><c>true</c> if [should quit]; otherwise, <c>false</c>.</value>
    bool ShouldQuit { get; }

    /// <summary>
    /// Gets the delegate to execute after each pulse.
    /// </summary>
    /// <value>The on pulse delegate or null.</value>
    Func<bool> OnPulse { get; }

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops this instance.
    /// </summary>
    void Stop();
  }
}
