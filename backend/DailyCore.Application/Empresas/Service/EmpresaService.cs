

using DailyCore.Application.Empresas.DTOs;
using DailyCore.Application.Empresas.Interfaces;
using DailyCore.Domain.Entities;


namespace DailyCore.Application.Empresas.Service
{
    public class EmpresaService
    {

        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<CrearEmpresaResponse> CrearEmpresaAsync ( CrearEmpresaRequest request)
        {
           var empresa = new Empresa(request.Nombre);

            await _empresaRepository.GuardarAsync(empresa);


            return new CrearEmpresaResponse
            {
                Id = empresa.Id,
                Nombre = empresa.Nombre,
                CreatedAt = empresa.CreatedAt
            };
           
        }


    }
}
