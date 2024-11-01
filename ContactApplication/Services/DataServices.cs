using ContactApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Services
{
    internal class DataServices
    {
        static string userFilePath = ConfigurationManager.AppSettings["UserFilePath"];
    
        static List<T> GetData<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }


        static void SaveData<T>(string filePath, List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        // Method to get users
        public static List<User> GetUsers()
        {
            return GetData<User>(userFilePath);
        }

        // Method to save users
        public static void SaveUsers(List<User> users)
        {
            SaveData(userFilePath, users);
        }

       
    }

    
}

