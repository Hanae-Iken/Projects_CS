namespace Gestion_Ecole
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataEleve.DataSource = new DAOEleve().findAll();
            DataEleve.DataSource = new DAOEleve().find(new Eleve(0, null, null, "Tanger", null));
            //string res = new DAOEleve().testfind(new Eleve(0, null, null, "Tanger", null));
            //MessageBox.Show(res);
        }

        private void b_Ajouter_Click(object sender, EventArgs e)
        {
            new DAOEleve().insert(new Eleve(0, t_nom.Text, t_prenom.Text, t_ville.Text, t_specialite.Text));
            // DataEleve.Rows.Add(0,t_nom.Text,t_prenom.Text,t_ville.Text,t_specialite.Text);
            DataEleve.DataSource = new DAOEleve().findAll();
        }

        private void b_Rechercher_Click(object sender, EventArgs e)
        {
            DataEleve.DataSource = new DAOEleve().find(new Eleve(0, t_nom.Text.Trim(), t_prenom.Text.Trim(), t_ville.Text.Trim(), t_specialite.Text.Trim()));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
