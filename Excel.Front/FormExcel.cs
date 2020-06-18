using Excel.Front.Enums;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Excel.Front
{
    public partial class FormExcel : Form
    {
        private readonly string Path = (new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory).Directory.Parent.Parent.Parent.FullName);

        public FormExcel()
        {
            try
            {
                InitializeComponent();
                LoadComboDisplayType();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro. Favor entrar em contato com o administrador");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetOperations();
            ShowButtonsExport(true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var filter = new { DisplayType = cboDisplayType.SelectedValue, FileType = FileType.Excel };
            var result = Post("operation/file", filter);

            if (result != null)
            {
                MessageBox.Show("Excel gerado com sucesso. O arquivo será aberto automaticamente.");
                Process.Start($"{Path}/Relatorios/operations.xlsx");
            }
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {
            var filter = new { DisplayType = cboDisplayType.SelectedValue, FileType = FileType.Csv };
            var result = Post("operation/file", filter);

            if (result != null)
            {
                MessageBox.Show("Csv gerado com sucesso. O arquivo será aberto automaticamente.");
                Process.Start($"{Path}/Relatorios/operations.csv");
            }
        }

        private void btnGenerateData_Click(object sender, EventArgs e)
        {
            var result = Post("operation/data", null);

            if (result != null)
            {
                MessageBox.Show("Massa de dados gerado com sucesso!");
                ShowButtonsExport(false);
            }
        }

        private void ShowButtonsExport(bool visible)
        {
            btnCsv.Visible = visible;
            btnExcel.Visible = visible;
        }

        private object Post(string route, object filter)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/api/");

                var serializedFilter = JsonConvert.SerializeObject(filter);

                var content = new StringContent(serializedFilter, Encoding.UTF8, "application/json");

                var result = client.PostAsync(route, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var operations = JsonConvert.DeserializeObject(readTask);
                    return operations ?? String.Empty;
                }
                else
                {
                    ShowErrorMessages(route);
                }

                return null;
            }
        }

        private void ShowErrorMessages(string route)
        {
            if (route.Equals("operation/file"))
                MessageBox.Show("O arquivo Excel/CSV está em uso. Favor fechar para prosseguir com a geração de um novo relatório.");
            else
                MessageBox.Show("Falha ao consultar API. Favor entrar em contato com o administrador.");
        }

        private void LoadComboDisplayType()
        {
            cboDisplayType.DisplayMember = "Text";
            cboDisplayType.ValueMember = "Value";

            var cboItems = new[] {
                    new {Text = "Todos" , Value = 4},
                    new {Text = "Agrupado por Cliente" , Value = 1},
                    new {Text = "Agrupado por Ativo" , Value = 2},
                    new {Text = "Agrupado por Tipo" , Value = 3},
            };

            cboDisplayType.DataSource = cboItems;
        }

        private void GetOperations()
        {
            var filter = new { DisplayType = cboDisplayType.SelectedValue };

            var operations = Post("operation", filter);

            if (operations != null)
            {
                gdvOperations.Columns.Clear();
                gdvOperations.DataSource = operations;
                ConfigGridView();

                if (!cboDisplayType.SelectedValue.Equals(4))
                {
                    HiddenColumnsGridView();
                }
            }
        }

        private void HiddenColumnsGridView()
        {
            gdvOperations.Columns["Id"].Visible = false;
            gdvOperations.Columns["InclusionDate"].Visible = false;

            if (cboDisplayType.SelectedValue.Equals((int)DisplayType.GroupByAccount))
            {
                gdvOperations.Columns["Type"].Visible = false;
                gdvOperations.Columns["AssetName"].Visible = false;
                gdvOperations.Columns["Account"].DisplayIndex = 0;
                return;
            }

            if (cboDisplayType.SelectedValue.Equals((int)DisplayType.GroupByAsset))
            {
                gdvOperations.Columns["Type"].Visible = false;
                gdvOperations.Columns["Account"].Visible = false;
                return;
            }

            gdvOperations.Columns["Account"].Visible = false;
            gdvOperations.Columns["AssetName"].Visible = false;
        }

        private void ConfigGridView()
        {
            gdvOperations.Columns["Id"].HeaderText = "Id";
            gdvOperations.Columns["InclusionDate"].HeaderText = "Data";
            gdvOperations.Columns["Type"].HeaderText = "Tipo";
            gdvOperations.Columns["AssetName"].HeaderText = "Ativo";
            gdvOperations.Columns["Account"].HeaderText = "Conta";
            gdvOperations.Columns["Price"].HeaderText = "Preço";
            gdvOperations.Columns["Quantity"].HeaderText = "Quantidade";
        }
    }
}
