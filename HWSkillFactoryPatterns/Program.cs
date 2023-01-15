using HWSkillFactoryPatterns;

static class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите ссылку на видео с YouTube");
        // создадим отправителя
        var CommandSender = new CommandSender();

        // создадим получателя
        var video = new Video(Console.ReadLine());

        // создадим команду
        var commandOne = new VideoAction(video);

        // инициализация команды
        CommandSender.SetAction(commandOne);

        //  выполнение
        CommandSender.GetInfo();
        CommandSender.Download();

        Console.ReadKey();
    }
}