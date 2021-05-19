using System;
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
        public override string Type => "twitter";

        public TwitterHandler(ILogger<TwitterHandler> logger)
        {
            _logger = logger;
        }

        public override async Task Send(NotifyMessage message) {
            try
            {
                var appCredentials = new TwitterCredentials(message.ConnectionStringParts["consumerKey"],
                    message.ConnectionStringParts["consumerSecret"],
                    message.ConnectionStringParts["accessToken"],
                    message.ConnectionStringParts["accessTokenSecret"]);

                var appClient = new TwitterClient(appCredentials);
                await appClient.Tweets.PublishTweetAsync(message.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not send tweet...");
            }
        }

        public override Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            subscription.NotificationConnectionString = subscription.NotificationConnectionString.Replace("twitter", "mail");
            return base.Activated(subscription, information);
        }

        public override Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information)
        {
            subscription.NotificationConnectionString = subscription.NotificationConnectionString.Replace("twitter", "mail");
            return base.Added(subscription, information);
        }

        public override Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            subscription.NotificationConnectionString = subscription.NotificationConnectionString.Replace("twitter", "mail");
            return base.Deactivated(subscription, information);
        }
    }
}
