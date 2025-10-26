using System;
using System.Collections.Generic;
using System.Windows.Forms;
using project.Models;

namespace project.Forms
{
    public partial class BicyclesForm : Form
    {
        // Контейнер для списку велосипедів
        public List<Bicycle> listBicycles = new List<Bicycle>();

        // Об'єкт для роботи з БД
        Db db = new Db();

        public BicyclesForm()
        {
            InitializeComponent();
        }

        // Завантаження даних при старті форми
        private void BicyclesForm_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowData();
        }

        // Метод завантаження велосипедів з бази даних
        public void LoadData()
        {
            string query = "SELECT * FROM Bicycles";
            db.Execute(query, ref listBicycles, reader => new Bicycle
            {
                Id = reader.GetInt32("Id_bicycle"),
                ModelName = reader.GetString("Model_name"),
                BrandId = reader.GetInt32("Id_brand"),
                Type = reader.GetString("Type1"),
                FrameSize = reader.GetString("Frame_size"),
                FrameMaterial = reader.GetString("Frame_material"),
                GearCount = reader.GetInt32("Gear_count"),
                Price = reader.GetDecimal("Price"),
                StockQuantity = reader.GetInt32("Stock_quantity")
            });
        }

        // Відображення даних на інтерфейсі
        public void ShowData()
        {
            dgvBicycles.Rows.Clear();
            foreach (var bike in listBicycles)
            {
                dgvBicycles.Rows.Add(
                    bike.Id,
                    bike.ModelName,
                    bike.BrandId,
                    bike.Type,
                    bike.FrameSize,
                    bike.FrameMaterial,
                    bike.GearCount,
                    bike.Price,
                    bike.StockQuantity
                );
            }
        }

        // Перевірка введених даних
        public bool CheckDataBicycle()
        {
            if (tbModel.Text.Trim() == "")
            {
                MessageBox.Show("Поле 'Модель' є обов'язковим.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbBrandId.Text.Trim() == "")
            {
                MessageBox.Show("Поле 'ID бренду' є обов'язковим.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Додавання нового велосипеда до бази
        public void SaveDataToDB()
        {
            if (CheckDataBicycle())
            {
                Bicycle bike = new Bicycle
                {
                    ModelName = tbModel.Text.Trim(),
                    BrandId = int.Parse(tbBrandId.Text.Trim()),
                    Type = tbType.Text.Trim(),
                    FrameSize = tbFrameSize.Text.Trim(),
                    FrameMaterial = tbFrameMaterial.Text.Trim(),
                    GearCount = int.Parse(tbGearCount.Text.Trim()),
                    Price = decimal.Parse(tbPrice.Text.Trim()),
                    StockQuantity = int.Parse(tbStock.Text.Trim())
                };

                string query = $"INSERT INTO Bicycles " +
                               $"(Model_name, Id_brand, Type1, Frame_size, Frame_material, Gear_count, Price, Stock_quantity) " +
                               $"VALUES ('{bike.ModelName}', {bike.BrandId}, '{bike.Type}', '{bike.FrameSize}', '{bike.FrameMaterial}', {bike.GearCount}, {bike.Price}, {bike.StockQuantity})";

                db.ExecuteNonQuery(query);
                listBicycles.Add(bike);
                ShowData();
            }
        }

        // Кнопка "Додати"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveDataToDB();
        }
    }
}
