namespace WindowsForms
{
    public partial class Main : Form
    {
        private Form selectedForm;

        public Main()
        {
            InitializeComponent();
            ShowSeasons();
        }

        // PAGES
        private void formClear()
        {
            this.panel1.Controls.Clear();

            if (this.selectedForm != null)
                this.selectedForm.Controls.Clear();
        }

        private void ShowSeasons()
        {
            this.formClear();

            SeasonsForm seasonsForm = new SeasonsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            seasonsForm.FormBorderStyle = FormBorderStyle.None;
            this.selectedForm = seasonsForm;

            this.panel1.Controls.Add(seasonsForm);
            seasonsForm.Show();
        }

        private void ShowRegistrations()
        {
            this.formClear();

            RegistrationsForm registrationsForm = new RegistrationsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            registrationsForm.FormBorderStyle = FormBorderStyle.None;
            this.selectedForm = registrationsForm;

            this.panel1.Controls.Add(registrationsForm);
            registrationsForm.Show();
        }

        private void button_seasonpage_Click(object sender, EventArgs e)
        {
            ShowSeasons();
        }

        private void button_registrationpage_Click(object sender, EventArgs e)
        {
            ShowRegistrations();
        }
    }
}