using OrderService.Database;
using OrderService.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Repositories
{
    /// <inheritdoc cref="IPostamatRepository"/>
    public class PostamatRepository : IPostamatRepository
    {
        private readonly PostamatDatabase _postamatDatabase;

        public PostamatRepository(PostamatDatabase postamatDatabase)
        {
            _postamatDatabase = postamatDatabase;
        }

        /// <inheritdoc />
        public Postamat Get(int postamatId)
        {
            return _postamatDatabase.Postamats.FirstOrDefault(p => p.Id == postamatId);
        }

        /// <inheritdoc />
        public Postamat Add(Postamat newPostamat)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public Postamat Update(Postamat updatedPostamat)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public Postamat Remove(int postamatId)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public Task<Postamat> GetAsync(int postamatId, CancellationToken token)
        {
            return Task.FromResult(Get(postamatId));
        }

        /// <inheritdoc />
        public Task<Postamat> AddAsync(Postamat newPostamat, CancellationToken token)
        {
            return Task.FromResult(Add(newPostamat));
        }

        /// <inheritdoc />
        public Task<Postamat> UpdateAsync(Postamat updatedPostamat, CancellationToken token)
        {
            return Task.FromResult(Update(updatedPostamat));
        }

        /// <inheritdoc />
        public Task<Postamat> RemoveAsync(int postamatId, CancellationToken token)
        {
            return Task.FromResult(Remove(postamatId));
        }
    }
}
