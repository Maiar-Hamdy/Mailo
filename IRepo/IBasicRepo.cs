using System.Collections.Generic;
namespace Mailo.IRepo
{
	public interface IBasicRepo<T> where T : class
	{
		//IEnumerable<T> FindAll();
		Task<List<T>> GetAll();
		Task<T> GetByID(int id);
		void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
	}
}
