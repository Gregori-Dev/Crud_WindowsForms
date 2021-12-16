namespace Crud.Domain
{
    public interface IRepositorio
    {
        void Adicionar(DadosUsuario dadosUsuario);
        void Delete(DadosUsuario dadosUsuario);
        void Update(DadosUsuario dadosUsuario, int idProcura);

        object ExibirTodos(DadosUsuario dadosUsuario);

    }
}
