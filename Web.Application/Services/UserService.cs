using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Extensions;
using Web.Application.Models;
using Web.Application.Validation;
using Web.Domain.Entities;

namespace Web.Application.Services
{
    public class UserService(IUserDao userDao, IValidator<UserModel> validator) : IUserService
    {
        public async Task<List<UserModel>> GetAll() 
        {
            List<User> userList = await userDao.GetAll();
            return UserModel.ToList(userList);
        }

        public async Task<UserModel> GetById(int id)
        {
            User user = await userDao.GetById(id);
            return UserModel.From(user);
        }

        public async Task<UserModel> Update(int id, string firstName, string lastName, string description, string email)
        {
            UserModel request = await ValidateUser(id, firstName, lastName, description, email);

            User updatedUser = await userDao.Update(id, User.Update(id, firstName, lastName, description, email));

            return UserModel.From(updatedUser);

        }

        public async Task<UserModel> Create(string firstName, string lastName, string description, string email)
        {
            UserModel request = await ValidateUser(null, firstName, lastName, description, email);

            User user = await userDao.Insert(User.Create(request.FirstName, request.LastName, request.Description, request.Email));

            return UserModel.From(user);
        }

        public async Task Delete(int id)
        {
            await userDao.Delete(id);
        }

        private async Task<UserModel> ValidateUser(int? id, string firstName, string lastName, string description, string email) 
        {
            UserModel request = new UserModel
            {
                Id = id ?? 0,
                FirstName = firstName,
                LastName = lastName,
                Description = description,
                Email = email
            };

            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                var errors = string.Join(", ", validatorResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Invalid user data: {errors}");
            }

            return request;
        }
    }
}
