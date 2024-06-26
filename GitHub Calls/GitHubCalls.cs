﻿using FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.GitHub_Calls
{
    public static class GitHubCalls
    {
        public static List<Objects.GitHub_Objects.Release> GetReleases()
        {
            List<Objects.GitHub_Objects.Release> releases = new List<Objects.GitHub_Objects.Release>();

            string releasesURL = "https://api.github.com/repos/maphillips1/EveHelperWF/releases";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            System.Net.Http.HttpResponseMessage response = client.GetAsync(releasesURL).Result;

            if (response != null && response.IsSuccessStatusCode)
            {
                string releasesContent = response.Content.ReadAsStringAsync().Result;
                releases = JsonConvert.DeserializeObject<List<Objects.GitHub_Objects.Release>>(releasesContent);
            }
            return releases;
        }

        public static Tuple<bool, Objects.GitHub_Objects.Release> CheckForUpdate()
        {
            try
            {
                List<Objects.GitHub_Objects.Release> releases = GetReleases();

                Version version = Assembly.GetExecutingAssembly().GetName().Version;

                foreach (Objects.GitHub_Objects.Release release in releases)
                {
                    if (IsVersionNewer(release, version))
                    {
                        return Tuple.Create(true, release);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogError(ex.Message, ex.StackTrace);
            }

            return Tuple.Create<bool, Objects.GitHub_Objects.Release>(false, new Objects.GitHub_Objects.Release());
        }

        private static bool IsVersionNewer(Objects.GitHub_Objects.Release release, Version currentVersion)
        {
            if (release != null)
            {
                string[] releaseVersion = release.tag_name.Replace("v", "").Replace("-", "").ToLowerInvariant().Replace("beta", "").Trim().Split('.');
                //major = pos0
                //minor = pos1
                //build = pos2

                if (releaseVersion.Length == 3)
                {
                    int majorVersion = Convert.ToInt32(releaseVersion[0]);
                    int minorVersion = Convert.ToInt32(releaseVersion[1]);
                    int buildVersion = Convert.ToInt32(releaseVersion[2]);

                    if (majorVersion > currentVersion.Major)
                    {
                        return true;
                    }
                    if (majorVersion == currentVersion.Major && minorVersion > currentVersion.Minor)
                    {
                        return true;
                    }
                    if (majorVersion == currentVersion.Major && minorVersion == currentVersion.Minor && buildVersion > currentVersion.Build)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string CreateIssue(string title, string body)
        {
            string returnURL = "";

            try
            {
                Objects.GitHub_Objects.CreateIssueResponse issueResponse = new Objects.GitHub_Objects.CreateIssueResponse();
                string? githubToken = "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";
                if (githubToken != null)
                {
                    Objects.GitHub_Objects.CreateIssueRequest issueRequest = new Objects.GitHub_Objects.CreateIssueRequest();
                    issueRequest.title = title;
                    issueRequest.body = body;
                    StringContent messageBody = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(issueRequest));
                    string releasesURL = "https://api.github.com/repos/maphillips1/EveHelperWF/issues";
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
                    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                    client.DefaultRequestHeaders.Add("User-Agent", "request");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + githubToken);
                    

                    System.Net.Http.HttpResponseMessage response = client.PostAsync(releasesURL, messageBody).Result;

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string issueResponseContent = response.Content.ReadAsStringAsync().Result;
                        issueResponse = JsonConvert.DeserializeObject<Objects.GitHub_Objects.CreateIssueResponse>(issueResponseContent);
                        returnURL = issueResponse.url;
                        returnURL = returnURL.Replace("api.", "").Replace("repos/", "");
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogError(ex.Message, ex.StackTrace);
            }

            return returnURL;
        }
    }
}
