using HandsOn_.NET8APIWithUnitTesting.Models;
using HandsOn_.NET8APIWithUnitTesting.Repository;
using Moq;

namespace HandsOn_MoqTests
{
    public class MoqTests
    {
        private readonly Mock<IPatientRepository> _mockRepository;

        public MoqTests()
        {
            _mockRepository = new Mock<IPatientRepository>();
        }

        //write moq test for GetAllPatients method  
        [Test]
        public void GetAllPatientsTest()
        {
            //Arrange
            _mockRepository.Setup(p => p.GetAllPatients()).Returns(new List<PatientModel>()
            {
                new PatientModel() { PatientId = 1001, PatientName = "Sam", Age = 39, Email = "sam@gmail.com", MobileNumber = 9600197755, DiseaseName = "Fever" },
                new PatientModel() { PatientId = 1002, PatientName = "Peter", Age = 40, Email = "peter@yahoo.in", MobileNumber = 7606197758, DiseaseName = "Leg Pain" }
            });
            var result = _mockRepository.Object;

            //Act
            var patients = result.GetAllPatients();

            //Assert
            Assert.That(2, Is.EqualTo(patients.Count()));
            }


        //write moq test for GetPatientById method
        [Test]
        public void GetPatientByIdTest()
        {
            //Arrange
            PatientModel patient = new PatientModel()
            {
                PatientId = 1001,
                PatientName = "Sam",
                Age = 39,
                Email = "sam@gmail.com",
                MobileNumber = 9600197755,
                DiseaseName = "Fever"
            };
            
            _mockRepository.Setup(x => x.GetPatientById(1001)).Returns(patient);
            var result = _mockRepository.Object;

            //Act
            var patientsById = result.GetPatientById(1001);

            //Assert
            Assert.That(patient, Is.EqualTo(patientsById));

        }

         //write moq test for AddPatient method
            [Test]
            public void AddPatientTest()
            {
            //Arrange
            PatientModel patient = new PatientModel()
            {
                PatientId = 1001,
                PatientName = "Sam",
                Age = 39,
                Email = "sam@gmail.com",
                MobileNumber = 9600197755,
                DiseaseName = "Fever"
            };

            _mockRepository.Setup(x => x.AddPatient(patient)).Returns(new PatientModel()
            {
                PatientId = 1001,
                PatientName = "Sam",
                Age = 39,
                Email = "sam@gmail.com",
                MobileNumber = 9600197755,
                DiseaseName = "Fever"
            });
            var result = _mockRepository.Object;

            //Act
            var patientAdded = result.AddPatient(patient);

            //Assert
            Assert.That(patient.PatientId, Is.EqualTo(patientAdded.PatientId));
            Assert.That(patient.PatientName, Is.EqualTo(patientAdded.PatientName));
            Assert.That(patient.Age, Is.EqualTo(patientAdded.Age));
            Assert.That(patient.Email, Is.EqualTo(patientAdded.Email));
            Assert.That(patient.MobileNumber, Is.EqualTo(patientAdded.MobileNumber));
            Assert.That(patient.DiseaseName, Is.EqualTo(patientAdded.DiseaseName));
        }

        //write moq test for UpdatePatient method
        [Test]
        public void UpdatePatientTest()
        {
            //Arrange
            PatientModel patient = new PatientModel()
            {
                PatientId = 1001,
                PatientName = "Sam",
                Age = 40,
                Email = "sam@gmail.com",
                MobileNumber = 9600197755,
                DiseaseName = "Viral Pox"
            };

            _mockRepository.Setup(x => x.UpdatePatient(patient, patient.PatientId)).Returns(new PatientModel()
            {
                PatientId = 1001,
                PatientName = "Sam",
                Age = 40,
                Email = "sam@gmail.com",
                MobileNumber = 9600197755,
                DiseaseName = "Viral Pox"
            });
            var result = _mockRepository.Object;

            //Act
            var patientUpdated = result.UpdatePatient(patient, patient.PatientId);

            //Assert
            Assert.That(patient.PatientId, Is.EqualTo(patientUpdated.PatientId));
            Assert.That(patient.PatientName, Is.EqualTo(patientUpdated.PatientName));
            Assert.That(patient.Age, Is.EqualTo(patientUpdated.Age));
            Assert.That(patient.Email, Is.EqualTo(patientUpdated.Email));
            Assert.That(patient.MobileNumber, Is.EqualTo(patientUpdated.MobileNumber));
            Assert.That(patient.DiseaseName, Is.EqualTo(patientUpdated.DiseaseName));

        }

            //write moq test for DeletePatient method
            [Test]
            public void DeletePatientTest()
            {
                //Arrange
                PatientModel patient = new PatientModel()
                {
                    PatientId = 1001,
                    PatientName = "Sam",
                    Age = 39,
                    Email = "sam@gmail.com",
                    MobileNumber = 9600197755,
                    DiseaseName = "Fever"
                };

                _mockRepository.Setup(x => x.DeletePatient(1001)).Returns(true);
                var result = _mockRepository.Object;

                //Act
                var deletedPatient = result.DeletePatient(1001);

                //Assert
                Assert.IsTrue(deletedPatient);
            }


        }
}