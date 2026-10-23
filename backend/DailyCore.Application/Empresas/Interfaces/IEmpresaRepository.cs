using DailyCore.Domain.Entities;


namespace DailyCore.Application.Empresas.Interfaces
{
    public interface IEmpresaRepository
    {
        Task GuardarAsync(Empresa empresa);
    }
}
