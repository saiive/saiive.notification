
using System.Text;
using System.Threading.Tasks;

namespace Saiive.Notification.Abstractions.Model.Messages
{
    public class UrlTextMessage : SimpleTextMessage
    {
        public string Url { get; }
        public string UrlText { get; }

        public UrlTextMessage(SubscriptionsEntity subscription, string text, string title, string url, string urlText) : base(subscription, text, title)
        {
            Url = url;
            UrlText = urlText;
        }

        public override Task<string> ToMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Title);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(Text);
            stringBuilder.AppendLine(Url);

            return Task.FromResult(stringBuilder.ToString());
        }
    }

}