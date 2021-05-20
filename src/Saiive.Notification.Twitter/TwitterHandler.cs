using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;
using Tweetinvi;
using Tweetinvi.Models;

namespace Saiive.Notification.Twitter
{
    public class TwitterHandler : MessageHandler
    {
        private readonly ILogger _logger;
        public override NotificationType Type => NotificationType.Twitter;

        private const string ConsumerKeyProperty = "consumerKey";
        private const string ConsumerSecretProperty = "consumerSecret";
        private const string AccessTokenProperty = "accessToken";
        private const string AccessTokenSecretProperty = "accessTokenSecret";
        private const string ToProperty = "to";

        public TwitterHandler(ILogger<TwitterHandler> logger)
        {
            _logger = logger;
        }
        protected override Task<bool> CheckIsValid(SubscriptionsEntity subscription, Dictionary<string, string> connectionSettings)
        {
            if (!connectionSettings.ContainsKey(ConsumerKeyProperty))
            {
                throw new ArgumentException($"{ConsumerKeyProperty} must be set!", ConsumerKeyProperty);
            }

            if (!connectionSettings.ContainsKey(ConsumerSecretProperty))
            {
                throw new ArgumentException($"{ConsumerSecretProperty} must be set!", ConsumerSecretProperty);
            }
            
            if (!connectionSettings.ContainsKey(AccessTokenProperty))
            {
                throw new ArgumentException($"{AccessTokenProperty} must be set!", AccessTokenProperty);
            }

            if (!connectionSettings.ContainsKey(AccessTokenSecretProperty))
            {
                throw new ArgumentException($"{AccessTokenSecretProperty} must be set!", AccessTokenSecretProperty);
            }

            if (!connectionSettings.ContainsKey(ToProperty))
            {
                throw new ArgumentException($"{ToProperty} must be set to confirm the twitter account!", ToProperty);
            }

            return Task.FromResult(true);
        }

        public override async Task Send(NotifyMessage message, Dictionary<string, string> connectionSettings) {
            try
            {
                var appCredentials = new TwitterCredentials(connectionSettings[ConsumerKeyProperty],
                    connectionSettings[ConsumerSecretProperty],
                    connectionSettings[AccessTokenProperty],
                    connectionSettings[AccessTokenSecretProperty]);

                var appClient = new TwitterClient(appCredentials);
                await appClient.Tweets.PublishTweetAsync(await message.ToMessage());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not send tweet...");
            }
        }

        public override Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            subscription.NotificationType = NotificationType.Mail;
            return base.Activated(subscription, information);
        }

        public override Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information)
        {
            subscription.NotificationType = NotificationType.Mail;
            return base.Added(subscription, information);
        }

        public override Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            subscription.NotificationType = NotificationType.Mail;
            return base.Deactivated(subscription, information);
        }
    }
}
