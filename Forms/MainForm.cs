using System;
using System.Collections.Generic;
using System.Windows.Forms;
using project.Models;

namespace project.Forms
{
    public partial class BicyclesForm : Form
    {
        public List<Bicycle> listBicycles = new List<Bicycle>();
        Db db = new Db();
        public BicyclesForm()
        {
            InitializeComponent();
        }

        private void BicyclesForm_Load(object sender, EventArgs e)
        {
            dgvBicycles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBicycles.MultiSelect = false;
            dgvBicycles.ReadOnly = true; 

            LoadData();
            ShowData();
        }

        public void LoadData()
        {
            string query = "SELECT * FROM Bicycles";
            db.Execute(query, ref listBicycles, reader => new Bicycle
            {
                Id_bicycle = reader.GetInt32("Id_bicycle"),
                Model_name = reader.GetString("Model_name"),
                Id_brand = reader.GetInt32("Id_brand"),
                Type1 = reader.GetString("Type1"),
                Frame_size = reader.GetString("Frame_size"),
                Frame_material = reader.GetString("Frame_material"),
                Gear_count = reader.GetInt32("Gear_count"),
                Price = reader.GetDecimal("Price"),
                Stock_quantity = reader.GetInt32("Stock_quantity"),
                Brand = new Brand()
                {
                    Id_brand = reader.GetInt32("Id_brand"),
                    Brand_name = "",
                    Country = ""
                }
            });
        }

        public void ShowData()
        {
            dgvBicycles.Rows.Clear();
            foreach (var bike in listBicycles)
            {
                dgvBicycles.Rows.Add
                (
                    bike.Id_bicycle,
                    bike.Model_name,
                    bike.Id_brand,
                    bike.Price,
                    bike.Stock_quantity
                );
            }
        }

        public bool CheckData()
        {
            if (tbModel.Text.Trim() == "")
            {
                MessageBox.Show("Вкажіть модель!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbBrandId.Text.Trim() == "")
            {
                MessageBox.Show("Вкажіть ID бренду!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbPrice.Text.Trim() == "")
            {
                MessageBox.Show("Вкажіть ціну!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbStock.Text.Trim() == "")
            {
                MessageBox.Show("Вкажіть кількість!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void SaveDataToDB()
        {
            if (!CheckData()) return;

            decimal price = decimal.Parse
            (
                tbPrice.Text.Trim().Replace(',', '.'),
                System.Globalization.CultureInfo.InvariantCulture
            );

            Bicycle bike = new Bicycle
            {
                Model_name = tbModel.Text.Trim(),
                Id_brand = int.Parse(tbBrandId.Text.Trim()),
                Type1 = "Гірський",
                Frame_size = "M",
                Frame_material = "Алюміній",
                Gear_count = 18,
                Price = price,
                Stock_quantity = int.Parse(tbStock.Text.Trim()),
                Brand = new Brand()
                {
                    Id_brand = int.Parse(tbBrandId.Text.Trim()),
                    Brand_name = "",
                    Country = ""
                }
            };

            string query = $"INSERT INTO Bicycles " + "(Model_name, Id_brand, Type1, Frame_size, Frame_material, Gear_count, Price, Stock_quantity) " +
                        $"VALUES ('{bike.Model_name}', {bike.Id_brand}, '{bike.Type1}', '{bike.Frame_size}', '{bike.Frame_material}', {bike.Gear_count}, {bike.Price}, {bike.Stock_quantity})";

            db.ExecuteNonQuery(query);
            LoadData();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveDataToDB();
        }

        public int GetSelectedId()
        {
            if (dgvBicycles.CurrentRow == null)
            {
                MessageBox.Show("Виберіть рядок!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            return Convert.ToInt32(dgvBicycles.CurrentRow.Cells["Id_bicycle"].Value);
        }

        private void dgvBicycles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            tbModel.Text = dgvBicycles.Rows[e.RowIndex].Cells["Model_name"].Value.ToString();
            tbBrandId.Text = dgvBicycles.Rows[e.RowIndex].Cells["Id_brand"].Value.ToString();
            tbPrice.Text = dgvBicycles.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            tbStock.Text = dgvBicycles.Rows[e.RowIndex].Cells["Stock_quantity"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            var confirm = MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            string query = $"DELETE FROM Bicycles WHERE Id_bicycle = {id}";
            db.ExecuteNonQuery(query);

            LoadData();
            ShowData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;
            if (!CheckData()) return;

            decimal price = decimal.Parse
            (
                tbPrice.Text.Trim().Replace(',', '.'),
                System.Globalization.CultureInfo.InvariantCulture
            );

            string query = $"UPDATE Bicycles SET " +
                           $"Model_name = '{tbModel.Text.Trim()}', " +
                           $"Id_brand = {tbBrandId.Text.Trim()}, " +
                           $"Type1 = 'Гірський', " +
                           $"Frame_size = 'M', " +
                           $"Frame_material = 'Алюміній', " +
                           $"Gear_count = 18, " +
                           $"Price = {price}, " +
                           $"Stock_quantity = {tbStock.Text.Trim()} " +
                           $"WHERE Id_bicycle = {id}";

            db.ExecuteNonQuery(query);

            LoadData();
            ShowData();
        }
    }
}
