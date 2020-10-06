using System.Linq;
using System.Threading.Tasks;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Data
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatorHandler mediator, VendasContext context)
        {
            var domainEntities = context.ChangeTracker.Entries<Entity>().Where(cd => cd.Entity.Notificacoes != null && cd.Entity.Notificacoes.Any()).ToList();

            var domainEvents = domainEntities.SelectMany(cd => cd.Entity.Notificacoes).ToList();

            domainEntities.ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents.Select(async (domainEvent) => await mediator.PublicarEvento(domainEvent));

            await Task.WhenAll(tasks);
        }
    }
}