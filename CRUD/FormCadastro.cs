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
        private IRepositorio Repositorio { get; set; }
        Usuario _Usuario = new Usuario();
        int id;
        string nome;
        string idade;
        
        public FormCadastro(IRepositorio repositorio, Usuario usuario)
        {
            _Usuario = usuario;
            Repositorio = repositorio;

            InitializeComponent();

            if (nome != String.Empty)
            {
                TbNome.Text = nome;
                TbIdade.Text = idade;
            }
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
                var ultimoId = listUsuarios.Instance.ListagemCliente.Count == 0
                 ? 0
                 : listUsuarios.Instance.ListagemCliente.Max(x => x.IdCliente);
                _Usuario.IdCliente = ultimoId +1;
                _Usuario.NomeCliente = TbNome.Text;
                _Usuario.IdadeCliente = TbIdade.Text;
                Repositorio.Adicionar(_Usuario);
                DialogResult = DialogResult.OK;
            }
            else if (KeyEdit == false)
            {              
                    int idProcura = id;

                _Usuario.IdadeCliente = TbIdade.Text;
                _Usuario.NomeCliente = TbNome.Text;
                _Usuario.IdCliente = id;

                Repositorio.Update(_Usuario, idProcura);
                DialogResult = DialogResult.OK;
                }
            }
        private void FormCadastro_Load(object sender, EventArgs e)
        {
             id = _Usuario.IdCliente;
             nome = _Usuario.NomeCliente;
             idade = _Usuario.IdadeCliente;
            if (nome != String.Empty)
            {
                TbNome.Text = nome;
                TbIdade.Text = idade;
            }
        }
    }       
    }
      