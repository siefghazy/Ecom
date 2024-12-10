using Store.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface IUserService
    {
        public Task<IReadOnlyList<UserSignUpDto>> getUsersAsync();
        public Task<UserSignUpDto> getUserById(string id);
        public Task deleteUserAsync(string id);
        public Task<bool> signIn(UserSignInDto userDTO);
        public Task register(UserSignUpDto userDTO,string role);
    }
}
