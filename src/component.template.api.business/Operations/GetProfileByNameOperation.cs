using AutoMapper;
using component.template.api.domain.Common;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.External;
using component.template.api.domain.Models.Repository;

namespace component.template.api.business.Operations;

public class GetProfileByNameOperation : BaseOperation<GetProfileByNameRequest, GetProfileByNameResponse?>
{
    public override void ConfigureMappings(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<ProfileDto, GetProfileByNameResponse>();
    }

    public override async Task ValidateAsync(GetProfileByNameRequest input)
    {
        if (string.IsNullOrWhiteSpace(input?.Name))
            throw new ArgumentException("ProfileName cannot be null or empty", nameof(input.Name));
        
        await Task.CompletedTask;
    }

    public override async Task<GetProfileByNameResponse?> RunAsync(GetProfileByNameRequest input)
    {
        var unitOfWork = base.GetContextRepositories<IUnitOfWork>();
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var adminProfile = await unitOfWork.Profiles
                            .FindAsync(p => p.ProfileName.ToLower() == "admin");
            var adminProfileEntity = adminProfile.FirstOrDefault();

            if (adminProfileEntity == null)
            {
                // TODO: Logar erro de perfil não encontrado
                return default;
            }                    
            return _mapper.Map<ProfileDto, GetProfileByNameResponse>(adminProfileEntity);
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
