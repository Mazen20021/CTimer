using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CTimer.Updates
{
    internal class Hub
    {
        private const string RepositoryOwner = "Mazen20021";
        private const string RepositoryName = "CTimer";
        private const string ApiUrl = "https://api.github.com/repos/{0}/{1}/releases/latest";
        private void BackupFiles(string backupFolderPath, string currentFolderPath)
        {
            if (!Directory.Exists(backupFolderPath))
                Directory.CreateDirectory(backupFolderPath);

            // Move all files from the current folder to the backup folder
            foreach (string file in Directory.GetFiles(currentFolderPath))
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(backupFolderPath, fileName);
                File.Move(file, destinationPath);
            }
        }
        private string GetCurrentVersion()
        {
            // TODO: Return the current version of the downloaded program
            return "1.0.0"; // Replace with your actual implementation
        }

        private string GetLatestVersionFromGitHub()
        {
            string apiUrl = string.Format(ApiUrl, RepositoryOwner, RepositoryName);

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.UserAgent = "UpdateChecker"; // Set a custom user agent
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string jsonResponse = reader.ReadToEnd();
                            dynamic release = JsonConvert.DeserializeObject(jsonResponse);
                            return release.tag_name;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Handle any errors that occur during the API request
                Console.WriteLine("Error occurred while fetching latest version from GitHub: " + e.Message);
            }

            return null;
        }

        public void CheckForUpdates()
        {
            string currentVersion = GetCurrentVersion();
            string latestVersion = GetLatestVersionFromGitHub();
            try
            {
                if (latestVersion != null && currentVersion != latestVersion)
                {
                    // New update available
                    var x = MessageBox.Show("New update available! Current version: " + currentVersion + ", Latest version: " + latestVersion + "Wanna Update Now ?", "New Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult.Yes == x)
                    {
                        string backupFolderPath = Path.Combine(Environment.CurrentDirectory, "Backup");
                        string currentFolderPath = Environment.CurrentDirectory;
                        try
                        {
                            // Create a backup folder and move the old files to it
                            BackupFiles(backupFolderPath, currentFolderPath);

                            // Download the latest release files from GitHub and extract them to the current folder
                            // Replace this with your actual download and extraction logic
                            DownloadAndExtractRelease(latestVersion);

                            MessageBox.Show("Update completed successfully!", "Program Updated !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception e)
                        {
                            BackupFiles(currentFolderPath, backupFolderPath);
                            // Handle any errors that occur during the update process
                            MessageBox.Show("Error occurred during the update process Rolling Back: " + e.Message, "Update Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (latestVersion != null && currentVersion == latestVersion)
                {
                    // Up to date
                    MessageBox.Show("You have the latest version: " + currentVersion, "No Update");
                }
                else
                {
                    MessageBox.Show("ERROR: " + currentVersion, "No Update");
                }
            }catch(Exception e)
            {
                var x = MessageBox.Show("Failed to check for updates. try again ? Dueto: "+e, "Connection Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DialogResult.Yes == x)
                {
                    CheckForUpdates();
                }
            }
        }
        private void DownloadAndExtractRelease(string latestVersion)
        {
            string downloadUrl = $"https://github.com/{RepositoryOwner}/{RepositoryName}/releases/download/{latestVersion}/{RepositoryName}.zip";
            string zipFilePath = Path.Combine(Environment.CurrentDirectory, $"{RepositoryName}.zip");
            string extractFolderPath = Environment.CurrentDirectory;

            try
            {
                using (WebClient client = new WebClient())
                {
                    MessageBox.Show("Downloading the latest release...");

                    // Download the release zip file
                    client.DownloadFile(downloadUrl, zipFilePath);

                    MessageBox.Show("Download completed!");

                    MessageBox.Show("Extracting the release files...");

                    // Extract the zip file to the current folder
                    ZipFile.ExtractToDirectory(zipFilePath, extractFolderPath);

                    MessageBox.Show("Extraction completed!");

                    // Delete the downloaded zip file
                    File.Delete(zipFilePath);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred during the download and extraction process: " + e.Message);
            }
        }
    }
}

