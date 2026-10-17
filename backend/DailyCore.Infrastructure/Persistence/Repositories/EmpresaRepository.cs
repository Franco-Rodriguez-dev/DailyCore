

using DailyCore.Application.Empresas.Interfaces;
using DailyCore.Domain.Entities;

namespace DailyCore.Infrastructure.Persistence.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DailyCoreDbContext _context;

        public EmpresaRepository(DailyCoreDbContext context)
        {
            _context = context;
        }

        public async Task GuardarAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();


        }



    }
}
