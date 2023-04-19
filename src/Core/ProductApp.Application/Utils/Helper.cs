using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;

namespace ProductApp.Application.Utils
{
    public static class Helper
    {
        public static string HttpPostJson(string url, string method, string json, int timeout = 0)
        {
            if (string.IsNullOrEmpty(url) /*|| string.IsNullOrEmpty(method)*/)
            {
                throw new System.Exception(string.Format("Url : {0}, Method : {1}, json : {2}", url, method, json));
            }
            HttpWebRequest httpWebRequest;
            if (string.IsNullOrEmpty(method))
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            else
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url + method);
            }
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            if (timeout > 0)
            {
                httpWebRequest.Timeout = timeout * 1000;
            }
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var result = streamReader.ReadToEnd();
            return result;
        }

        public static string HttpGetJson(string url, string qStr, int timeout = 0)
        {
            using (var htp = new HttpClient())
            {
                if (timeout > 0)
                    htp.Timeout = TimeSpan.FromSeconds(timeout);

                var data = htp.GetStringAsync(url + "?" + qStr);
                return data.Result;
            }
        }

        public static string GetConfigStr(string key)
        {
            try
            {
                if (ConfigurationManager.AppSettings.Count != 0)
                {
                    if (ConfigurationManager.AppSettings[key] == null)
                        return String.Empty;
                    else
                        return ConfigurationManager.AppSettings[key];
                }
                return String.Empty;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static string GetConfigStr(string key, string defaultStr)
        {
            var str = GetConfigStr(key);
            return str.Length > 0 ? str : defaultStr;
        }

        public static int GetConfigInt(string key, int defaultStr)
        {
            var str = GetConfigStr(key);
            return str.Length > 0 ? int.Parse(str) : defaultStr;
        }

        public static List<int> GetConfigIntList(string key)
        {
            try
            {
                List<int> returnValues = new List<int>();
                var str = GetConfigStr(key);
                var strList = str.Split(";").ToList();
                strList.ForEach(p => returnValues.Add(int.Parse(p)));
                return returnValues;
            }
            catch (Exception)
            {
                return new List<int>();
            }

        }

        public static List<string> GetConfigStringList(string key)
        {
            try
            {
                var str = GetConfigStr(key);
                return str.Split(";").ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public static string CalculateHash(string input)
        {
            System.Security.Cryptography.SHA512 sha = new System.Security.Cryptography.SHA512CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashingbytes = sha.ComputeHash(bytes);

            string hash = Convert.ToBase64String(hashingbytes);
            return hash;
        }

        public static bool CheckMsisdn(string msisdn)
        {
            if (msisdn.StartsWith("5") && msisdn.Length == 10 && long.TryParse(msisdn, out _))
            {
                return true;
            }
            return false;
        }

        public static bool CheckIp(string ipString)
        {
            if (ipString.Count(c => c == '.') != 3) return false;
            return IPAddress.TryParse(ipString, out _);
        }
        public static string CalculateHashSHA1(string value)
        {
            var data = Encoding.UTF8.GetBytes(value);
            var hashData = new System.Security.Cryptography.SHA1Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }
            return hash;
        }

    }
}
