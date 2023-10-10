using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
class UdpClientExample
{
    static void Main(string[] args)
    {
        string serverIp = "127.0.0.1"; 
        int serverPort = 12345; 


        using (UdpClient udpClient = new UdpClient())
        {

            Dictionary<int, string> fontMappings = new Dictionary<int, string>
            {
                {1, "Arial"},
                {2, "Times New Roman"},
                {3, "Verdana"},
            };

            while (true)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1. Clear Display");
                Console.WriteLine("2. Draw Pixel");
                Console.WriteLine("3. Draw Line");
                Console.WriteLine("4. draw rectangle");
                Console.WriteLine("5. fill rectangle");
                Console.WriteLine("6. draw ellipse");
                Console.WriteLine("7. fill ellipse");
                Console.WriteLine("8. Draw Text");
                Console.WriteLine("9. Draw Image");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Неправильный выбор команды.");
                    continue;
                }

          
                string command = "";
                switch (choice)
                {
                    case 1:
                        command = "clear display";
                        break;
                    case 2:
                        command = "draw pixel";
                        break;
                    case 3:
                        command = "draw line";
                        break;
                    case 4:
                        command = "draw rectangle";
                        break;
                    case 5:
                        command = "fill rectangle";
                        break;
                    case 6:
                        command = "draw ellipse";
                        break;
                    case 7:
                        command = "fill ellipse";
                        break;
                    case 8:
                        command = "draw text"; 
                        break;
                    case 9:
                        command = "draw image"; 
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор команды.");
                        continue;
                }

                Console.WriteLine($"Выбрана команда: {command}");

                string parameters = "";
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите цвет для очистки:");
                        string colorClear = Console.ReadLine();
                        parameters = colorClear;
                        break;
                    case 2:
                        Console.WriteLine("Введите x-координату:");
                        int xPixel = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y-координату:");
                        int yPixel = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorPixel = Console.ReadLine();
                        parameters = $"{xPixel},{yPixel},{colorPixel}";
                        break;
                    case 3:
                        Console.WriteLine("Введите x0:");
                        int x0Line = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y0:");
                        int y0Line = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите x1:");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y1:");
                        int y1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorLine = Console.ReadLine();
                        parameters = $"{x0Line},{y0Line},{x1},{y1},{colorLine}";
                        break;
                    case 4:
                        Console.WriteLine("Введите x0:");
                        int x0Rect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y0:");
                        int y0Rect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите ширину:");
                        int wRect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите высоту:");
                        int hRect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorRect = Console.ReadLine();
                        parameters = $"{x0Rect},{y0Rect},{wRect},{hRect},{colorRect}";
                        break;
                    case 5:
                        Console.WriteLine("Введите x0:");
                        int x0FillRect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y0:");
                        int y0FillRect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите ширину:");
                        int wFillRect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите высоту:");
                        int hFillRect = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorFillRect = Console.ReadLine();
                        parameters = $"{x0FillRect},{y0FillRect},{wFillRect},{hFillRect},{colorFillRect}";
                        break;
                    case 6:
                        Console.WriteLine("Введите x-координату центра:");
                        int xEllipse = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y-координату центра:");
                        int yEllipse = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите горизонтальный радиус:");
                        int radiusX = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите вертикальный радиус:");
                        int radiusY = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorEllipse = Console.ReadLine();
                        parameters = $"{xEllipse},{yEllipse},{radiusX},{radiusY},{colorEllipse}";
                        break;
                    case 7:
                        Console.WriteLine("Введите x-координату центра:");
                        int xEllipseFill = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y-координату центра:");
                        int yEllipseFill = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите горизонтальный радиус:");
                        int radiusXFill = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите вертикальный радиус:");
                        int radiusYFill = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorEllipseFill = Console.ReadLine();
                        parameters = $"fill ellipse:{xEllipseFill},{yEllipseFill},{radiusXFill},{radiusYFill},{colorEllipseFill}";
                        break;
                    case 8:
                        Console.WriteLine("Введите x0:");
                        int x0Text = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y0:");
                        int y0Text = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цвет:");
                        string colorText = Console.ReadLine();
                        Console.WriteLine("Введите номер шрифта (1 - Arial, 2 - Times New Roman, 3 - Verdana):");
                        int fontNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите размер шрифта:");
                        int fontSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите текст:");
                        string text = Console.ReadLine();
                        string fontName;
                        if (fontMappings.TryGetValue(fontNumber, out fontName))
                        {
                            parameters = $"{x0Text},{y0Text},{colorText},{fontName},{fontSize},{text}";
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер шрифта.");
                            continue;
                        }
                        break;
                    case 9:
                        Console.WriteLine("Введите x0:");
                        int x0Image = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите y0:");
                        int y0Image = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите ширину:");
                        int wImage = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите высоту:");
                        int hImage = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите путь к изображению:");
                        string imagePath = Console.ReadLine();
                        byte[] imageBytes = LoadImage(imagePath);
                        if (imageBytes != null)
                        {
                            string imageBase64 = Convert.ToBase64String(imageBytes);
                            parameters = $"{x0Image},{y0Image},{wImage},{hImage},{imageBase64}";
                        }
                        else
                        {
                            Console.WriteLine("Ошибка загрузки изображения.");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор команды.");
                        continue;
                }
                string message = $"{command}: {parameters}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, serverIp, serverPort);
            }
        }
    }

    private static byte[] LoadImage(string imagePath)
    {
        try
        {
            return File.ReadAllBytes(imagePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
            return null;
        }
    }
}
