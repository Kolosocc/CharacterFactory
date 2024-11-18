using System.Drawing;

namespace CharacterFactoryNameSpace
{
    public class Character : ICharacter
    {
        public string Name { get; private set; }
        public string Role { get; private set; }

        public Character(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public void DisplayInfo()
        {
            var (image, level) = CharacterFactory.GetCharacterAttributes(Name, Role);
            Console.WriteLine($"Имя: {Name}, Роль: {Role}, Уровень: {level}, Картинка: {image}");
            Console.WriteLine("Изображение:");
            DisplayImage(image);
        }

        private void DisplayImage(string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image) && File.Exists(image))
                {
                    using (Bitmap bitmap = new Bitmap(image))
                    {
                        int width = 20;
                        int height = 10;

                        Bitmap resizedBitmap = new Bitmap(bitmap, new System.Drawing.Size(width, height));

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                Color pixel = resizedBitmap.GetPixel(x, y);
                                int brightness = CalculateBrightness(pixel);
                                char symbol = GetSymbolForBrightness(brightness);
                                Console.Write(symbol);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: изображение не найдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private int CalculateBrightness(Color pixel)
        {
            return (int)((0.1 * pixel.R + 0.5 * pixel.G + 0.01 * pixel.B) / 255 * (CharacterFactory.BrightnessMap.Length - 1));
        }

        private char GetSymbolForBrightness(int brightness)
        {
            return CharacterFactory.BrightnessMap[brightness];
        }
    }
}
