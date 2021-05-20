using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Saiive.Notification.Abstractions.Model.Messages;

namespace Saiive.Notification.Abstractions.Model
{
    public abstract class NotifyMessage
    {
        private NotifyMessage()
        {

        }

        protected NotifyMessage(SubscriptionsEntity subscription, string title)
        {
            Subscription = subscription;
            Title = title;
        }

        public string Title { get; }

        public SubscriptionsEntity Subscription { get; }

        public abstract Task<string> ToMessage();

        public static NotifyMessage Decode(string type, string json)
        {
            if (type == nameof(SimpleTextMessage))
            {
                return JsonConvert.DeserializeObject<SimpleTextMessage>(json);
            }
            if (type == nameof(UrlTextMessage))
            {
                return JsonConvert.DeserializeObject<UrlTextMessage>(json);
            }

            throw new ArgumentException($"{type} could not be found!");
        }
    }
}
