using Crud.Domain;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace CRUD
{
    public partial class FormCadastro : Form
    {
        private IRepositorio Repositorio { get; set; }
        DadosUsuario dadosUsuario = new DadosUsuario();
        int id;
        string nome;
        string idade;
        
        public FormCadastro(IRepositorio repositorio, DadosUsuario usuario)
        {
            dadosUsuario = usuario;
            Repositorio = repositorio;

            InitializeComponent();

        }
        public bool KeyEdit;
        private void BtLimpar_Click(object sender, EventArgs e)
        {
            TbNome.Text = string.Empty;
            TbIdade.Text = string.Empty;
        }
        private void BtRetornar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtSalvar_Click(object sender, EventArgs e)
        {

            if (TbNome.Text.Trim().Equals(string.Empty))
            {                
                MessageBox.Show("Você deve informa o nome. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (TbIdade.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Você deve informa o Idade. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           else if (TbNome.Text.Where(c => char.IsNumber(c)).Count() > 0)
            {
                MessageBox.Show("Nome com caractere invalida. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (TbIdade.Text.Where(c => char.IsLetter(c)).Count() > 0)
            {
                MessageBox.Show("Idade invalida verifique se contem somente conjunto numérico. ", this.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }           
            if (KeyEdit == true)
            {
                dadosUsuario.NomeClientes = TbNome.Text;
                dadosUsuario.IdadeClientes = TbIdade.Text;
                Repositorio.Adicionar(dadosUsuario);
                DialogResult = DialogResult.OK;
            }
            else if (KeyEdit == false)
            {              
                    int idProcura = id;

                dadosUsuario.IdadeClientes = TbIdade.Text;
                dadosUsuario.NomeClientes = TbNome.Text;
                dadosUsuario.IdClientes = id;

                Repositorio.Update(dadosUsuario);
                DialogResult = DialogResult.OK;
                }
            }
        private void FormCadastro_Load(object sender, EventArgs e)
        {
             id = dadosUsuario.IdClientes;
             
            if (dadosUsuario.NomeClientes != String.Empty)
            {
                TbNome.Text = dadosUsuario.NomeClientes;
                TbIdade.Text = dadosUsuario.IdadeClientes;
            }
        }
    }       
    }
      