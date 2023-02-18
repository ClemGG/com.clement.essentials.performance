using UnityEngine;

namespace Essentials.Performance
{
    /// <summary>
    /// Allows to edit the application's
    /// performance settings (fps, memory, etc.)
    /// </summary>
    public static class ApplicationPerformance
    {
        #region Constants

        private const int DEFAULT_FRAMERATE = 60;
        private const int UNFOCUSED_FRAMERATE = 1;

        #endregion

        #region Static variables

        /// <summary>
        /// Cached to restore the user defined framerate
        /// each time we focus back on the game window
        /// </summary>
        private static int _userDefinedFrameRate = DEFAULT_FRAMERATE;

        #endregion

        #region Public methods

        /// <summary>
        /// Sets a new framerate
        /// </summary>
        /// <param name="framerate">The new framerate to reach</param>
        public static void SetFramerate(int framerate)
        {
            Application.targetFrameRate = framerate;
            _userDefinedFrameRate = framerate;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Called before the splash screen appears to initialize the settings
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void OnBeforeSplashScreen()
        {
            SetFramerate(DEFAULT_FRAMERATE);
            Application.lowMemory += OnApplicationLowMemory;
            Application.focusChanged += OnApplicationFocusChanged;
        }

        /// <summary>
        /// Called when the application loses or regains focus
        /// </summary>
        /// <param name="focus">TRUE is the application is focus, FALSE if it runs in the background</param>
        private static void OnApplicationFocusChanged(bool focus)
        {
            Application.targetFrameRate = focus ? _userDefinedFrameRate : UNFOCUSED_FRAMERATE;
        }

        /// <summary>
        /// Called when the applications runs out of memory
        /// </summary>
        private static void OnApplicationLowMemory()
        {
            // Remove all assets and scripts with no references.
            // Also calls GC.Collect() internally.

            Resources.UnloadUnusedAssets();
        }

        #endregion
    }
}