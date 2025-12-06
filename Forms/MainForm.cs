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

            LoadBrands();
            LoadData();
            ShowData();
        }

        //завантаження з бази
        public void LoadData()
        {
            string query = @"
                SELECT b.*, br.Brand_name, br.Country 
                FROM Bicycles b
                LEFT JOIN Brands br ON b.Id_brand = br.Id_brand";

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
                Brand = new Brand
                {
                    Id_brand = reader.GetInt32("Id_brand"),
                    Brand_name = reader.GetString("Brand_name"),
                    Country = reader.GetString("Country")
                }
            });
        }

        //завантаження в комбобокс
        private void LoadBrands()
        {
            cbBrandFilter.Items.Clear();
            cbBrandFilter.Items.Add(new ComboBoxItem("Всі", 0));

            string query = "SELECT Id_brand, Brand_name, Country FROM Brands";
            var brands = new List<Brand>();
            db.Execute(query, ref brands, reader => new Brand
            {
                Id_brand = reader.GetInt32("Id_brand"),
                Brand_name = reader.GetString("Brand_name"),
                Country = reader.GetString("Country")
            });

            foreach (var brand in brands) cbBrandFilter.Items.Add(new ComboBoxItem(brand.Brand_name, brand.Id_brand));
            cbBrandFilter.SelectedIndex = 0;
        }

        //відображення в датагрід
        public void ShowData()
        {
            dgvBicycles.Rows.Clear();
            int displayId = 1;

            int selectedBrandId = 0;
            if (cbBrandFilter.SelectedItem is ComboBoxItem item) selectedBrandId = item.Value;

            string searchModel = tbSearchModel.Text.Trim().ToLower();

            foreach (var bike in listBicycles)
            {
                bool matchesModel = string.IsNullOrEmpty(searchModel) || bike.Model_name.ToLower().Contains(searchModel);
                bool matchesBrand = selectedBrandId == 0 || bike.Id_brand == selectedBrandId;

                if (matchesModel && matchesBrand)
                {
                    dgvBicycles.Rows.Add(
                        displayId,
                        bike.Model_name,
                        bike.Id_brand,
                        bike.Price,
                        bike.Stock_quantity,
                        bike.Type1,
                        bike.Frame_size,
                        bike.Frame_material,
                        bike.Gear_count,
                        bike.Id_bicycle
                    );
                    displayId++;
                }
            }
        }

        //перевірка заповнення
        public bool CheckData()
        {
            if (string.IsNullOrWhiteSpace(tbModel.Text))
            {
                MessageBox.Show("Вкажіть модель!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbBrandId.Text))
            {
                MessageBox.Show("Вкажіть ID бренду!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                MessageBox.Show("Вкажіть ціну!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbStock.Text))
            {
                MessageBox.Show("Вкажіть кількість!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //додавання нового велосипеда
        public void SaveDataToDB()
        {
            if (!CheckData()) return;

            decimal price = decimal.Parse(tbPrice.Text.Trim().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

            int brandId = int.Parse(tbBrandId.Text.Trim());
            string brandName = "Unknown";
            string brandCountry = "Unknown";

            if (cbBrandFilter.SelectedItem is ComboBoxItem selectedBrand && selectedBrand.Value != 0)
            {
                brandId = selectedBrand.Value;
                brandName = selectedBrand.Text;
            }

            Bicycle bike = new Bicycle
            {
                Model_name = tbModel.Text.Trim(),
                Id_brand = brandId,
                Type1 = tbType.Text.Trim(),
                Frame_size = tbFrameSize.Text.Trim(),
                Frame_material = tbFrameMaterial.Text.Trim(),
                Gear_count = int.Parse(tbGearCount.Text.Trim()),
                Price = price,
                Stock_quantity = int.Parse(tbStock.Text.Trim()),
                Brand = new Brand
                {
                    Id_brand = brandId,
                    Brand_name = brandName,
                    Country = brandCountry
                }
            };

            string query = $"INSERT INTO Bicycles (Model_name, Id_brand, Type1, Frame_size, Frame_material, Gear_count, Price, Stock_quantity) " +
                           $"VALUES ('{bike.Model_name}', {bike.Id_brand}, '{bike.Type1}', '{bike.Frame_size}', '{bike.Frame_material}', {bike.Gear_count}, {bike.Price}, {bike.Stock_quantity})";

            db.ExecuteNonQuery(query);
            LoadData();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e) => SaveDataToDB();

        public int GetSelectedRealId()
        {
            var currentRow = dgvBicycles.CurrentRow;
            if (currentRow == null || currentRow.Cells["RealId"].Value == null)
            {
                MessageBox.Show("Виберіть рядок!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return Convert.ToInt32(currentRow.Cells["RealId"].Value);
        }

        private void dgvBicycles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            tbModel.Text = dgvBicycles.Rows[e.RowIndex].Cells["Model_name"].Value.ToString();
            tbBrandId.Text = dgvBicycles.Rows[e.RowIndex].Cells["Id_brand"].Value.ToString();
            tbPrice.Text = dgvBicycles.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            tbStock.Text = dgvBicycles.Rows[e.RowIndex].Cells["Stock_quantity"].Value.ToString();
            tbType.Text = dgvBicycles.Rows[e.RowIndex].Cells["Type1"].Value.ToString();
            tbFrameSize.Text = dgvBicycles.Rows[e.RowIndex].Cells["Frame_size"].Value.ToString();
            tbFrameMaterial.Text = dgvBicycles.Rows[e.RowIndex].Cells["Frame_material"].Value.ToString();
            tbGearCount.Text = dgvBicycles.Rows[e.RowIndex].Cells["Gear_count"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedRealId();
            if (id == -1) return;

            if (MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM Bicycles WHERE Id_bicycle = {id}";
            db.ExecuteNonQuery(query);

            LoadData();
            ShowData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedRealId();
            if (id == -1 || !CheckData()) return;

            decimal price = decimal.Parse(tbPrice.Text.Trim().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

            string query = $"UPDATE Bicycles SET " +
                           $"Model_name = '{tbModel.Text.Trim()}', " +
                           $"Id_brand = {tbBrandId.Text.Trim()}, " +
                           $"Type1 = '{tbType.Text.Trim()}', " +
                           $"Frame_size = '{tbFrameSize.Text.Trim()}', " +
                           $"Frame_material = '{tbFrameMaterial.Text.Trim()}', " +
                           $"Gear_count = {tbGearCount.Text.Trim()}, " +
                           $"Price = {price}, " +
                           $"Stock_quantity = {tbStock.Text.Trim()} " +
                           $"WHERE Id_bicycle = {id}";

            db.ExecuteNonQuery(query);
            LoadData();
            ShowData();
        }

        private void FilterChanged(object sender, EventArgs e) => ShowData();
        private void tbSearchModel_TextChanged(object sender, EventArgs e) => ShowData();

        //комбобокс
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString() => Text;
        }
        private void BtnImportCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string[] lines = System.IO.File.ReadAllLines(ofd.FileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 8) continue;

                    string model = parts[0].Trim();
                    int brandId = int.Parse(parts[1].Trim());
                    string type = parts[2].Trim();
                    string frameSize = parts[3].Trim();
                    string frameMaterial = parts[4].Trim();
                    int gearCount = int.Parse(parts[5].Trim());
                    decimal price = decimal.Parse(parts[6].Trim(), System.Globalization.CultureInfo.InvariantCulture);
                    int stock = int.Parse(parts[7].Trim());

                    string query = $"INSERT INTO Bicycles (Model_name, Id_brand, Type1, Frame_size, Frame_material, Gear_count, Price, Stock_quantity) " +
                                   $"VALUES ('{model}', {brandId}, '{type}', '{frameSize}', '{frameMaterial}', {gearCount}, {price}, {stock})";

                    db.ExecuteNonQuery(query);
                }

                LoadData();
                ShowData();
                MessageBox.Show("Імпорт CSV завершено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
