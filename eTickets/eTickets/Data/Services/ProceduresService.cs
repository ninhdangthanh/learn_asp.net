using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ProceduresService:EntityBaseRepository<Producer>, IProceduresService
    {
        public ProceduresService(AppDbContext context) : base(context) { }
    }
}
