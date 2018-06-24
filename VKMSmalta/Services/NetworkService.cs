﻿#region Usings

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKMSmalta.Domain;
using VKMSmalta.Network;

#endregion

namespace VKMSmalta.Services
{
    public class NetworkService
    {
        private readonly AdminUri adminUri;

        private string accessToken;

        private NetworkService(AdminUri adminUri)
        {
            this.adminUri = adminUri;
        }

        public static NetworkService Instance { get; private set; }

        public static void InitializeService(AdminUri adminUri)
        {
            if (Instance == null)
            {
                Instance = new NetworkService(adminUri);
            }
        }

        private void AuthValidate(HttpClient client)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Вы не авторизованы в системе");
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        private void InsertDefaultHttpClientSettings(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(10);
        }

        private async Task<HttpResponseMessage> SendGetRequestCore(string uri, bool authorize = false)
        {
            using (var httpClient = new HttpClient())
            {
                if (authorize)
                {
                    AuthValidate(httpClient);
                }

                InsertDefaultHttpClientSettings(httpClient);

                var response = await httpClient.GetAsync(uri);
                return response;
            }
        }

        private async Task<HttpResponseMessage> SendPostRequestCore(string uri, object content, bool authorize = false)
        {
            using (var httpClient = new HttpClient())
            {
                if (authorize)
                {
                    AuthValidate(httpClient);
                }

                InsertDefaultHttpClientSettings(httpClient);

                var json = JsonConvert.SerializeObject(content);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(uri, body);
                return response;
            }
        }

        public async Task<Student> Authorize(NetworkCredential credential)
        {
            var response = await SendPostRequestCore(adminUri.AdminAuthorizeUri, credential);
            if (response.IsSuccessStatusCode)
            {
                var responseContentJson = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<AuthorizeResponseDto>(responseContentJson);
                accessToken = responseContent.token;
                return responseContent.Student;
            }

            return null;
        }

        public async Task<IEnumerable<TeamWithStudentsWithoutLoginsDto>> GetTeamsAndStudentsWithoutLogin()
        {
            var response = await SendGetRequestCore(adminUri.AdminGetFreeStudentsUri);
            if (response.IsSuccessStatusCode)
            {
                var responseContentJson = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<IEnumerable<TeamWithStudentsWithoutLoginsDto>>(responseContentJson);
                return responseContent;
            }

            throw new Exception("Ошибка на сервере");
        }

        public async Task<bool> Register(RegisterDataDto registerData)
        {
            var response = await SendPostRequestCore(adminUri.AdminRegisterUri, registerData);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendExamineResultToAdmin(ExamineResult examineResult)
        {
            var result = await SendPostRequestCore(adminUri.AdminAddHistoryUri, examineResult, true);
            return result.IsSuccessStatusCode;
        }
    }
}