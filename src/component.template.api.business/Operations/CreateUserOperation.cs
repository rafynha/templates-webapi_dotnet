using AutoMapper;
using component.template.api.domain.Common;
using component.template.api.domain.Exceptions;
using component.template.api.domain.Helpers;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.External;
using component.template.api.domain.Models.Repository;

namespace component.template.api.business.Operations;

public class CreateUserOperation : BaseOperation<CreateUserRequest, CreateUserResponse>
{
    public override void ConfigureMappings(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<CreateUserRequest, UserDto>();
    }

    public override async Task ValidateAsync(CreateUserRequest input)
    {
        if (string.IsNullOrWhiteSpace(input.Email))
            throw new RequiredFieldException("O email não pode ser vazio.", nameof(input.Email));

        if (!EmailHelper.IsValidEmail(input.Email))
            throw new InvalidFieldException("O email fornecido não é válido.", nameof(input.Email));

        if (string.IsNullOrWhiteSpace(input.Password))
            throw new RequiredFieldException("A senha não pode ser vazia.", nameof(input.Password));

        await Task.CompletedTask;
    }

    public override async Task<CreateUserResponse> RunAsync(CreateUserRequest input)
    {
        var unitOfWork = base.GetContextRepositories<IUnitOfWork>();
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var user = _mapper.Map<CreateUserRequest, UserDto>(input);
            
            user.PasswordHash = PasswordHelper.HashPassword(input.Password); // Gera o hash da senha
            // Verifica se o usuário já existe pelo e-mail
            var existingUser = await unitOfWork.Users
                .FindAsync(u => u.Email == user.Email);

            if (existingUser.Any())
            {
                throw new InvalidOperationException("Já existe um usuário com este e-mail.");
            }
            
            await unitOfWork.Users.AddAsync(user); // Adiciona o novo usuário
            await unitOfWork.CommitAsync(); // Commit inicial para gerar o ID do usuário

            await SetAdminProfile(unitOfWork, user);

            await unitOfWork.CommitTransactionAsync(); // Commit das alterações e encerramento da transação

            return await Task.FromResult(new CreateUserResponse(){ IdUser = user.UserId});
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }        
    }

    #region Private Methods
        private async Task SetAdminProfile(IUnitOfWork unitOfWork, UserDto user)
        {
            var adminProfileEntity = await GetAdminProfile(unitOfWork); // Busca o perfil Admin
            await AssociateProfile(unitOfWork, user.UserId, adminProfileEntity.ProfileId); // Associa o usuário ao perfil Admin
        }
    
        private async Task<GetProfileByNameResponse> GetAdminProfile(IUnitOfWork unitOfWork)
        {
            /* Call Service example */
            var resultService = await base.GetContextService<IProfileBusiness>()
                .GetByName(new(){ Name = "admin" }); 

            if (resultService == null)
                throw new InvalidOperationException("O perfil Admin não foi encontrado no sistema.");
                
            return resultService;
        }
    
        private async Task AssociateProfile(IUnitOfWork unitOfWork, long userId, int profileId)
        {
            var userProfile = new UserProfileDto()
            {
                UserId = userId,
                ProfileId = profileId
            };
    
            await unitOfWork.UserProfiles.AddAsync(userProfile);
        }
    #endregion
}
