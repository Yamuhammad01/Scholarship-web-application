using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using AutoMapper;

namespace Scholarship.Application.Services
{
    public class RegistrationService : IStudentService
    {
        private readonly IStudentRepository _repository;
       // private readonly IMapper _mapper;

        public RegistrationService(IStudentRepository repository)
        {
            _repository = repository;
            
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllStudentsAsync()
        {
           
            var students = await _repository.GetAllAsync();
   
            return students.Select(s => new RegistrationDTO { FullName = s.FullName, Email = s.Email, 
                PhoneNumber = s.PhoneNumber, Gender = s.Gender, DateOfBirth = s.DateOfBirth});
        }

        public async Task<GetStudentDto> GetStudentByIdAsync(int id, string userId)
        {
            var student = await _repository.GetByIdAsync(id, userId);
            if (student == null)
                return null;

            return new GetStudentDto
            {
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Gender = student.Gender
            };
        }

        public async Task AddStudentAsync(Registration student)
        {
            await _repository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(int id, RegistrationDTO studentDto, string userId)
        {
            var student = await _repository.GetByIdAsync(id, userId);
           if (student == null)
                throw new UnauthorizedAccessException("Access denied");

            student.FullName = studentDto.FullName;
            student.Email = studentDto.Email;
            student.PhoneNumber = studentDto.PhoneNumber;
            student.Gender = studentDto.Gender;
            student.DateOfBirth = studentDto.DateOfBirth;
            await _repository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id, string userId)
        {
            await _repository.DeleteAsync(id, userId);
        }
    }
}
