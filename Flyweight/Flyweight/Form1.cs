using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Flyweight
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        // ПОЛЯ КЛИЕНТА
        private const int mapSize = 20; // Размерность карты (mapSize x mapSize клеток, каждая клетка tileSize x tileSize пикселей)
        private const int tileSize = 32; // Размер клетки в пикселях

        private Tile[,] map = new Tile[mapSize, mapSize]; // например, 20 * 32 = 640 пикселей на 640 пикселей будет размер поля
        private TileFactory tileFactory = new TileFactory(); // фабрика для взятия/создания уникальных тайлов

        private List<UnsharedCharacter> characters = new List<UnsharedCharacter>(); // уникальная (неразделяемая) часть персонажей
        private CharacterFactory characterFactory = new CharacterFactory();
        private SharedCharacter sharedCharacter;


        // ГЛОБАЛЬНЫЕ ПЕРЕМЕННЫЕ
        long totalMemory; // для мониторинга выделяемой памяти
        string nameENG; // вся игра на русском - поэтому надо переводить на english
        string selectedCharacterSkin; // выбранный скин персонажа (из combobox при создании персонажа)
        string selectedCharacter; // выбранный персонаж за которого пользователь будет играть
        int score = 0; // текущий счёт - собранные объекты

        // координаты текущего местоположения персонажа за которого играем и новые (пересчитываются при перемещении)
        int x_curr;
        int y_curr;
        int newX;
        int newY;

        string skinPath; // путь к скину
        Image skinView; // для увеличенного отображения скина при его выборе
        string characterName; // уникальный ник (имя и тд) персонажа при создании

        public MainForm()
        {
            InitializeComponent();

            panel_GameSpace.Paint += panelMap_Paint;
        }

        // ЛОГИКА ИГРЫ
        // Обработка клавиш на форме (w, a, s, d) - перемещение
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            var character = characters.FirstOrDefault(c => c.CharacterName == selectedCharacter);
            if (character == null) return;

            // Получаем общие характеристики из фабрики (по имени)
            sharedCharacter = characterFactory.GetSharedCharacter(character.skinKey);

            newX = x_curr;
            newY = y_curr;

            switch (e.KeyCode)
            {
                case Keys.W: newY--; break; // Вверх
                case Keys.S: newY++; break; // Вниз
                case Keys.A: newX--; break; // Влево
                case Keys.D: newX++; break; // Вправо
            }

            // Проверка выхода за границы карты
            if (newX < 0 || newY < 0 || newX >= mapSize || newY >= mapSize)
                return;

            // Проверяем, можно ли шагнуть на новую клетку
            if (CanMoveToTile(newX, newY))
            {
                TryCollectTile(newX, newY);
                // Очищаем старое положение персонажа, перерисовывая тайл карты
                using (Graphics g = panel_GameSpace.CreateGraphics())
                {
                    map[y_curr, x_curr]?.Draw(
                        g,
                        x_curr * tileSize,
                        y_curr * tileSize,
                        tileSize
                    );

                    // Обновляем позицию персонажа
                    x_curr = newX;
                    y_curr = newY;

                    // Рисуем персонажа только в новой позиции
                    sharedCharacter.Operation(g, x_curr, y_curr);

                    character.AddToTrajectory(x_curr, y_curr);
                    character.Operation(g, x_curr, y_curr);
                }
            }
        }

        // нет ли препятствий (BushTile, MoonStoneTile, CoalTile, RobotTile)
        private bool CanMoveToTile(int x, int y)
        {
            return map[y, x] is GrassTile || map[y, x] is MoonSandTile || map[y, x] is StoneTile || map[y, x] is TileTile
                || map[y, x] is MushroomTile || map[y, x] is CactusTile || map[y, x] is CrystalTile || map[y, x] is RadioTile;
        }

        // проверка на объекты подходящие для сбора (MushroomTile, CactusTile, CrystalTile, RadioTile)
        private void TryCollectTile(int x, int y)
        {
            if (map[y, x] is MushroomTile ||
                map[y, x] is CactusTile ||
                map[y, x] is CrystalTile ||
                map[y, x] is RadioTile)
            {
                score++;
                label_Score.Text = $"Счёт: {score}";

                // Заменяем тайл на обычный под персонажем
                 map[y, x] = GetDefaultTile();

                // Перерисовываем карту
                // panel_GameSpace.Invalidate();
            }
        }

        // для закраски тайла после перемещения
        private Tile GetDefaultTile()
        {
            switch (comboBox_Maps.SelectedItem.ToString())
            {
                case "Волшебный Лес":
                    return tileFactory.GetTile("Grass");
                case "Лунная Пустошь":
                    return tileFactory.GetTile("MoonSand");
                case "Пещера Вечного Мрака":
                    return tileFactory.GetTile("Stone");
                case "Город Механических Чудес":
                    return tileFactory.GetTile("Tile");
                default:
                    return tileFactory.GetTile("Grass");
            }
        }

        // для вывода в статусбар информации - в данном случае значение глобальной переменной memory
        private void UpdateStatusBar()
        {
            // Получаем текущий процесс
            Process proc = Process.GetCurrentProcess();
            totalMemory = proc.PrivateMemorySize64; // Общий объём занятой памяти в байтах

            toolStripStatusLabel_Info.Text = $"Используемая память: {totalMemory / 1024} KB";
        }

        // генерация карты
        private void GenerateMap(string mapType)
        {
            Random rand = new Random();

            Dictionary<string, double> tileProbabilities;

            switch (mapType)
            {
                case "Волшебный Лес":
                    tileProbabilities = new Dictionary<string, double>
            {
                { "Grass", 0.85 },    // 85% травы
                { "Bush", 0.10 },     // 10% кустов
                { "Mushroom", 0.05 }  // 5% грибов
            };
                    break;
                case "Лунная Пустошь":
                    tileProbabilities = new Dictionary<string, double>
            {
                { "MoonSand", 0.85 },  // 85% песка
                { "MoonStone", 0.10 }, // 10% камней
                { "Cactus", 0.05 }     // 5% кактусов
            };
                    break;
                case "Пещера Вечного Мрака":
                    tileProbabilities = new Dictionary<string, double>
            {
                { "Stone", 0.85 },  // 85% камня
                { "Coal", 0.10 },   // 10% угля
                { "Crystal", 0.05 } // 5% кристаллов
            };
                    break;
                case "Город Механических Чудес":
                    tileProbabilities = new Dictionary<string, double>
            {
                { "Tile", 0.85 },   // 85% плитки
                { "Radio", 0.10 },  // 10% радиооборудования
                { "Robot", 0.05 }   // 5% роботов
            };
                    break;
                default:
                    tileProbabilities = new Dictionary<string, double>
            {
                { "Grass", 0.85 },
                { "Bush", 0.10 },
                { "Mushroom", 0.05 }
            };
                    break;
            }

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    double randomValue = rand.NextDouble(); // Генерируем число от 0 до 1
                    double cumulativeProbability = 0;

                    foreach (var tileType in tileProbabilities)
                    {
                        cumulativeProbability += tileType.Value;
                        if (randomValue <= cumulativeProbability)
                        {
                            map[i, j] = tileFactory.GetTile(tileType.Key);
                            break;
                        }
                    }
                }
            }

            panel_GameSpace.Invalidate(); // Перерисовка карты
            UpdateStatusBar();
        }

        // обработчик рисования на панель с картой
        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j]?.Draw(e.Graphics, j * tileSize, i * tileSize, tileSize);
                }
            }
        }

        // выбор карты
        private void comboBox_Maps_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_StartGame.Enabled = true;

            string selectedMap = comboBox_Maps.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedMap))
            {
                GenerateMap(selectedMap);
            }
        }

        // запуск игры
        private void button_StartGame_Click(object sender, EventArgs e)
        {
            if (comboBox_CreatedCharacters.SelectedItem == null)
            {
                MessageBox.Show("Выберите существующего персонажа или создайте нового.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прерываем выполнение метода, если персонаж не выбран
            }

            selectedCharacter = comboBox_CreatedCharacters.SelectedItem.ToString();

            KeyDown += MainForm_KeyDown;
            KeyPreview = true; // Позволяет форме перехватывать события клавиш

            button_StartGame.Enabled = false;
            button_Reset.Enabled = true;
            comboBox_Maps.Enabled = false;
            comboBox_CreatedCharacters.Enabled = false;
            panel_CreateNewCharacter.Enabled = false;
            

            if (!string.IsNullOrEmpty(selectedCharacter))
            {
                // Находим персонажа по имени
                UnsharedCharacter character = characters.FirstOrDefault(c => c.CharacterName == selectedCharacter);

                // Получаем общие характеристики из фабрики (по имени)
                sharedCharacter = characterFactory.GetSharedCharacter(character.skinKey);

                if (character != null)
                {
                    // Находим свободные координаты при старте игры
                    (x_curr, y_curr) = FindFreeCoordinates();

                    character.AddToTrajectory(x_curr, y_curr);

                    using (Graphics g = panel_GameSpace.CreateGraphics())
                    {
                        // Отрисовка персонажа в его координатах
                        sharedCharacter.Operation(g, x_curr, y_curr);
                        character.Operation(g, x_curr, y_curr);
                    }
                }
            }
        }

        // скины возможные (выбор при создании персонажа)
        private void comboBox_CharacterSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCharacterSkin = comboBox_CharacterSkins.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedCharacterSkin))
            {
                ShowSelectedCharacterSkin(selectedCharacterSkin);
            }
        }


        // показ выбранного скина персонажа
        private void ShowSelectedCharacterSkin(string nameRUS)
        {
            switch (nameRUS)
            {
                case "Медведь":
                    nameENG = "bear";
                    break;
                case "Капибара":
                    nameENG = "capybara";
                    break;
                case "Горилла":
                    nameENG = "gorilla";
                    break;
                case "Рыцарь":
                    nameENG = "knight";
                    break;
                case "Священик":
                    nameENG = "priest";
                    break;
                case "Маг":
                    nameENG = "wizard";
                    break;
                default:
                    nameENG = "knight";
                    break;
            }

            // Используем фабрику для создания скина заранее (даже если он не будет использоваться потом, он может использоваться тут)
            //sharedCharacter = characterFactory.GetSharedCharacter(nameENG);

            skinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Character", $"{nameENG}.png");
            skinView = Image.FromFile(skinPath);

            panel_ViewSelectedCharacterSkin.BackgroundImage = skinView;
            panel_ViewSelectedCharacterSkin.BackgroundImageLayout = ImageLayout.Stretch;

            UpdateStatusBar();
        }

        // создание персонажа
        private void button_CreateCharacter_Click(object sender, EventArgs e)
        {
            if (comboBox_CharacterSkins.SelectedItem == null)
            {
                MessageBox.Show("Выберите скин для персонажа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прерываем выполнение метода, если персонаж не выбран
            }

            characterName = textBox_NewCharacterName.Text;

            if (string.IsNullOrWhiteSpace(characterName))
            {
                MessageBox.Show("Имя персонажа не может быть пустым.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка уникальности имени персонажа
            if (characters.Any(c => c.CharacterName == characterName))
            {
                MessageBox.Show("Персонаж с таким именем уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаём уникальную часть персонажа (ник персонажа)
            UnsharedCharacter unsharedCharacter = new UnsharedCharacter(characterName, nameENG);
            characters.Add(unsharedCharacter);

            comboBox_CreatedCharacters.Items.Add(characterName);

            UpdateStatusBar();
        }

        // поиск свободных координат для начального размещения персонажа 
        private (int, int) FindFreeCoordinates()
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(0, mapSize);
                int y = random.Next(0, mapSize);

                // Проверяем, что клетка не занята объектами или персонажами
                bool isFree = map[y, x] is GrassTile || map[y, x] is MoonSandTile || map[y, x] is StoneTile || map[y, x] is TileTile;

                if (isFree)
                {
                    return (x, y);
                }
            }
        }

        // сброс
        private void button_Reset_Click(object sender, EventArgs e)
        {
            KeyDown -= MainForm_KeyDown;
            KeyPreview = false; // Позволяет форме перехватывать события клавиш

            comboBox_Maps.Enabled = true;
            panel_CreateNewCharacter.Enabled = true;
            comboBox_CreatedCharacters.Enabled = true;
            button_StartGame.Enabled = true;
            panel_GameSpace.Invalidate();


            var character = characters.FirstOrDefault(c => c.CharacterName == selectedCharacter);
            if (character is UnsharedCharacter unsharedCharacter)
            {
                unsharedCharacter.ClearTrajectory();
            }

            UpdateStatusBar();
        }
    }



    // --------------------------------------------------------------------------------------------------------------------------
    // ** Приспособленец - для Текстур **
    abstract class Tile
    {
        protected Image image;

        public abstract void Draw(Graphics g, int x, int y, int size);
    }

    // FOREST
    class GrassTile : Tile
    {
        public GrassTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Forest", "grass.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class BushTile : Tile
    {
        public BushTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Forest", "bush.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class MushroomTile : Tile
    {
        public MushroomTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Forest", "mushroom.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }
    // FOREST

    // DESERT
    class MoonSandTile : Tile
    {
        public MoonSandTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Desert", "moon_sand.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class MoonStoneTile : Tile
    {
        public MoonStoneTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Desert", "moon_stone.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class CactusTile : Tile
    {
        public CactusTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Desert", "cactus.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }
    // DESERT

    // CAVE
    class StoneTile : Tile
    {
        public StoneTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cave", "stone.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class CoalTile : Tile
    {
        public CoalTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cave", "coal.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class CrystalTile : Tile
    {
        public CrystalTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cave", "crystal.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }
    // CAVE

    // CITY
    class TileTile : Tile
    {
        public TileTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "City", "tile.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class RadioTile : Tile
    {
        public RadioTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "City", "radio.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }

    class RobotTile : Tile
    {
        public RobotTile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "City", "robot.png");
            image = Image.FromFile(path);
        }

        public override void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawImage(image, x, y, size, size);
        }
    }
    // CITY

    class TileFactory
    {
        private Dictionary<string, Tile> tiles = new Dictionary<string, Tile>();

        public Tile GetTile(string key)
        {
            if (!tiles.ContainsKey(key))
            {
                switch (key)
                {
                    case "Grass":
                        tiles[key] = new GrassTile();
                        break;
                    case "Bush":
                        tiles[key] = new BushTile();
                        break;
                    case "Mushroom":
                        tiles[key] = new MushroomTile();
                        break;
                    case "MoonSand":
                        tiles[key] = new MoonSandTile();
                        break;
                    case "MoonStone":
                        tiles[key] = new MoonStoneTile();
                        break;
                    case "Cactus":
                        tiles[key] = new CactusTile();
                        break;
                    case "Stone":
                        tiles[key] = new StoneTile();
                        break;
                    case "Coal":
                        tiles[key] = new CoalTile();
                        break;
                    case "Crystal":
                        tiles[key] = new CrystalTile();
                        break;
                    case "Robot":
                        tiles[key] = new RobotTile();
                        break;
                    case "Radio":
                        tiles[key] = new RadioTile();
                        break;
                    case "Tile":
                        tiles[key] = new TileTile();
                        break;
                }
            }
            return tiles[key];
        }
    }



    // ---------------------------------------------------------------------------------------------------------------------



    // *******************************************************************************************************
    // ** Приспособленец - для Персонажей **
    class CharacterFactory
    {
        private Dictionary<string, SharedCharacter> sharedCharacters = new Dictionary<string, SharedCharacter>();

        public SharedCharacter GetSharedCharacter(string key)
        {
            if (!sharedCharacters.ContainsKey(key))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Character", $"{key}.png");
                Image skin = Image.FromFile(path);
                sharedCharacters[key] = new SharedCharacter(skin);
            }
            return sharedCharacters[key];
        }
    }

    abstract class Character
    {
        abstract public void Operation(Graphics g ,int x, int y);
    }

    // **Разделяемая часть**
    class SharedCharacter : Character
    {
        private Image skin;

        public SharedCharacter(Image skin)
        {
            this.skin = skin;
        }

        public override void Operation(Graphics g, int x, int y)
        {
            if (skin != null)
            {
                g.DrawImage(skin, x * 32, y * 32, 32, 32); // Отрисовка скина персонажа
            }
        }
    }

    // **Неразделяемая часть**
    class UnsharedCharacter : Character
    {
        public string CharacterName { get; }
        public string skinKey;
        private List<Point> trajectory = new List<Point>();

        public UnsharedCharacter(string name, string skinKey)
        {
            CharacterName = name;
            this.skinKey = skinKey;
        }

        public void AddToTrajectory(int x, int y)
        {
            trajectory.Add(new Point(x, y));
            if (trajectory.Count > 10) // Ограничиваем длину следа
                trajectory.RemoveAt(0);
        }

        public void ClearTrajectory()
        {
            trajectory.Clear();
        }


        public override void Operation(Graphics g, int x, int y)
        {
            // Отрисовка траектории
            using (Pen pen = new Pen(Color.Brown, 2)) // Цвет пути
            {
                for (int i = 1; i < trajectory.Count; i++)
                {
                    g.DrawLine(pen,
                        trajectory[i - 1].X * 32 + 16, trajectory[i - 1].Y * 32 + 16,
                        trajectory[i].X * 32 + 16, trajectory[i].Y * 32 + 16);
                }
            }
        }
    }
    // *******************************************************************************************************

}
