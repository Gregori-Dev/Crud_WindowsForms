using Crud.Domain;
using Crud.Infra;
using Ninject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUD
{
    public partial class FormCadastro : Form
    {
        private  IRepositorio Repositorio;
        string Nome, Idade;
        int Id;

        Usuario Usuario = new Usuario();
          [Inject()]
        public FormCadastro(IRepositorio repositorio)
        {
            this.Repositorio = repositorio;
            InitializeComponent();
            
          //  Nome = nome;
            //Idade = idade;
           // Id = idCliente;

            Usuario.NomeCliente = Nome;
            Usuario.IdadeCliente = Idade;   
            
            if (this.Nome != String.Empty)
            {
                TbNome.Text = Nome;
                TbIdade.Text = Idade;
            }
        }
        public FormCadastro()
        {
            InitializeComponent();
        }
        public bool KeyEdit = true ;
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
                var ultimoId = listUsuarios.Instance.ListagemCliente.Count == 0
                 ? 0
                 : listUsuarios.Instance.ListagemCliente.Max(x => x.IdCliente);
                Usuario.IdCliente = ultimoId +1;
                Usuario.NomeCliente = TbNome.Text;
                Usuario.IdadeCliente = TbIdade.Text;
                Repositorio.Adicionar(Usuario);
                DialogResult = DialogResult.OK;
            }
            else if (KeyEdit == false)
            {              
                    int idProcura = Id;

                Usuario.IdadeCliente = TbIdade.Text;
                Usuario.NomeCliente = TbNome.Text;
                Usuario.IdCliente = Id;

                Repositorio.Update(Usuario, idProcura);
                DialogResult = DialogResult.OK;
                }
            }                    
        }       
    }
      