using ECOMMERECE.helper;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.DTO;
using Store.Services.interfaces;
using Store.Services.middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.services
{
    public class userServices : IUserService
    {
        private readonly Iuser _user;
        private readonly IImages _images;
        public userServices(Iuser user,IImages images)
        {
            _user = user;
            _images = images;
        }
        public async  Task deleteUserAsync(string id)
        {
            var user = await _user.getUserByIdAsync(id);
            _images.removeImage(user.imageID);
            await _user.deleteUserAsync(id);
        }

        public async Task<IReadOnlyList<UserSignUpDto>> getUsersAsync()
        {
            var users = await _user.getAllUserAsync();
            var mappedUsers =  users.Select(x => new UserSignUpDto()
            {
                Email = x.Email,
                firstName = x.firstName,
                lastName = x.lastName,
                userName = x.firstName + x.lastName,
                userImageID = x.image?.ID,
                userImageUrl = x.image?.path,
                mobilePhone = x.PhoneNumber,
            }).ToList();
            return mappedUsers;
        }

        public async Task<UserSignUpDto> getUserById(string id)
        {
            var user = await _user.getUserByIdAsync(id);
            UserSignUpDto mappedSignUp = new UserSignUpDto()
            {
                Email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                userName = user.firstName + user.lastName,
                userImageID = user.image?.ID,
                userImageUrl = user.image?.path,
                mobilePhone = user.PhoneNumber,
            };
            return mappedSignUp;
        }

        public async Task register(UserSignUpDto userDTO,string role)
        {
            if (userDTO.formImages is not null)
            {
                var path = documentSetting.uploadFile(userDTO.formImages, "images");
                var imageToBeAdded = ImageUploadMiddleware.imageUpload(path, _images);
                ApplicationUser user = new ApplicationUser()
                {
                    firstName = userDTO.firstName,
                    lastName = userDTO.lastName,
                    PhoneNumber = userDTO.mobilePhone,
                    address = userDTO.address,
                    Email = userDTO.Email,
                    UserName = userDTO.Email.Split('@')[0],
                    imageID = imageToBeAdded.ID
                };
                await _user.register(user, userDTO.password,role);
            }
            else
            {
                ApplicationUser user = new ApplicationUser()
                {
                    firstName = userDTO.firstName,
                    lastName = userDTO.lastName,
                    PhoneNumber = userDTO.mobilePhone,
                    address = userDTO.address,
                    Email = userDTO.Email,
                    UserName = userDTO.Email.Split('@')[0]
                };
                await _user.register(user, userDTO.password,role);
            }

        }
        public async Task<bool> signIn(UserSignInDto userDTO)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = userDTO.Email,
            };
            if (await _user.signIn(user,userDTO.password))
            {
                return true;
            }
            return false;
        }
    }
}
