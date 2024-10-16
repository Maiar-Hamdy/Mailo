using Mailo.Models;

namespace Mailo.IRepo
{
	public interface IUnitOfWork : IDisposable
	{
        public IBasicRepo<User> users { get; }
        public IBasicRepo<Employee> employees { get; }
        public IBasicRepo<Order> orders { get; }
        public IBasicRepo<Productss> products { get; }
        public IBasicRepo<Wishlist> wishlists { get; }
        public IBasicRepo<Review> reviews { get; }

        public IBasicRepo<Payment> payments { get; }
        int CommitChanges();

	}
}
