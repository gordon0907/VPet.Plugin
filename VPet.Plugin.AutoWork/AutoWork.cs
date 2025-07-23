//
// VPet.Plugin.AutoWork
//
// Description:
//   This plugin automatically starts the last selected work task for the pet
//   if the pet has been idle for a specified duration.
//


using System.Windows.Threading;
using LinePutScript.Localization.WPF;
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
        // Counts the elapsed seconds of the pet's current idle period.
        int elapsedIdleSeconds = -1;

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
                elapsedIdleSeconds++;
            else
                // If busy, reset the counter.
                elapsedIdleSeconds = -1;

            // Triggers once when the idle threshold is met.
            if (elapsedIdleSeconds == IdleThresholdInSeconds)
            {
                // Ensure a work task is set (it can be null on a fresh game start).
                if (MW.Main.NowWork != null)
                {
                    // Attempt to start the work.
                    if (MW.Main.StartWork(MW.Main.NowWork))
                        // Announce successful start.
                        MW.Main.SayRnd("已自動開始新的「{0}」…".Translate(MW.Main.NowWork.NameTrans));
                    else
                        // Announce failure to start.
                        MW.Main.SayRnd("無法自動開始新的「{0}」…".Translate(MW.Main.NowWork.NameTrans));
                }
            }
        };

        // Start the timer.
        autoWorkTimer.Start();
    }
}