using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{ 
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IFindeksService _findeksService;
        IFindeksDal _findeksDal;
        ICustomerDal _customerDal;
        public UserManager(IUserDal userDal, IFindeksService findeksService, IFindeksDal findeksDal, ICustomerDal customerDal)
        {
            _userDal = userDal;
            _findeksService = findeksService;
            _findeksDal = findeksDal;
            _customerDal = customerDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("user.delete,moderator,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("user.update,moderator,admin")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [SecuredOperation("user.get,moderator,admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [SecuredOperation("user.get,moderator,admin")]
        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=> u.Id == Id));
        }

        public IDataResult<UserDetailDto> GetUserDetailDtoByUserId(int id)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailByUserId(id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Email == email));
        }

        [SecuredOperation("user")]
        public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var user = GetById(userDetailForUpdate.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash,
                user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

            user.FirstName = userDetailForUpdate.FirstName;
            user.LastName = userDetailForUpdate.LastName;
            if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userDal.Update(user);

            var customer = _customerDal.Get(c => c.Id == userDetailForUpdate.CustomerId);
            customer.CompanyName = userDetailForUpdate.CompanyName;
            _customerDal.Update(customer);

            if (!string.IsNullOrEmpty(userDetailForUpdate.NationalIdentity))
            {
                var findeks = _findeksService.GetByCustomerId(userDetailForUpdate.CustomerId).Data;
                if (findeks == null)
                {
                    var newFindeks = new Findeks
                    {
                        CustomerId = userDetailForUpdate.CustomerId,
                        NationalIdentity = userDetailForUpdate.NationalIdentity
                    };
                    _findeksService.Add(newFindeks);
                }
                else
                {
                    findeks.NationalIdentity = userDetailForUpdate.NationalIdentity;
                    var newFindeks = _findeksService.CalculateFindeksScore(findeks).Data;
                    _findeksDal.Update(newFindeks);
                }
            }

            return new SuccessResult(Messages.UserDetailsUpdated);
        }
    }
}
