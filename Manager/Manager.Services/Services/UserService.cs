using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Manager.Services.DTO;

using Manager.Services.Interfaces;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using AutoMapper;
using Manager.Infra.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExistis = await _userRepository.GetByEmail(userDTO.Email);

            if (userExistis != null)
            {
                throw new DomainException("There is already a registered user with the registered email!");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);

        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExistis = await _userRepository.Get(userDTO.Id);

            if (userExistis == null)
            {
                throw new DomainException("There is no user with id informed!");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }
        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }
        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }
    }
}