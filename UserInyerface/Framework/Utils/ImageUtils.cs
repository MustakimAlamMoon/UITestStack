using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;

namespace UserInyerface.Framework.Utils
{
    /// <summary>
    /// Provides utility methods for handling image-related tasks,
    /// including uploading images using AutoIT or InputSimulator.
    /// </summary>
    internal class ImageUtils
    {
        // Base directory of the application.
        private static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Relative paths to the image file and upload script.
        private const string imageFilePath = @"Resources\Files\New Year.jpg";
        private const string imageUploadScriptPath = @"Resources\Files\ImageUploadScript.exe";

        /// <summary>
        /// Gets the full path of the image file.
        /// </summary>
        /// <returns>Full path of the image file.</returns>
        private static string GetImageFilePath() => Path.Combine(baseDirectory, imageFilePath);

        /// <summary>
        /// Gets the full path of the image upload script.
        /// </summary>
        /// <returns>Full path of the image upload script.</returns>
        private static string GetImageUploadScriptPath() => Path.Combine(baseDirectory, imageUploadScriptPath);

        /// <summary>
        /// Runs an AutoIT script to upload an image.
        /// </summary>
        [Obsolete("Temporarily disabled. Instead of AutoIT, currently using InputSimulator to upload image.")]
        public static void RunAutoITScriptToUploadImage()
        {
            try
            {
                // Retrieve the script path.
                string scriptPath = GetImageUploadScriptPath();

                // Check if the script file exists.
                if (!File.Exists(scriptPath))
                    throw new FileNotFoundException("Upload script not found.", scriptPath);

                // Initialize the process to run the script.
                Process process = new()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = scriptPath,
                        UseShellExecute = false
                    }
                };

                // Start the script process.
                process.Start();

                // Wait for the script process to exit.
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the script execution.
                Debug.WriteLine($"Error running upload script: {ex.Message}");
            }
        }

        /// <summary>
        /// Uses InputSimulator to simulate keyboard input for uploading an image.
        /// </summary>
        public static void RunInputSimulatorScriptToUploadImage()
        {
            try
            {
                // Retrieve the image file path.
                string imageLocationPath = GetImageFilePath();

                // Check if the image file exists.
                if (!File.Exists(imageLocationPath))
                    throw new FileNotFoundException("Image file not found.", imageLocationPath);

                var inputSimulator = new InputSimulator();

                // Simulate pressing the SELECT key.
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SELECT);
                Thread.Sleep(1000);

                // Simulate typing the image file path.
                inputSimulator.Keyboard.TextEntry(imageLocationPath);
                Thread.Sleep(1000);

                // Simulate pressing the RETURN key.
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the image upload process.
                Debug.WriteLine($"Error uploading image: {ex.Message}");
            }
        }
    }
}
