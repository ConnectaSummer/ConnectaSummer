using ConnectaSummer.Application.Users.Requests;
using ConnectaSummer.Application.Users.Responses;
using ConnectaSummer.Domain.Users;
using Data.UnityOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetByIdAsync(request.UserId);
            user.ReleaseRemove ();

            if (user.HasErrors)
            {
                DeleteUserResponse response = new DeleteUserResponse
                {
                    Erros = user.Errors,
                    Message = "error for create",
                    StatusCode = 400
                };
                return response;
            }
            else
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    await _repository.SaveAsync(user);
                    _unitOfWork.Commit();
                    DeleteUserResponse response = new DeleteUserResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    DeleteUserResponse response = new DeleteUserResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return await Task.FromResult(response);
                }
            }
        }
    }
}
