namespace HotelSOL_APP
{
    public partial class main : Form
    {
        Controlador.MainController oMainController = new Controlador.MainController();
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oMainController.GetList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}