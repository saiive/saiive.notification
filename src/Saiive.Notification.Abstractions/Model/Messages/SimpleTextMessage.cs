
using System.Text;
using System.Threading.Tasks;

namespace Saiive.Notification.Abstractions.Model.Messages
{
    public class SimpleTextMessage : NotifyMessage
    {
        public string Text { get; }
     

        public SimpleTextMessage(SubscriptionsEntity subscription, string text, string title) : base(subscription, title)
        {
            Text = text;
        }

        public override Task<string> ToMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Title);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(Text);


            return Task.FromResult(stringBuilder.ToString());
        }
    }

}