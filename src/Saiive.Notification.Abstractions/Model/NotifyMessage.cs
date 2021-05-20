using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiive.Notification.Abstractions.Model
{
    public class NotifyMessage
    {

        private NotifyMessage()
        {

        }

        public NotifyMessage(SubscriptionsEntity subscription)
        {
            Subscription = subscription;
        }

        public SubscriptionsEntity Subscription { get; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
