using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using University_Manager.Models;

namespace University_Manager.Models
{
    public class UniversityDBInitializer : DropCreateDatabaseAlways<UniversityDbContex>
    {
        protected override  void Seed(UniversityDbContex context)
        {

            SeedAsync(context).Wait();
        }

        protected async Task SeedAsync(UniversityDbContex context)
        {
            await addData(context);
            base.Seed(context);
        }

        private async Task addData(UniversityDbContex context)
        {            
            context = loadGrades(context);
            context = loadRooms(context);
            context = loadDesignations(context);
            context = loadSemisters(context);
            context = loadDays(context);
            context = loadDeparments(context);
            context = loadCourses(context);
            context = loadTeachers(context);
            context = loadStudents(context);
            context = loadEnrolls(context);
            context = loadResultEntry(context);

            createRolesandUsers();
        }

        private UniversityDbContex loadGrades(UniversityDbContex context)
        {
            IList<Grade> defaultValues = new List<Grade>();

            defaultValues.Add(new Grade() { Name = "A+" });
            defaultValues.Add(new Grade() { Name = "A" });
            defaultValues.Add(new Grade() { Name = "B+" });
            defaultValues.Add(new Grade() { Name = "B" });
            defaultValues.Add(new Grade() { Name = "C+" });
            defaultValues.Add(new Grade() { Name = "C" });
            defaultValues.Add(new Grade() { Name = "D" });
            defaultValues.Add(new Grade() { Name = "F" });

            context.Grades.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadRooms(UniversityDbContex context)
        {
            IList<Room> defaultValues = new List<Room>();

            defaultValues.Add(new Room() { Name = "Room-1" });
            defaultValues.Add(new Room() { Name = "Room-2" });
            defaultValues.Add(new Room() { Name = "Room-3" });
            defaultValues.Add(new Room() { Name = "Room-4" });
            defaultValues.Add(new Room() { Name = "Room-5" });
            defaultValues.Add(new Room() { Name = "Room-6" });
            defaultValues.Add(new Room() { Name = "Room-7" });
            defaultValues.Add(new Room() { Name = "Room-8" });

            context.Rooms.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadDesignations(UniversityDbContex context)
        {
            IList<Designation> defaultValues = new List<Designation>();

            
            defaultValues.Add(new Designation() { DesignationName = "No assign" });
            defaultValues.Add(new Designation() { DesignationName = "Professor" });
            defaultValues.Add(new Designation() { DesignationName = "Asst. Professor" });
            defaultValues.Add(new Designation() { DesignationName = "Lecturer" });
            defaultValues.Add(new Designation() { DesignationName = "Asst Lecturer" });
            
            context.Designations.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadSemisters(UniversityDbContex context)
        {
            IList<Semister> defaultValues = new List<Semister>();

            defaultValues.Add(new Semister() { Semistername = "No assign" });
            defaultValues.Add(new Semister() { Semistername = "First Semister" });
            defaultValues.Add(new Semister() { Semistername = "Second Semister" });
            defaultValues.Add(new Semister() { Semistername = "Third Semister" });
            defaultValues.Add(new Semister() { Semistername = "Four Semister" });

            context.Semisters.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadDays(UniversityDbContex context)
        {
            IList<Day> defaultValues = new List<Day>();

            defaultValues.Add(new Day() { Name = "No assign" });
            defaultValues.Add(new Day() { Name = "Monday" });
            defaultValues.Add(new Day() { Name = "Tuesday" });
            defaultValues.Add(new Day() { Name = "Wednesday" });
            defaultValues.Add(new Day() { Name = "Thursday" });
            defaultValues.Add(new Day() { Name = "Friday" });
            defaultValues.Add(new Day() { Name = "Saturday" });
            defaultValues.Add(new Day() { Name = "Sunday" });

            context.Days.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadDeparments(UniversityDbContex context)
        {
            IList<Department> defaultValues = new List<Department>();

            defaultValues.Add(new Department() { Code = "Wd01",Name= "Web Development" });
            defaultValues.Add(new Department() { Code = "Pr02", Name = "Programming" });
            defaultValues.Add(new Department() { Code = "DC03", Name = "Data Science" });

            context.Departments.AddRange(defaultValues);
            context.SaveChanges();
            return context;
        }

        private UniversityDbContex loadCourses(UniversityDbContex context)
        {
            IList<Course> defaultValues = new List<Course>();


            defaultValues.Add(new Course() { Code=  "C101",Name="Html",Credit=10,Description="Html basic",SemisterId=1,DepartmentId=1,AssignTo="" });
            defaultValues.Add(new Course() { Code = "C102", Name = "Css", Credit = 10, Description = "Css basic", SemisterId = 1, DepartmentId = 1, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "C103", Name = "Responsive Design", Credit = 10, Description = "Responsive Design", SemisterId = 1, DepartmentId = 1, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "C104", Name = "Saas advande", Credit = 10, Description = "Saas advance", SemisterId = 1, DepartmentId = 1, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "C105", Name = "Angular advance", Credit = 10, Description = "Angular advance", SemisterId = 1, DepartmentId = 1, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "C106", Name = "React", Credit = 10, Description = "Reac basic", SemisterId = 1, DepartmentId = 1, AssignTo = "" });

            defaultValues.Add(new Course() { Code = "D101", Name = "Python", Credit = 10, Description = "Python", SemisterId = 1, DepartmentId = 2, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "D102", Name = "Java", Credit = 10, Description = "Java", SemisterId = 1, DepartmentId = 2, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "D103", Name = "C Sharp", Credit = 10, Description = "C Sharp", SemisterId = 1, DepartmentId = 2, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "D104", Name = "JavaScript", Credit = 10, Description = "JavaScript", SemisterId = 1, DepartmentId = 2, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "D105", Name = "Android", Credit = 10, Description = "Android", SemisterId = 1, DepartmentId = 2, AssignTo = "" });
            
            defaultValues.Add(new Course() { Code = "F101", Name = "Oracle", Credit = 10, Description = "Oracle", SemisterId = 1, DepartmentId = 3, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "F102", Name = "Microsoft Sql", Credit = 10, Description = "Microsoft Sql", SemisterId = 3, DepartmentId = 2, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "F103", Name = "Tableau", Credit = 10, Description = "Tableau", SemisterId = 1, DepartmentId = 3, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "F104", Name = "Data mining", Credit = 10, Description = "Data mining", SemisterId = 3, DepartmentId = 2, AssignTo = "" });
            defaultValues.Add(new Course() { Code = "F105", Name = "Myslq", Credit = 10, Description = "Mysql", SemisterId = 1, DepartmentId = 3, AssignTo = "" });


            context.Courses.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadTeachers(UniversityDbContex context)
        {
            IList<Teacher> defaultValues = new List<Teacher>();

            defaultValues.Add(new Teacher() {  Name="John Smith",Address="Alajuela",Email="johnsmith@gmail.com",Contact="86589658", DepartmentId=1,CreditTaken=100,DesignationId=1 });
            defaultValues.Add(new Teacher() { Name = "Laurece Vargas", Address = "San Jose", Email = "laurece@gmail.com", Contact = "80896521", DepartmentId = 2, CreditTaken = 100, DesignationId = 1 });
            defaultValues.Add(new Teacher() { Name = "Michael Soto", Address = "Heredia", Email = "michael@gmail.com", Contact = "78965214", DepartmentId = 3, CreditTaken = 100, DesignationId = 1 });

            context.Teachers.AddRange(defaultValues);
            return context;
        }

        private UniversityDbContex loadStudents(UniversityDbContex context)
        {
            IList<Student> defaultValues = new List<Student>();

            defaultValues.Add(new Student() { Name = "Marco Rojas", Email = "marcoro@gmail.com", Contact = "86589658", Date = Convert.ToDateTime("08/08/1990"), RegistrationId = "C5115556",Address="Alajuela", DepartmentId = 1 });
            defaultValues.Add(new Student() { Name = "Julia Nunez", Email = "julia@gmail.com", Contact = "87987987", Date = Convert.ToDateTime("08/08/1997"), RegistrationId = "C5115557",  Address = "San Jose",DepartmentId = 1 });
            defaultValues.Add(new Student() { Name = "Gabriela Miranda", Email = "gabriela@gmail.com", Contact = "86535158", Date = Convert.ToDateTime("08/08/1993"), RegistrationId = "C5115558", Address = "Heredia", DepartmentId = 1 });
            defaultValues.Add(new Student() { Name = "Luis Rodriguez", Email = "luis@gmail.com", Contact = "86589612", Date = Convert.ToDateTime("08/08/1998"), RegistrationId = "C5115559", Address = "Alajuela", DepartmentId = 1 });

            context.Students.AddRange(defaultValues);
            context.SaveChanges();
            return context;
        }

      
        private UniversityDbContex loadEnrolls(UniversityDbContex context)
        {
            IList<EnrollCourse> defaultValues = new List<EnrollCourse>();
            Enrollment s = new Enrollment();
            List<Student> listStudents = new List<Student>();
            List<Course> listCourse = new List<Course>();

      
            listStudents = context.Students.ToList();
            listCourse = context.Courses.ToList();

            foreach(Student st in listStudents)
            {
                foreach(Course cr in listCourse)
                {
                    defaultValues.Add(new EnrollCourse() { Student = st, Course = cr, EnrollDate = Convert.ToDateTime("08/08/2017") });
                }
            }

            context.EnrollCourses.AddRange(defaultValues);
            context.SaveChanges();
            return context;
        }

        

        private UniversityDbContex loadResultEntry(UniversityDbContex context)
        {
            IList<ResultEntry> defaultValues = new List<ResultEntry>();
            List<Student> listStudent = new List<Student>();
            List<Course> listCourse = new List<Course>();
            List<Grade> listGrade = new List<Grade>();

            listCourse = context.Courses.ToList();
            listStudent = context.Students.ToList();
            listGrade = context.Grades.ToList();

            foreach (Student st in listStudent)
            {
                foreach(Course cour in listCourse)
                {
                    Random rnd = new Random();
                    int indexGrade = rnd.Next(0, 8);
                    Grade gr = listGrade[indexGrade];
                    defaultValues.Add(new ResultEntry() { Student=st, StudentId=st.StudentId,Course=cour, CourseId=cour.CourseId ,Grade= gr, GradeId= gr.GradeId});
                    gr = new Grade();
                }
            }
        
            context.ResultEntries.AddRange(defaultValues);
            context.SaveChanges();
            return context;
        }


        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

           
            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";

                string userPWD = "123456";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
            
        }

    }
}