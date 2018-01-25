using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp.Events
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }    
    }

    public class VideoEncoder
    {
        // 1- Define a delegate
        // 2- Define an event
        // 3- Raise the event

        // public delegate void VideoEncodedEventHandler(object sender, VideoEventArgs args);

        // EventHandler
        // EventHandler<TEventArgs>

        //public event VideoEncodedEventHandler VideoEncoded;

        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            //if(VideoEncoded != null)
            //    VideoEncoded(this, EventArgs.Empty);

            VideoEncoded?.Invoke(this, new VideoEventArgs{Video = video});
        }
    }
}
