using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly
{
    public partial class Form1 : Form
    {
        private List<Player> _players = new List<Player>();
        private List<Property> _properties = new List<Property>();
        private int _currentPlayerIndex = 0;
        private const int CellCount = 24; // 6 клеток на сторону (4 стороны)
        private const int CellSize = 60; // Размер клетки
        private const int FieldSize = 400; // Размер поля

        
        public Form1()
        {
            InitializeComponent();
            
            pictureBox.Size = new Size(FieldSize, FieldSize);
            pictureBox.Location = new Point(20, 20);
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Инициализация игроков с разными стартовыми позициями
            _players.Add(new Player { Color = Color.Red, Position = 0 });
            _players.Add(new Player { Color = Color.Blue, Position = 0 });

            // Инициализация клеток
            for (int i = 0; i < CellCount; i++)
            {
                _properties.Add(new Property { GroupColor = Color.LightGray });
            }


            UpdateUI();
        }

        private void BtnRollDice_Click(object sender, EventArgs e)
        {
            Player currentPlayer = _players[_currentPlayerIndex];
            var rnd = new Random();
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            int steps = dice1 + dice2;
            int previousPosition = currentPlayer.Position;

            // Перемещение игрока
            currentPlayer.Position = (currentPlayer.Position + steps) % CellCount;
            UpdateUI();

            // Проверка на прохождение круга
            if (previousPosition + steps >= CellCount)
            {
                currentPlayer.Money += 200;
                MessageBox.Show($"Игрок {_currentPlayerIndex + 1} прошел круг! +200$");
                UpdateUI();
            }

            Property currentProperty = _properties[currentPlayer.Position];

            // Логика покупки
            if (currentProperty.OwnerId == -1)
            {
                DialogResult result = MessageBox.Show(
                    $"Купить участок за {currentProperty.Price}?",
                    $"Игрок {_currentPlayerIndex + 1}",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes && currentPlayer.Money >= currentProperty.Price)
                {
                    currentPlayer.Money -= currentProperty.Price;
                    currentProperty.OwnerId = _currentPlayerIndex;
                    currentProperty.GroupColor = currentPlayer.Color;
                    UpdateUI();

                    // Проверка на банкротство после покупки
                    if (currentPlayer.Money < 0)
                    {
                        MessageBox.Show($"Игрок {_currentPlayerIndex + 1} обанкротился!", "Конец игры");
                        this.Close();
                        return; // Прерываем выполнение
                    }
                }
            }
            else if (currentProperty.OwnerId == _currentPlayerIndex) // Новый блок улучшения
            {
                if (currentProperty.Level < 3) // Максимум 3 уровня
                {
                    DialogResult upgradeResult = MessageBox.Show(
                        $"Улучшить участок за {currentProperty.UpgradeCost}? Текущий уровень: {currentProperty.Level}\nНовая аренда: {currentProperty.Rent + currentProperty.BaseRent}",
                        "Улучшение",
                        MessageBoxButtons.YesNo
                    );

                    if (upgradeResult == DialogResult.Yes &&
                        currentPlayer.Money >= currentProperty.UpgradeCost)
                    {
                        currentPlayer.Money -= currentProperty.UpgradeCost;
                        currentProperty.Level++;
                        MessageBox.Show($"Уровень участка повышен до {currentProperty.Level}!");
                        UpdateUI();
                    }
                }
            }
            // Логика аренды
            else if (currentProperty.OwnerId != _currentPlayerIndex)
            {
                int rent = currentProperty.Rent;
                currentPlayer.Money -= rent;
                _players[currentProperty.OwnerId].Money += rent;

                MessageBox.Show(
                    $"Игрок {_currentPlayerIndex + 1} встал на чужое поле! -{rent}$",
                    "Аренда",
                    MessageBoxButtons.OK
                );
                UpdateUI();

                // Проверка на банкротство после аренды
                if (currentPlayer.Money < 0)
                {
                    MessageBox.Show($"Игрок {_currentPlayerIndex + 1} обанкротился!", "Конец игры");
                    this.Close();
                    return; // Прерываем выполнение
                }
            }

            // Переход хода (если игра не завершена)
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
            lblCurrentPlayer.Text = $"Ход игрока {_currentPlayerIndex + 1}";
        }

        private void MovePlayer(Player player, int steps)
        {
            player.Position = (player.Position + steps) % CellCount;

            Property currentProperty = _properties[player.Position];
            if (currentProperty.OwnerId == -1)
            {
                DialogResult result = MessageBox.Show(
                    "Купить участок?",
                    $"Игрок {_currentPlayerIndex + 1}",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes && player.Money >= currentProperty.Price)
                {
                    player.Money -= currentProperty.Price;
                    currentProperty.OwnerId = _currentPlayerIndex;
                    currentProperty.GroupColor = player.Color;
                }
            }
            else if (currentProperty.OwnerId != _currentPlayerIndex)
            {
                player.Money -= currentProperty.Rent;
                _players[currentProperty.OwnerId].Money += currentProperty.Rent;
            }
        }


        private void UpdateUI()
        {
            lblCurrentPlayer.Text = $"Ход игрока {_currentPlayerIndex + 1}";
            lblMoney.Text = $"Деньги: {_players[_currentPlayerIndex].Money}";
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            // Отрисовка клеток
            for (int i = 0; i < CellCount; i++)
            {
                Rectangle rect = GetCellRectangle(i);
                Color cellColor = _properties[i].OwnerId == -1
                    ? _properties[i].GroupColor
                    : _players[_properties[i].OwnerId].Color;

                g.FillRectangle(new SolidBrush(cellColor), rect);
                g.DrawRectangle(Pens.Black, rect);
            }

            // Отрисовка игроков с толстой обводкой
            foreach (var player in _players)
            {
                Rectangle rect = GetCellRectangle(player.Position);
                int offset = 8; // Увеличиваем отступ для толстой обводки
                int borderThickness = 3; // Толщина обводки

                using (Pen thickPen = new Pen(Color.Black, borderThickness))
                {
                    // Заливка фишки
                    g.FillEllipse(
                        new SolidBrush(player.Color),
                        rect.X + offset,
                        rect.Y + offset,
                        rect.Width - 2 * offset,
                        rect.Height - 2 * offset
                    );

                    // Обводка
                    g.DrawEllipse(
                        thickPen,
                        rect.X + offset,
                        rect.Y + offset,
                        rect.Width - 2 * offset,
                        rect.Height - 2 * offset
                    );
                }
            }
        }
        private Rectangle GetCellRectangle(int position)
        {
            int side = position / 6;
            int posInSide = position % 6;

            switch (side)
            {
                case 0: // Верх (слева направо)
                    return new Rectangle(20 + posInSide * CellSize, 20, CellSize, CellSize);
                case 1: // Право (сверху вниз)
                    return new Rectangle(FieldSize - CellSize - 20, 20 + posInSide * CellSize, CellSize, CellSize);
                case 2: // Низ (справа налево)
                    return new Rectangle(FieldSize - 20 - (posInSide + 1) * CellSize, FieldSize - CellSize - 20, CellSize, CellSize);
                case 3: // Лево (снизу вверх)
                    return new Rectangle(20, FieldSize - 20 - (posInSide + 1) * CellSize, CellSize, CellSize);
                default:
                    throw new ArgumentException("Недопустимая позиция");
            }
        }

    }

    public class Player
    {
        public int Money { get; set; } = 400;
        public List<int> OwnedProperties { get; } = new List<int>();
        public int Position { get; set; } = 0;
        public Color Color { get; set; }
    }

    public class Property
    {
        public int Price { get; set; } = 200;    
        public int BaseRent { get; } = 550;        
        public int Rent => BaseRent * (1 + Level); 
        public int UpgradeCost { get; } = 100;     
        public int Level { get; set; } = 0;       
        public int OwnerId { get; set; } = -1;
        public Color GroupColor { get; set; }
    }
}
