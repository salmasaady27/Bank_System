using Bank_BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsername(string Username)
        {
            try
            {
                // Det the current project's directory(folder path)
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Then create text file where you want to save the data
                string filePath = currentDirectory + "\\DataLogin.txt";

                // Incase Username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                // Write Username and Password with separator
                string DataToSave = Username;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(DataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\DataLogin.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
        public static bool RememberUsernameWithRegistry(string Username)
        {
            // Registry Path
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Projects\Bank_Login";

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);

                return true;

            }
            catch //(Exception ex)
            {
                return false;
            }
        }

        public static bool GetStoredCredentialWithRegistry(ref string Username)
        {

            // Registry Path 
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Projects\Bank_Login";

            try
            {
                // Read the value from the Registry
                Username = Registry.GetValue(keyPath, "Username", null) as string;

                if (Username != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
