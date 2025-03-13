using Business.Abstracts;
using DataAccess;
using Dto.Request;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Business.Concretes
{
    public class PostService : IPostService
    {
        SocialMediaContext _socialMediaContext;
        public PostService(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
        public void Add(PostAddRequestDto dto)
        {
            try
            {
                if (dto.auth.role!= ERole.USER)
                {
                    throw new Exception(Messages.UnauthorizedAccess);
                }
            }
            //ToDo
            catch (Exception ex)
            {

            }
            
            _socialMediaContext.Add(dto);
        }
    }
}
