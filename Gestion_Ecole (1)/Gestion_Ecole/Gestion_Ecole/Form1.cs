namespace Gestion_Ecole
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DataEleve.SelectionChanged += DataEleve_SelectionChanged;

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

        private void b_Supprimer_Click(object sender, EventArgs e)
        {
            if (DataEleve.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(DataEleve.SelectedRows[0].Cells["id"].Value);
                int result = new DAOEleve().delete(selectedId);

                if (result > 0)
                {
                    MessageBox.Show("Élève supprimé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataEleve.DataSource = new DAOEleve().findAll();
                }
                else
                {
                    MessageBox.Show("La suppression a échoué. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un élève à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void DataEleve_SelectionChanged(object sender, EventArgs e)
        {
            if (DataEleve.SelectedRows.Count > 0)
            {
                
                int selectedId = Convert.ToInt32(DataEleve.SelectedRows[0].Cells["id"].Value);

                Eleve selectedEleve = new DAOEleve().findById(selectedId);

                if (selectedEleve != null)
                {
                    t_nom.Text = selectedEleve.Nom;
                    t_prenom.Text = selectedEleve.Prenom;
                    t_ville.Text = selectedEleve.Ville;
                    t_specialite.Text = selectedEleve.Specialite;
                }
            }
        }

        private void b_Update_Click(object sender, EventArgs e)
        {
            if (DataEleve.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(DataEleve.SelectedRows[0].Cells["id"].Value);                
                Eleve updatedEleve = new Eleve(
                    selectedId,
                    t_nom.Text.Trim(),
                    t_prenom.Text.Trim(),
                    t_ville.Text.Trim(),
                    t_specialite.Text.Trim()
                );
                int result = new DAOEleve().update(updatedEleve);

                if (result > 0)
                {
                    MessageBox.Show("Mise à jour réussie !");
                    DataEleve.DataSource = new DAOEleve().findAll(); 
                }
                else
                {
                    MessageBox.Show("Échec de la mise à jour.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un élève à modifier.");
            }
        }

    }




}

