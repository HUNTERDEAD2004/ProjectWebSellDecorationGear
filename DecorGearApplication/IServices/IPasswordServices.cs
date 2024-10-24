using Application.DataTransferObj.User.Request;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Password;
using DecorGearDomain.Enum;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.IServices
{
    public interface IPasswordServices
    {

        Task<ResponseDto<ErrorMessage>> ForgotPassword(ForgotPassword request, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> ResetPassword(ResetPassword request, CancellationToken cancellationToken);

    }
}   
