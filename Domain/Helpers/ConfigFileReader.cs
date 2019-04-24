using Domain.Objects;
using System;
using System.IO;

namespace Domain.Helpers
{
    public class ConfigFileReader
    {
        private readonly string[] _configFile;

        public ConfigFileReader()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var solutionPath = currentDirectory.Remove(currentDirectory.IndexOf("PolteqTests") + "PolteqTests".Length);

                var configFilePath = solutionPath + "\\appconfig.txt";
                _configFile = File.ReadAllLines(configFilePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new FileNotFoundException("config file not found! Be sure that appconfig.txt is placed in main solution folder!");
            }
        }

        public Credentials GetCredentials()
        {
            var credentials = new Credentials()
            {
                Username = _configFile[0],
                Password = _configFile[1]
            };
            return credentials;
        }

        public bool GetShouldLog()
        {
            if (_configFile[2].Replace(" ", "").ToLower().Equals("false"))
            {
                return false;
            }
            else return true;
        }
    }
}
