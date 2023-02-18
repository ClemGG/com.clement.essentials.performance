using UnityEngine;

namespace Essentials.Performance.Samples
{
    /// <summary>
    /// Prints the application target framerate
    /// when focused and unfocused on the game window
    /// </summary>
    public class FPSLogger : MonoBehaviour
    {
        #region Unity methods

        private void Update()
        {
            Debug.Log(Application.targetFrameRate);
        }

        #endregion
    }
}