using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValheimPlusRewrite.Configurations;

namespace ValheimPlusRewrite.Handlers.AdvancedModes
{
    internal class AdvancedModeBase
    {
        // Control Flags
        protected static bool controlFlag;
        protected static bool shiftFlag;
        protected static bool altFlag;

        protected static float currentModificationSpeed = 1;

        private const float MIN_MODIFICATION_SPEED = 1;
        private const float MAX_MODIFICATION_SPEED = 30;

        protected static void NotifyUser(string system, string Message, MessageHud.MessageType position)
        {
            MessageHud.instance.ShowMessage(position, $"{system}: " + Message);
        }

        protected static void IsRunning(string system, bool isActive)
        {
            if (isActive)
            {
                MessageHud.instance.ShowMessage(MessageHud.MessageType.Center, $"{system} is active");
            }
        }

        protected static void DetectKeyFlags()
        {
            // CONTROL PRESSED
            if (Input.GetKeyDown(KeyCode.LeftControl)) { controlFlag = true; }
            if (Input.GetKeyUp(KeyCode.LeftControl)) { controlFlag = false; }
            // SHIFT PRESSED
            if (Input.GetKeyDown(KeyCode.LeftShift)) { shiftFlag = true; }
            if (Input.GetKeyUp(KeyCode.LeftShift)) { shiftFlag = false; }
            // LEFT ALT PRESSED
            if (Input.GetKeyDown(KeyCode.LeftAlt)) { altFlag = true; }
            if (Input.GetKeyUp(KeyCode.LeftAlt)) { altFlag = false; }
        }

        protected static void ChangeModificationSpeed(string system, KeyCode increaseSpeed, KeyCode decreaseSpeed)
        {
            float speedDelta = 1;
            if (shiftFlag)
            {
                speedDelta = 10;
            }

            if (Input.GetKeyDown(increaseSpeed))
            {
                currentModificationSpeed = Mathf.Clamp(currentModificationSpeed + speedDelta, MIN_MODIFICATION_SPEED, MAX_MODIFICATION_SPEED);
                NotifyUser(system, "Modification Speed: " + currentModificationSpeed, MessageHud.MessageType.TopLeft);
            }

            if (Input.GetKeyDown(decreaseSpeed))
            {
                currentModificationSpeed = Mathf.Clamp(currentModificationSpeed - speedDelta, MIN_MODIFICATION_SPEED, MAX_MODIFICATION_SPEED);
                NotifyUser(system, "Modification Speed: " + currentModificationSpeed, MessageHud.MessageType.TopLeft);
            }
        }
    }
}
