using System;

namespace AdvancedCSharp.Events
{

    public class MailService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs e)
        {
            Console.WriteLine($"Mail Service: Sending an email {e?.Video.Title}");
        }
    }

}
