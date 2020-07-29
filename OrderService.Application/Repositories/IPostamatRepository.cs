using OrderService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PostamatService.Application.Repositories
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
        Postamat Create(Postamat newPostamat);

        /// <summary>
        /// Update postamat.
        /// </summary>
        Postamat Update(Postamat updatedPostamat);

        /// <summary>
        /// Cancell postamat.
        /// </summary>
        Postamat Cancell(int postamatId);

        /// <summary>
        /// Get postamat by ID asynchronously. 
        /// </summary>
        Task<Postamat> GetAsync(int postamatId, CancellationToken token);

        /// <summary>
        /// Create new postamat asynchronously.
        /// </summary>
        Task<Postamat> CreateAsync(Postamat newPostamat, CancellationToken token);

        /// <summary>
        /// Update postamat asynchronously.
        /// </summary>
        Task<Postamat> UpdateAsync(Postamat updatedPostamat, CancellationToken token);

        /// <summary>
        /// Cancell postamat asynchronously.
        /// </summary>
        Task<Postamat> CancellAsync(int postamatId, CancellationToken token);
    }
}
