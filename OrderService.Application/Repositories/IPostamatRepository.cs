using OrderService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Repositories
{
    /// <summary>
    /// Repository to work with postamats.
    /// </summary>
    public interface IPostamatRepository
    {
        /// <summary>
        /// Get postamat by ID. 
        /// </summary>
        Postamat Get(int postamatId);

        /// <summary>
        /// Create new postamat.
        /// </summary>
        Postamat Add(Postamat newPostamat);

        /// <summary>
        /// Update postamat.
        /// </summary>
        Postamat Update(Postamat updatedPostamat);

        /// <summary>
        /// Remove postamat.
        /// </summary>
        Postamat Remove(int postamatId);

        /// <summary>
        /// Get postamat by ID asynchronously. 
        /// </summary>
        Task<Postamat> GetAsync(int postamatId, CancellationToken token);

        /// <summary>
        /// Create new postamat asynchronously.
        /// </summary>
        Task<Postamat> AddAsync(Postamat newPostamat, CancellationToken token);

        /// <summary>
        /// Update postamat asynchronously.
        /// </summary>
        Task<Postamat> UpdateAsync(Postamat updatedPostamat, CancellationToken token);

        /// <summary>
        /// Remove postamat asynchronously.
        /// </summary>
        Task<Postamat> RemoveAsync(int postamatId, CancellationToken token);
    }
}
