using ESFE.ArqLimpia.EN;
using ESFE.ArqLimpia.EN.Interfaces;
using ESFE.ArqLimpia.BL.DTOs.UserDTOs;
using ESFE.ArqLimpia.BL.Interfaces;

namespace ESFE.ArqLimpia.BL
{
    public class UserBL : IUserBL
    {
        readonly IUser userDAL;
        readonly IUnitOfWork unitWork;

        public UserBL(IUser pUserDAL, IUnitOfWork pUnitWork)
        {
            userDAL = pUserDAL;
            unitWork = pUnitWork;
        }

        public async Task<CreateUserOutputDTO> Create(CreateUserInputDTO pUser)
        {
            User user = new User
            {
                Name = pUser.Name,
                Email = pUser.Email,
                Password = pUser.Password,
            };
            userDAL.Create(user);
            await unitWork.SaveChangesAsync();
            CreateUserOutputDTO userOutput = new CreateUserOutputDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };
            return userOutput;
        }

        public async Task<int> Delete(DeleteUserDTO pUser)
        {
            userDAL.Delete(new User { Id = pUser.Id });
            return await unitWork.SaveChangesAsync();
        }

        public async Task<GetByIdUserOutputDTO> GetById(GetByIdUserInputDTO pUser)
        {
            User user = await userDAL.GetById(new User { Id = pUser.Id });
            return new GetByIdUserOutputDTO
            { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<List<SearchUserOutputDTO>> Search(SearchUserInputDTO pUser)
        {
            List<User> users = await userDAL.Search(new User { Name = pUser.Name, Email = pUser.Email });
            List<SearchUserOutputDTO> list = new List<SearchUserOutputDTO>();
            users.ForEach(s => list.Add(new SearchUserOutputDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            }));
            return list;
        }

        public async Task<int> Update(UpdateUserDTO pUser)
        {
            User user = await userDAL.GetById(new User { Id = pUser.Id });
            if (user.Id == pUser.Id)
            {
                user.Name = pUser.Name;
                userDAL.Update(user);
                return await unitWork.SaveChangesAsync();
            }
            else return 0;
        }
    }
}