using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Reflection;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace esthar_practice
{
    class Updater
    {
		static async public Task<bool> IsUpdateRequired()
        {
			string currentVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
			string apiUrl = "https://api.github.com/repos/brofar/esthar-practice/releases/latest";
			using (var httpClient = new HttpClient())
			{
				string latestVersion = "";
				httpClient.DefaultRequestHeaders.Add("User-Agent", "brofar/esthar-practice");
				try
                {
					var result = await httpClient.GetStringAsync(apiUrl);
					var json = JsonConvert.DeserializeObject<dynamic>(result);
					latestVersion = json.tag_name;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}

				if(currentVersion != latestVersion)
                {
					return true;
                }
				return false;
			}
		}
	}
}