using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Windows.Forms;

namespace WinDataGridView
{
  public partial class Form1 : Form
  {
    string codigoSelecionado;
    int linhaSelecionada;
    bool manterFoco;
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
   //   var i = dataGridView1.CurrentRow.Index;
   //   textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();

    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      manterFoco = true;
      if (e.KeyCode == Keys.Enter)
      {
        manterFoco = false;
        MessageBox.Show ("Registro Selecionado " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
      }
      else if (e.KeyCode == Keys.Down)
      {
        dataGridView1.Focus();
        dataGridView1.ClearSelection();
        dataGridView1.CurrentRow.DataGridView.Select();
        linhaSelecionada = dataGridView1.CurrentRow.Index + 1;
        if (linhaSelecionada >= 0 && linhaSelecionada <= dataGridView1.Rows.Count - 1)
        {
          //          dataGridView1.Rows[linhaSelecionada].Selected = true;
          dataGridView1.CurrentCell = dataGridView1.Rows[linhaSelecionada].Cells[0];
        }
        else
          dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

        e.SuppressKeyPress = true;


      }
      else if (e.KeyCode == Keys.Up)
      {
        dataGridView1.Focus();
        dataGridView1.ClearSelection();
        dataGridView1.CurrentRow.DataGridView.Select();
        linhaSelecionada = dataGridView1.CurrentRow.Index - 1;

        if (linhaSelecionada >= 0)
          //          dataGridView1.Rows[linhaSelecionada].Selected = true;
          dataGridView1.CurrentCell = dataGridView1.Rows[linhaSelecionada].Cells[0];
        else
          dataGridView1.Rows[0].Selected = true;

        e.SuppressKeyPress = true;


      }
    }

    private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (manterFoco)
        e.Cancel = true;
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
      linhaSelecionada = dataGridView1.CurrentRow.Index;

    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      manterFoco = false;
    }
  }
}