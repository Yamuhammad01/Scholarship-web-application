using Microsoft.EntityFrameworkCore;
using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IBiodataRepository _profileRepository;
       
       
        public ProfileService(IBiodataRepository profileRepository)
        {
            _profileRepository = profileRepository;
            
        }
        public async Task AddStudentBiodataAsync(BiodataDTO biodataDto)
        {
            var biodata = new Biodata
            {
                Surname = biodataDto.Surname,
                Firstname = biodataDto.Firstname,
                Othernames = biodataDto.Othernames,
                Email = biodataDto.Email,
                Gender = biodataDto.Gender,
                AcademicLevel = biodataDto.AcademicLevel,
                DateOfBirth = biodataDto.DateOfBirth,
                StateofOrigin = biodataDto.StateofOrigin,
                LGA = biodataDto.LGA,
                ParmanentAddress = biodataDto.ParmanentAddress,
                PostalAddress = biodataDto.PostalAddress,
                PhoneNumber = biodataDto.PhoneNumber,
                MaritalStatus = biodataDto.MaritalStatus,
                PhysicallyChallenged = biodataDto.PhysicallyChallenged
            };
            await _profileRepository.AddBiodataAsync(biodata);
        }
        public async Task UpdateBiodataAsync(int id, BiodataDTO biodatadto)
        {
            var biodata = await _profileRepository.GetBiodataByIdAsync(id);

            if (biodata == null)
                throw new KeyNotFoundException($"Biodata with ID {id} not found.");
        

            // Map fields from DTO to entity
            biodata.Surname = biodatadto.Surname;
            biodata.Firstname = biodatadto.Firstname;
            biodata.Othernames = biodatadto.Othernames;
            biodata.Gender = biodatadto.Gender;
            biodata.AcademicLevel = biodatadto.AcademicLevel;
            biodata.DateOfBirth = biodatadto.DateOfBirth;
            biodata.StateofOrigin = biodatadto.StateofOrigin;
            biodata.LGA = biodatadto.LGA;
            biodata.ParmanentAddress = biodatadto.ParmanentAddress;
            biodata.PostalAddress = biodatadto.PostalAddress;
            biodata.PhoneNumber = biodatadto.PhoneNumber;
            biodata.MaritalStatus = biodatadto.MaritalStatus;
            biodata.PhysicallyChallenged = biodatadto.PhysicallyChallenged;

            // Update the entity
            await _profileRepository.UpdateBiodataAsync(id, biodata);

            // Save changes
            await _profileRepository.SaveChangesAsync();

        }
        public async Task<Registration> GetUserByEmailAsync(string email)
        {
            return await _profileRepository.GetUserByEmailAsync(email);
        }

        public async Task<BiodataDTO> GetBiodataaByIdAsync(int id)
        {
            var biodataDto = await _profileRepository.GetBiodataaByIdAsync(id);
            if (biodataDto == null)
                return null;

            return new BiodataDTO
            {
                Surname = biodataDto.Surname,
                Firstname = biodataDto.Firstname,
                Othernames = biodataDto.Othernames,
                Email = biodataDto.Email,
                Gender = biodataDto.Gender,
                AcademicLevel = biodataDto.AcademicLevel,
                DateOfBirth = biodataDto.DateOfBirth,
                StateofOrigin = biodataDto.StateofOrigin,
                LGA = biodataDto.LGA,
                ParmanentAddress = biodataDto.ParmanentAddress,
                PostalAddress = biodataDto.PostalAddress,
                PhoneNumber = biodataDto.PhoneNumber,
                MaritalStatus = biodataDto.MaritalStatus,
                PhysicallyChallenged = biodataDto.PhysicallyChallenged
            };
        }
        public async Task AddAcademicInfoAsync(AcademicLevelDTO academicLevelDTO)
        {
            var result = new AcademicLevel
            {
                Institution = academicLevelDTO.Institution,
                InsitutionAddress = academicLevelDTO.InsitutionAddress,
                Department = academicLevelDTO.Department,
                Qualification = academicLevelDTO.Qualification,
                Course = academicLevelDTO.Course,
                YearOfAdmission = academicLevelDTO.YearOfAdmission,
                CategoryOfStudy = academicLevelDTO.CategoryOfStudy,
                CurrentLevel = academicLevelDTO.CurrentLevel,
                CGPA = academicLevelDTO.CGPA
            };
            await _profileRepository.AddAcademicInfo(result);
        }
        public async Task UpdateAcademicInfoAsync(int id, AcademicLevelDTO academicLevelDTO)
        {
            var result = await _profileRepository.GetAcademicInfoByIdAsync(id);

            if (result == null)
                throw new KeyNotFoundException($"Not found.");


            // Map fields from DTO to entity
            result.Institution = academicLevelDTO.Institution;
            result.Institution = academicLevelDTO.Institution;
            result.InsitutionAddress = academicLevelDTO.InsitutionAddress;
            result.Department = academicLevelDTO.Department;
            result.Qualification = academicLevelDTO.Qualification;
            result.Course = academicLevelDTO.Course;
            result.YearOfAdmission = academicLevelDTO.YearOfAdmission;
            result.CategoryOfStudy = academicLevelDTO.CategoryOfStudy;
            result.CurrentLevel = academicLevelDTO.CurrentLevel;
            result.CGPA = academicLevelDTO.CGPA;
          
                
            // Update the entity-
            await _profileRepository.UpdateAcademicInfoAsync(id, result);

            // Save changes
            await _profileRepository.SaveChangesAsync();

        }

    }

    
}