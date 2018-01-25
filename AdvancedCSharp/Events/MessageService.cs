using System;

namespace AdvancedCSharp.Events
{
    public class MessageService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs e)
        {
            Console.WriteLine("Message Service: sending a text " + e?.Video.Title);
        }
    }
}