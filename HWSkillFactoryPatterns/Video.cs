using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace HWSkillFactoryPatterns
{
    public class Video
    {
        public string pathVideo { get; set; }
        YoutubeClient client { get; set; }
        YoutubeExplode.Videos.Video video;
        public Video(string pathVideo)
        {
            this.pathVideo = pathVideo;
            client = new YoutubeClient();
            video = client.Videos.GetAsync(pathVideo).Result;
        }

        public void GetInfo()
        {
            Console.WriteLine("Достаем информацию");
            
            string title = video.Title;
            string description = video.Description;
            Console.WriteLine("Наименование видео:" + title);
            Console.WriteLine("Описание видео:" + description);
        }

        public async Task DownloadAsync()
        {
            Console.WriteLine("Скачиваем видео");
            var streamManifest = await client.Videos.Streams.GetManifestAsync(pathVideo);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            var fileName = $"{video.Title}.{streamInfo.Container.Name}";
            await client.Videos.DownloadAsync(pathVideo, new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName + "\\"+ fileName);
            Console.WriteLine("Видео было скачано!");

        }
    }
}
