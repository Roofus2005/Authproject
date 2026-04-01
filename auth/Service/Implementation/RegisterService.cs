using auth.Dtos;
using auth.Entity;
using auth.Repository.Implementation;
using auth.Repository.Interface;
using auth.Service.Interface;

namespace auth.Service.Implementation
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _RegisterRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _userRoleRepository;

        public RegisterService(IRegisterRepository repository, IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository)
        {
            _RegisterRepository = repository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _userRoleRepository = userRoleRepository;   
        }

        public async Task<BaseResponse<RegisterDto?>> CreateAsync(CreateRegisterModel model)
        {
            try
            {
                if (model == null)
                {
                    return new BaseResponse<RegisterDto?>
                    {
                        Status = false,
                        Message = "THE REQUEST IS NULL ",
                        Data = null,
                    };
                }

                var existingUser = await _userRepository.GetAsync(a => a.Email == model.Email);
                if (existingUser != null)
                {
                    return new BaseResponse<RegisterDto?>
                    {
                        Status = false,
                        Message = "USER WITH THE EMAIL ALREADY EXISTS",
                        Data = null,
                    };
                }

                var register = new Register
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    Occupation = model.Occupation,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    Gender = model.Gender,

                };

                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                };

                var role = await _roleRepository.GetRoleAsync("User");
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    Role = role,
                    User = user
                };

                register.UserId = user.Id;
                user.RegisterId = register.Id;

                await _RegisterRepository.CreateAsync(register);
                await _userRepository.CreateAsync(user);
                await _userRoleRepository.CreateAsync(userRole);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse<RegisterDto?>
                {
                    Status = true,
                    Message = "REGISTERED SUCCESSFULLY",
                    Data = new RegisterDto
                    {
                        Id = register.Id,
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Email = register.Email,
                        Address = register.Address,
                        DateOfBirth = register.DateOfBirth,
                        Occupation = register.Occupation,
                        PhoneNumber = register.PhoneNumber,
                        UserName = register.UserName,
                    }
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<RegisterDto?>
                {
                    Status = false,
                    Message = $"AN ERROR OCCURRED: {ex.Message}",
                    Data = null,
                };
            }
        }
    }
}
