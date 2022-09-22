using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WinDataGridView
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      MontaGrid();
    }

    private void MontaGrid()
    {
      List<string> list = new List<string>();
      list.Add("Samuel");
      list.Add("Leonardo");
      list.Add("Luma");
      list.Add("Fernanda");

      var display = list.Select(x => new
      {
        Nome = x.ToString()
      }).ToList();
      dataGridView1.DataSource = display;

    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        e.SuppressKeyPress = true;

    }

    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      var i = dataGridView1.CurrentRow.Index;
      textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();

    }
  }
}