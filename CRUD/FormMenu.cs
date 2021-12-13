using Crud.Domain;
using Crud.Infra;
using Ninject;
using Ninject.Parameters;
using System;

using System.Windows.Forms;

namespace CRUD
{
    public partial class FormMenu : Form 
    {
      
        public bool KeyDetalhes = true;

        private IRepositorio Repositorio{ get; set; }
        Usuario usuario = new Usuario();

        [Inject()]
        public FormMenu(IRepositorio repositorio)
        {
            InitializeComponent();
            Repositorio = repositorio; 
        }
        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var param = new ConstructorArgument("usuario", new Usuario()); 
            FormCadastro frmC = FormResolve.Resolve<FormCadastro>(param);
            frmC.KeyEdit = true;

            if (frmC.ShowDialog()== DialogResult.OK)
            {
                    DGV_List.DataSource = null;
                    DGV_List.DataSource = listUsuarios.Instance.ListagemCliente;
            }
        }
        private void Deletar_Click(object sender, EventArgs e)
        {
            if ((DGV_List.CurrentRow) == null)
            {
                MessageBox.Show("Selecione um item para excluir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Deseja excluir o item selecionado", "Confirmação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) )
            {
                var Contador = DGV_List.CurrentRow.Index;
                Repositorio.Delete(Contador);
                DGV_List.DataSource = null;
                DGV_List.DataSource = listUsuarios.Instance.ListagemCliente;
            }
        }        
        private void detalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((DGV_List.CurrentRow) == null)
            {
                MessageBox.Show("Selecione um item para editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            var param = new ConstructorArgument("usuario", new Usuario
            {
            IdCliente = Convert.ToInt32(DGV_List.CurrentRow.Cells[0].Value),
            NomeCliente = DGV_List.CurrentRow.Cells[1].Value.ToString(),
            IdadeCliente = DGV_List.CurrentRow.Cells[2].Value.ToString()
            });
            FormCadastro frmE = FormResolve.Resolve<FormCadastro>(param);
            KeyDetalhes = false;
            frmE.KeyEdit = false;

            if (frmE.ShowDialog() == DialogResult.OK)
             {
                DGV_List.DataSource = null;
                DGV_List.DataSource = listUsuarios.Instance.ListagemCliente;
            }       
        }
        private void BSair_Menu_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja Sair do Menu? ", "Confirmação", MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                Close();
            }
        } 
    }
}