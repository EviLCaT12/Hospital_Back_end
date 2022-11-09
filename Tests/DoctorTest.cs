using System.Xml.Linq;
using Xunit;
using domain.UseCases;
using domain.Logic;
using domain.Models;
using Moq;
using System.Collections.Generic;

namespace Tests
{
    public class DoctorTest
    {
        private readonly DoctorUseCases _doctorUseCases;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

        public DoctorTest()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _doctorUseCases = new DoctorUseCases(_doctorRepositoryMock.Object);
        }

        [Fact]
        public void FullNameIsEmpty_ShoildFail()
        {
            var doctor = new Doctor(1,"", new Specialization(0, "asd"));
            var res = _doctorUseCases.CreateDoctor(doctor);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid input data:Non correct name", res.Error);
        }

        [Fact]

        public void DoctorIsNotFound_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.GetDoctorById(It.IsAny<int>()))
    .Returns(() => null);

            var res = _doctorUseCases.GetDoctorById(1);

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor not found", res.Error);
        }

        [Fact]
        public void GetAllDoctors_SholdTrue()
        {
            List<Doctor> doctors = new()
            {
                new Doctor(0, "qwreqwr", new Specialization(0, "qeqwe")),
                new Doctor(1, "zxc", new Specialization(0, "zxczxc"))
            };
            IEnumerable<Doctor> d = doctors;
            _doctorRepositoryMock.Setup(repository => repository.GetAllDoctors()).Returns(() => d);

            var result = _doctorUseCases.GetAllDoctors();

            Assert.True(result.Success);
        }

        [Fact]
        public void CreateDoctor_SholdTrue()
        {
            _doctorRepositoryMock.Setup(repository => repository.CreateDoctor(It.IsAny<Doctor>()))
                .Returns(() => true);
            var doctor = new Doctor(0,"qwecrqwr", new Specialization(1,"asexdas"));
            var res = _doctorUseCases.CreateDoctor(doctor);

            Assert.True(res.Success);
        }

        [Fact]
        public void DeleteNoExistDoctor_SholdFail()
        {
            var doctor = new Doctor(0, "qwecr", new Specialization(1,"123"));
            var res = _doctorUseCases.DeleteDoctor(0);

            Assert.True(res.IsFailure);
            Assert.Equal("There is no such doctor", res.Error);
        }

        [Fact]

        public void ErrorWhileDeleting_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.GetDoctorById(It.IsAny<int>())).Returns(() => new Doctor(0, "cwercqwe", new Specialization(0, "a")));
            _doctorRepositoryMock.Setup(repository => repository.DeleteDoctor(It.IsAny<int>())).Returns(() => false);

            var res = _doctorUseCases.DeleteDoctor(0);

            Assert.True(res.IsFailure);
            Assert.Equal("Error while deleting.Try again later", res.Error);
        }

        [Fact]
        public void GetDoctorByNotCorrectSpec_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.GetDoctorBySpecialization(It.IsAny<Specialization>())).Returns(() => null);

            var result = _doctorUseCases.GetDoctorBySpecialization(new Specialization(0, "cqwecrqwe"));

            Assert.True(result.IsFailure);
            Assert.Equal("Doctor  not found", result.Error);
        }
    }
}
