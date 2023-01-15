using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSkillFactoryPatterns
{
    interface IAction
    {
        void GetInfo();
        void Download();

    }
    /// <summary>
    /// Команда работы с видео
    /// </summary>
    class VideoAction : IAction
    {
        Video _video;

        public VideoAction(Video video)
        {
            _video = video;
        }

        public void GetInfo()
        {
            _video.GetInfo();
        }

        public void Download()
        {
            _video.DownloadAsync();
        }
    }
    /// <summary>
    /// Отправитель команд
    /// </summary>
    class CommandSender
    {
        IAction _action;

        /// <summary>
        ///  Инициализация команды
        /// </summary>
        public void SetAction(IAction action)
        {
            _action = action;
        }

        public void GetInfo()
        {
            // запуск команды
            _action.GetInfo();
        }

        public void Download()
        {
            // запуск команды
            _action.Download();
        }
    }
}
