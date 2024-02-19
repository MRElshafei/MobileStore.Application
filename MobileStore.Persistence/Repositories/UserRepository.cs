using Application.Enums;
using Application.Features.Login;
using Application.Features.Register;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MobileStore.Application.Auth.JWT_Auth;
using MobileStore.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;



namespace MobileStore.Persistence.Repositories
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        private readonly StoreDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JWT _jWT;

        public UserRepository(StoreDbContext context, IHttpContextAccessor contextAccessor, JWT jWT)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _jWT = jWT;
        }

        public async Task<string> LoginAsync(UserLogin userLogin)
        {
            // Check if user exists by email to retrieve hashed password
            var user = _context.RoleAssignments
                .Include(o => o.User)
                .FirstOrDefault(o => o.User.Email == userLogin.Email);

            if (user == null)
            {
                throw new ArgumentException("Invalid email or password. User not found.");
            }

            // Compare hashed password stored in the database with the password entered by the user
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.User.Password);

            if (!passwordMatches)
            {
                throw new ArgumentException("Invalid email or password. Password does not match.");
            }

            // Create JWT claims for authentication
            var claims = new List<Claim>
                {
                    new Claim(JWTClaims.Id, user.User.ID.ToString()),
                    new Claim(JWTClaims.FirstName, user.User.FirstName),
                    new Claim(JWTClaims.LastName, user.User.LastName),
                    new Claim(JWTClaims.Role, (user.RoleId == (int)RoleEnum.Admin?"Admin":"User").ToString())
                };

            var _jwt = new JWT
            {
                secretKey = "zaIV0No5+jWtTtV6usTFeuZ418kiPXPz4posiRGOCq0=",
                issuer = "SecureApi",
                audience = "SecureApiUser",
                Enable = true,
                expiryMinutes = 60 

            };
            

            if (_jwt == null || string.IsNullOrEmpty(_jwt.secretKey))
            {
                throw new ArgumentException("JWT configuration is invalid.");
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.secretKey));
            // Create JWT token
            var jwtSecurityToken = await JWTHandler.CreateJwtToken(claims, _jwt);
            var userToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return userToken;
        }



        public async Task<string> RegisterAsync(NewUser newUser)
        {
            // Validate input
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User information is required.");
            }

            if (string.IsNullOrWhiteSpace(newUser.Email) || newUser.Email.Contains(" ") || string.IsNullOrWhiteSpace(newUser.Password) || newUser.Password.Contains(" "))
            {
                throw new ArgumentException("Email and password are required. (Check spaces)");
            }
            


            // Check if user already exists
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                throw new WebException("A user with this email already exists.");
            }
            //Create User
            User user = new User();
            user.Address = newUser.Address;
            user.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            user.PhoneNumber = newUser.PhoneNumber;
            user.Email = newUser.Email;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;


            _context.Users.Add(user);

            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Adding New User");
            }

            //Assign User Role
            RoleAssignment roleAssignment = new RoleAssignment();
            var NewUser = _context.Users.FirstOrDefault(u => u.Email == newUser.Email);
            if (NewUser is  null)
            {
                throw new WebException("Error while Adding New User");

            }
            roleAssignment.UserId = NewUser.ID;
            roleAssignment.RoleId = (int)RoleEnum.User;

            _context.RoleAssignments.Add(roleAssignment);

            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Assign User Role");
            }

            return $"Your Account {user.FirstName} {user.LastName} is Created Successfully";
        }
    }
}
