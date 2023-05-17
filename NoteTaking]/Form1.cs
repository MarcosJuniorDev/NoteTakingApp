using System.Data;

namespace NoteTaking_
{
    public partial class noteTaker : Form
    {
        public DataTable Notes { get; set; } = new DataTable();
        public bool Editing { get; set; } = false;



        public noteTaker()
        {
            InitializeComponent();
        }

        private void noteTaker_Load(object sender, EventArgs e)
        {
            Notes.Columns.Add("Title");
            Notes.Columns.Add("Note");

            previusNote.DataSource = Notes;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (Editing)
            {
                Notes.Rows[previusNote.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                Notes.Rows[previusNote.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                Notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            Editing = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = Notes.Rows[previusNote.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = Notes.Rows[previusNote.CurrentCell.RowIndex].ItemArray[1].ToString();
            Editing = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Notes.Rows[previusNote.CurrentCell.RowIndex] == null)
                {
                    Console.WriteLine("Nota invalida");
                }
                else
                {
                    Notes.Rows[previusNote.CurrentCell.RowIndex].Delete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nota não valida {ex.Message}");
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        /*private void previusNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Notes.Columns.Contains())
            {
                title.Text = Notes.Rows[previusNote.CurrentCell.RowIndex].ItemArray[0].ToString();
                note.Text = Notes.Rows[previusNote.CurrentCell.RowIndex].ItemArray[1].ToString();
                Editing = true;
            }
            else
            {
                throw new Exception("Row invalida");
            }
            
        }*/
    }
}