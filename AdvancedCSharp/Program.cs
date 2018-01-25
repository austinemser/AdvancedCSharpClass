using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedCSharp.Delegates;
using AdvancedCSharp.Events;
using AdvancedCSharp.Generics;
using AdvancedCSharp.Lambda;

namespace AdvancedCSharp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var number = new System.Nullable<int>(5);
            Console.WriteLine("Has Value ?" + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());

            Delegates();
            Lambda();
            Events();
        }

        static void Delegates()
        {
            var photoProcessor = new PhotoProcessor();
            var filters = new PhotoFilters();

            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            photoProcessor.Process("test", filterHandler);
        }

        static void Lambda()
        {
            // args => expression
            //number => number * number;
            // () => ...
            // x => ...
            // (x, y, z) => ...

            int NumFunc(int number) => number * number;
            Func<int, int> numFunc = number => number * number;

            const int factor = 5;

            Func<int, int> multiplier = n => n * factor;

            // Get books that are cheaper than $10
            var books = new BookRepository().GetBooks();

            //var cheapBooks = books.FindAll(IsCheaperThan10Dollars);

            var cheapBooks = books.FindAll(b => b.Price < 10);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine(NumFunc(5));

        }

        static void Events()
        {
            var video = new Video() {Title = "Video 1"};
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); // subscriber
            var messageService = new MessageService();  // subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }

        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }
           

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Remove red eye");
        }
    }
}
