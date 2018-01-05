namespace CoursesEvaluationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseEvaluationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CourseEvaluationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var student1 = new Entities.StudentEntity()
            {
                Id = new Guid("8ef983f7-04ef-4386-a516-4ebf88e14395"),
                Name = "Mensik",
                Surname = "Jakub",
                Login = "xmensi03",
                Address = "Nachod",
                Street = "Divadelni 9",
                Grade = 1
            };
            var student2 = new Entities.StudentEntity()
            {
                Id = new Guid("75d98bc9-9005-4879-9afa-9ff6678e9aa0"),
                Name = "Moravec",
                Surname = "Matej",
                Login = "xmorav32",
                Address = "Brno",
                Street = "Nova 555",
                Grade = 2
            };
            var student3 = new Entities.StudentEntity()
            {
                Id = new Guid("d089b5a6-953a-4fdc-8968-ac12cda3cb30"),
                Name = "Student",
                Surname = "Nesikovny",
                Login = "xnesik42",
                Address = "Praha",
                Street = "Pod Mostom 9",
                Grade = 5
            };
            var student4 = new Entities.StudentEntity()
            {
                Id = new Guid("8b2550c8-beb3-42fa-9fd6-c90fab3020f6"),
                Name = "Nestastny",
                Surname = "Omyl",
                Login = "xnesta22",
                Address = "Bratislava",
                Street = "Pentagon 5",
                Grade = 2
            };
            var student5 = new Entities.StudentEntity()
            {
                Id = new Guid("c9d04d93-d023-4738-ac12-c42382783225"),
                Name = "Wilson",
                Surname = "Jimmy",
                Login = "xwilso00",
                Address = "Nitra",
                Street = "Masarykova 25",
                Grade = 2
            };
            var student6 = new Entities.StudentEntity()
            {
                Id = new Guid("e6997a6f-95ec-4557-ad39-4e96756af911"),
                Name = "Novak",
                Surname = "Pavol",
                Login = "xnovak98",
                Address = "Kosice",
                Street = "Palackeho trieda 74",
                Grade = 3
            };
            var student7 = new Entities.StudentEntity()
            {
                Id = new Guid("64d44824-ea1d-4e51-8843-3f0b69ff7dac"),
                Name = "Lenivy",
                Surname = "Michal",
                Login = "xleniv05",
                Address = "Ostrava",
                Street = "Nadrazni 19",
                Grade = 3
            };
            var student8 = new Entities.StudentEntity()
            {
                Id = new Guid("5758d085-0b8c-47d6-b4ec-8f6ace7e1e48"),
                Name = "Navratilova",
                Surname = "Jana",
                Login = "xnavra44",
                Address = "Karlovy Vary",
                Street = "Husitska 8",
                Grade = 4
            };
            context.Students.AddOrUpdate(p => p.Id, student1, student2, student3, student4, student5, student6, student7, student8);


            var pluskalJan = new Entities.TeacherEntity()
            {
                Id = new Guid("6aea8a49-27c0-45c3-85cb-7b23ac0210e3"),
                Name = "Jan",
                Surname = "Pluskal",
                Email = "ipluskal@fit.vutbr.cz",
                Login = "ipluskal00",
                Room = "Office C306"
            };
            var honzikJan = new Entities.TeacherEntity()
            {
                Id = new Guid("71294cc5-f53c-4e63-a02b-38764f714940"),
                Name = "Jan Maximilian",
                Surname = "Honzik",
                Email = "honzik@fit.vutbr.cz",
                Login = "honzik",
                Room = "Office C227"
            };
            context.Teachers.AddOrUpdate(p => p.Id, pluskalJan, honzikJan);


            var iw1 = new Entities.CourseEntity()
            {
                Id = new Guid("fd0a9192-cec4-4317-a6c1-23131f003bc2"),
                Name = "Desktop systémy Microsoft Windows",
                Abbreviation = "IW1",
                Year = new DateTime(2016, 09, 20),
                GuaranteeId = honzikJan.Id
            };
            var iw2 = new Entities.CourseEntity()
            {
                Id = new Guid("33bc509d-3cfc-4e10-b809-4097eea4b7ab"),
                Name = "Serverové systémy Microsoft Windows",
                Abbreviation = "IW2",
                Year = new DateTime(2017, 02, 06),
                GuaranteeId = honzikJan.Id
            };
            var iw3 = new Entities.CourseEntity()
            {
                Id = new Guid("cc688e12-2cc8-4399-ab7a-50ba96e160fc"),
                Name = "Síové technologie Microsoft Windows",
                Abbreviation = "IW3",
                Year = new DateTime(2016, 09, 20),
                GuaranteeId = honzikJan.Id
            };
            var iw4 = new Entities.CourseEntity()
            {
                Id = new Guid("b2220871-def0-4299-be9a-d25f217553ae"),
                Name = "Podnikové technologie Microsoft",
                Abbreviation = "IW4",
                Year = new DateTime(2017, 02, 06),
                GuaranteeId = honzikJan.Id
            };
            var iw5 = new Entities.CourseEntity()
            {
                Id = new Guid("b667e639-0844-4687-b08e-b3d5d46085e8"),
                Name = "Programování v .NET a C#",
                Abbreviation = "IW5",
                Year = new DateTime(2017, 02, 06),
                GuaranteeId = honzikJan.Id
            };
            context.Courses.AddOrUpdate(c => c.Id, iw1, iw2, iw3, iw4, iw5);


            var student1EnrolledIw1 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("02efa9f0-87f8-4e27-adfa-4b51aeacc907"),
                CourseId = iw1.Id,
                StudentId = student1.Id
            };
            var student1EnrolledIw4 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("60efc5ad-2212-4268-b90d-0dc83bedf437"),
                CourseId = iw4.Id,
                StudentId = student1.Id
            };
            var student2EnrolledIw5 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("d403abc8-7bb9-454a-8d27-a210d02ce89f"),
                CourseId = iw5.Id,
                StudentId = student2.Id
            };
            var student3EnrolledIw2 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("1224f442-0de9-4403-a03e-5adaf7fb8d57"),
                CourseId = iw2.Id,
                StudentId = student3.Id
            };
            var student3EnrolledIw4 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("02b299b7-fc78-4df1-a875-f9dcbeef504c"),
                CourseId = iw4.Id,
                StudentId = student3.Id
            };
            var student4EnrolledIw1 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("526dc354-17e0-4559-91c5-5113c0981045"),
                CourseId = iw1.Id,
                StudentId = student4.Id
            };
            var student4EnrolledIw3 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("0883c0a4-00a3-4d57-b802-bcc7043e8a04"),
                CourseId = iw3.Id,
                StudentId = student4.Id
            };
            var student5EnrolledIw4 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("134df066-fbbb-45a2-8b31-12ce658c4b90"),
                CourseId = iw4.Id,
                StudentId = student5.Id
            };
            var student5EnrolledIw5 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("749245e9-0342-4f5f-9d4f-33402ad54bea"),
                CourseId = iw5.Id,
                StudentId = student5.Id
            };
            var student6EnrolledIw3 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("128fa9ba-99de-46e3-9289-e22484e2e6fe"),
                CourseId = iw3.Id,
                StudentId = student6.Id
            };
            var student8EnrolledIw1 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("3a059460-9b40-448a-aa93-486f29f2227e"),
                CourseId = iw1.Id,
                StudentId = student8.Id
            };
            var student8EnrolledIw2 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("c6b02e09-c26a-4622-a903-77b9e8e4e98b"),
                CourseId = iw2.Id,
                StudentId = student8.Id
            };
            var student8EnrolledIw5 = new Entities.EnrolledCourseEntity()
            {
                Id = new Guid("f1bbcb5e-2fdd-486f-a403-8963c9b9df53"),
                CourseId = iw5.Id,
                StudentId = student8.Id
            };
            context.EnrolledCourses.AddOrUpdate(p => p.Id,
                student1EnrolledIw1, student1EnrolledIw4,
                student2EnrolledIw5,
                student3EnrolledIw2, student3EnrolledIw4,
                student4EnrolledIw1, student4EnrolledIw3,
                student5EnrolledIw4, student5EnrolledIw5,
                student6EnrolledIw3,
                student8EnrolledIw1, student8EnrolledIw2, student8EnrolledIw5);


            var rating1 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("3b957a36-6d5c-4d70-a414-7856dccd89d0"),
                Points = 30,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student1EnrolledIw1.Id
            };
            var rating2 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("3b42a6d8-2c26-4112-88d7-47f5bce86665"),
                Points = 22,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student1EnrolledIw4.Id
            };
            var rating3 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("5c04ac67-6cc5-4561-a8d3-edb5be998ead"),
                Points = 2,
                Type = Entities.AssessmentType.BonusPoints,
                EnrolledCourseId = student1EnrolledIw4.Id
            };
            var rating4 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("bae2b329-c89e-4689-868d-378076d10a23"),
                Points = 12,
                Type = Entities.AssessmentType.Exercise,
                EnrolledCourseId = student2EnrolledIw5.Id
            };
            var rating5 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("86aa25e1-09f7-451b-b922-3cd6e578b7c2"),
                Points = 4,
                Type = Entities.AssessmentType.Exercise,
                EnrolledCourseId = student3EnrolledIw2.Id
            };
            var rating6 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("ef527f7e-9f9c-43a4-a946-83055c5959a6"),
                Points = 11,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student3EnrolledIw4.Id
            };
            var rating7 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("1b72e35c-e607-4f18-9d8b-e2480fed870d"),
                Points = 8,
                Type = Entities.AssessmentType.BonusPoints,
                EnrolledCourseId = student3EnrolledIw4.Id
            };
            var rating8 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("840af5e6-f3ce-4dda-9a63-3feae472551e"),
                Points = 34,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student3EnrolledIw4.Id
            };
            var rating9 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("57e9f1ef-cbef-4a6e-9358-3544ec64963d"),
                Points = 23,
                Type = Entities.AssessmentType.Exercise,
                EnrolledCourseId = student3EnrolledIw4.Id
            };
            var rating10 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("0ecf03fd-f69b-43ed-a2e8-53452c3e793a"),
                Points = 7,
                Type = Entities.AssessmentType.Other,
                EnrolledCourseId = student4EnrolledIw1.Id
            };
            var rating11 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("08ae7d88-720f-4148-ba7c-8e6da747c42e"),
                Points = 9,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student4EnrolledIw1.Id
            };
            var rating12 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("68d1775e-7bf3-493e-9cdf-79d5b318c7da"),
                Points = 14,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student5EnrolledIw4.Id
            };
            var rating13 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("250e8ffb-b869-4ce2-9797-aa72b9b620f5"),
                Points = 45,
                Type = Entities.AssessmentType.Project,
                EnrolledCourseId = student5EnrolledIw4.Id
            };
            var rating14 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("7cddf9c1-3977-4eb0-96eb-2935c25b4a83"),
                Points = 24,
                Type = Entities.AssessmentType.Exercise,
                EnrolledCourseId = student5EnrolledIw5.Id
            };
            var rating15 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("bac3abfb-af64-4624-a55d-1a4a6e0731ed"),
                Points = 5,
                Type = Entities.AssessmentType.Other,
                EnrolledCourseId = student6EnrolledIw3.Id
            };
            var rating16 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("bec3bbbc-d34d-40ff-a480-4d476ac92ee1"),
                Points = 17,
                Type = Entities.AssessmentType.Exercise,
                EnrolledCourseId = student8EnrolledIw1.Id
            };
            var rating17 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("1ad34d13-b4b9-4ab2-b91e-65b87913eccb"),
                Points = 24,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student8EnrolledIw1.Id
            };
            var rating18 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("c909ea81-b95d-48d4-97a4-e904f97b16a4"),
                Points = 20,
                Type = Entities.AssessmentType.Examination,
                EnrolledCourseId = student8EnrolledIw2.Id
            };
            var rating19 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("4de27fd9-5e8e-4f0e-9291-9fa7f1113e51"),
                Points = 60,
                Type = Entities.AssessmentType.Project,
                EnrolledCourseId = student8EnrolledIw5.Id
            };
            var rating20 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("5298556a-821d-415d-95f6-d82272e2bab2"),
                Points = 30,
                Type = Entities.AssessmentType.Exercise,
                EnrolledCourseId = student8EnrolledIw5.Id
            };
            var rating21 = new Entities.AssessmentRatingEntity()
            {
                Id = new Guid("3ac98d2c-5b9f-45d2-9687-1d5f65e51434"),
                Points = 4,
                Type = Entities.AssessmentType.BonusPoints,
                EnrolledCourseId = student8EnrolledIw5.Id
            };
            context.AssessmentRatings.AddOrUpdate(a => a.Id, rating1, rating2, rating3,
                rating4, rating5, rating6, rating7, rating8, rating9, rating10, rating11, rating12,
                rating13, rating14, rating15, rating16, rating17, rating18, rating19, rating20, rating21);
        }
    }
}
