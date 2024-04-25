using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dtos;
public class RegisterDto
{
    public UserForRegisterDto  User { get; set; }
    // ... diğer verilecek kayıt bilgileri
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfilePicture { get; set; }

    
}
