using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Repository
{
    /// <summary>
    /// Interface para rotinas de crud a serem executadas
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public interface ICRUD<T> where T:class
    {
        void Add(T item);

        void Delete(Guid id);

        void Update(Guid id, T item);

        //Retorna os itens baseados no id do usuário
        T GetItem(Guid id);

        //Um array de itens de usuários
        List<T> GetItens();

    }
}
