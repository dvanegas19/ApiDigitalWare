using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Interface.Repository
{
    /// <summary>
    /// interface to manage the Client
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     29/03/2021   Creation
    /// </history>
    public interface IClient
    {
        /// <summary>
        /// Get all Clients
        /// </summary>
        /// <returns><list><see cref="Entity.Client"/></list></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     29/03/2021   Creation
        /// </history>
        Task<Entity.Result<IEnumerable<Entity.Client>>> Get();

        Task<Entity.Result<int>> Insert(Entity.Client client);

        Task<Entity.Result<int>> Update(Entity.Client client);
    }
}
