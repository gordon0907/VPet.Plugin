//
// VPet.Plugin.AutoWork
//
// Description:
//   This plugin automatically starts the last selected work task for the pet
//   if the pet has been idle for a specified duration.
//


using System.Windows.Threading;
using VPet_Simulator.Core;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.AutoWork;

/// <summary>
/// Main class for the AutoWork plugin.
/// </summary>
public class AutoWork : MainPlugin
{
    // Time in seconds before auto-work triggers.
    private const int IdleThresholdInSeconds = 30;

    /// <summary>
    /// The public name of the plugin.
    /// </summary>
    public override string PluginName => "AutoWork";

    /// <summary>
    /// Plugin constructor.
    /// </summary>
    public AutoWork(IMainWindow mainwin) : base(mainwin)
    {
    }

    /// <summary>
    /// Called when the game has finished loading to set up the plugin.
    /// </summary>
    public override void GameLoaded()
    {
        // Tracks the pet's idle time in seconds.
        int idleTimeInSeconds = 0;

        // Initialize the timer.
        var autoWorkTimer = new DispatcherTimer
        {
            // Set the timer to tick once every second.
            Interval = TimeSpan.FromSeconds(1)
        };

        // Define the timer's behavior for each tick.
        autoWorkTimer.Tick += (sender, e) =>
        {
            // Check if the pet is currently idle.
            if (MW.Main.State == Main.WorkingState.Nomal)
                // If idle, increment the counter.
                idleTimeInSeconds++;
            else
                // If busy, reset the counter.
                idleTimeInSeconds = 0;

            // Check if the idle time has exceeded the threshold.
            if (idleTimeInSeconds > IdleThresholdInSeconds)
            {
                // Ensure a work task is selected.
                if (MW.Main.NowWork != null)
                {
                    // Attempt to start the work.
                    if (MW.Main.StartWork(MW.Main.NowWork))
                        // Announce successful start.
                        MW.Main.SayRnd($"已自動開始新的{MW.Main.NowWork.NameTrans}…");
                    else
                        // Announce failure to start.
                        MW.Main.SayRnd($"無法自動開始新的{MW.Main.NowWork.NameTrans}…");
                }

                // Reset the idle timer to prevent repeated attempts.
                idleTimeInSeconds = 0;
            }
        };

        // Start the timer.
        autoWorkTimer.Start();
    }
}