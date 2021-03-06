﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Wired.SlackErrors.Module.Configuration;

namespace Wired.SlackErrors.Module
{
    public class Interceptor : IHttpModule
    {
        private HttpApplication _context;

        public void Init(HttpApplication context)
        {
            _context = context;
            _context.Error += OnError;
        }

        private static void OnError(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;

            Task.Run(() => 
                PushEvent(application)
            );
        }

        private static void PushEvent(HttpApplication application)
        {
            var config = SlackErrorsConfiguration.Settings;

            var eventData = GetEventData(application);
            var client = new HttpClient();

            var message = new Message
            {
                Username = $"Website Errors [{config.ApplicationName}]",
                Text = $"Error occurred in {config.ApplicationName} on {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}",
                Attachments = new List<Attachment>
                {
                    new Attachment
                    {
                        Title = eventData.ExceptionType,
                        PreText = "Message",
                        Text = eventData.EventTitle
                    },
                    new Attachment
                    {
                        PreText = "Stack Trace",
                        Text = eventData.EventBody
                    }
                }
            };

            foreach (ChannelElement channel in config.Channels)
            {
                var postToChannel = true;

                if (!string.IsNullOrEmpty(channel.TypeFilter))
                {
                    if (!Regex.Match(eventData.ExceptionType, channel.TypeFilter).Success)
                    {
                        postToChannel = false;
                    }
                }

                if (!string.IsNullOrEmpty(channel.TraceFilter))
                {
                    if (!Regex.Match(eventData.ExceptionType, channel.TypeFilter).Success)
                    {
                        postToChannel = false;
                    }
                }

                if (!postToChannel)
                {
                    continue;
                }

                var postTask = client.PostAsJsonAsync(channel.PostUrl, message);
                postTask.Wait();

                var readTask = postTask.Result.Content.ReadAsStringAsync();
                readTask.Wait();
            }

        }

        private static ExceptionEventData GetEventData(HttpApplication application)
        {
            var lastError = application.Server.GetLastError();
            return new ExceptionEventData(lastError);
        }

        public void Dispose()
        {
            _context = null;
        }

    }
}
