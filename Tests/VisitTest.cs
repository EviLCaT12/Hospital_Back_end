using System.Xml.Linq;
using Xunit;
using domain.UseCases;
using domain.Logic;
using domain.Models;
using Moq;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class VisitTest
    {
        private readonly VisitUseCases _visitUseCases;
        private readonly Mock<IVisitRepository> _visitRepositoryMock;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
        public VisitTest()
        {
            _visitRepositoryMock = new Mock<IVisitRepository>();
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _visitUseCases = new VisitUseCases(_visitRepositoryMock.Object, _doctorRepositoryMock.Object);
        }

        [Fact]
        public void VisitIsntExist_ShouldTrue()
        {
            _visitRepositoryMock.Setup(repository => repository.IsVisitExist(It.IsAny<Visit>())).Returns(() => false);

            var res = _visitUseCases.IsVisitExist(new Visit());
            Assert.True(res.IsFailure);
            Assert.Equal("Visit not found", res.Error);
        }

        [Fact]
        public void NonCorrectTimeForVisit_ShouldFail()
        {
            var visit = new Visit();
            var res = _visitUseCases.CreateVisit(visit);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid input data:Non correct visit`s time", res.Error);
        }

        [Fact]
        public void TryCreateVisit_ShouldTrue()
        {
            _visitRepositoryMock.Setup(repo => repo.Create(It.IsAny<Visit>())).Returns(() => true);

            var visit = new Visit(0, DateTime.MinValue, DateTime.MaxValue, 1, 1);
            var res = _visitUseCases.CreateVisit(visit);
            Assert.True(res.Success);
        }

        [Fact]
        public void GetAllFreeSpec_ShouldOk()
        {
            var res = _visitUseCases.GetAllFreeSpec(new Specialization());
            Assert.True(res.Success);
        }

        [Fact]
        public void GetAllFreeDoctor_ShouldOk()
        {
            _doctorRepositoryMock.Setup(repo => repo.IsDoctorExist(It.IsAny<int>())).Returns(() => true);
            var res = _visitUseCases.GetAllFreeDoctor(new Doctor());
            Assert.True(res.Success);
        }
    }
}
