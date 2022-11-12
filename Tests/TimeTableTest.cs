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
    public class TimeTableTest
    {
        private readonly TimeTableUseCases _TimeTableUseCases;
        private readonly Mock<ITimeTableRepository> _TimeTableRepositoryMock;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
        public TimeTableTest()
        {
            _TimeTableRepositoryMock = new Mock<ITimeTableRepository>();
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _TimeTableUseCases = new TimeTableUseCases(_TimeTableRepositoryMock.Object, _doctorRepositoryMock.Object);
        }

        [Fact]
        public void NonValidData_ShouldFail()
        {
            var date = new TimeTable();
            var res = _TimeTableUseCases.CreateTimeTable(date);
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid input data:Non correct time", res.Error);
        }

        [Fact]
        public void TryCreateTimeTable_ShouldTrue()
        {
            _TimeTableRepositoryMock.Setup(repo => repo.CreateTimeTable(It.IsAny<TimeTable>())).Returns(() => true);
            var date = new TimeTable(1,DateTime.MinValue, DateTime.MaxValue);
            var res = _TimeTableUseCases.CreateTimeTable(date);
            Assert.True(res.Success);
        }

        [Fact]
        public void TryUpdateTimeTable_ShouldTrue()
        {
            _TimeTableRepositoryMock.Setup(repo => repo.UpdateTimeTable(It.IsAny<TimeTable>())).Returns(() => true);
            var date = new TimeTable(1, DateTime.MinValue, DateTime.MaxValue);
            var res = _TimeTableUseCases.UpdateTimeTable(date);
            Assert.True(res.Success);
        }

        [Fact]
        public void TryGetTimeTableByDoctorAndDateIsNull_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repo => repo.IsDoctorExist(It.IsAny<int>())).Returns(() => true);
            _TimeTableRepositoryMock.Setup(repo => repo.GetTimeTableByDoctorAndDate(It.IsAny<Doctor>(), It.IsAny<DateTime>()))
                .Returns(() => null);
            var res = _TimeTableUseCases.GetTimeTableByDoctorAndDate(new Doctor(), DateTime.MaxValue);
            Assert.True(res.IsFailure);
            Assert.Equal("Error while getting timetable.Try again later", res.Error);
        }
    }
}
