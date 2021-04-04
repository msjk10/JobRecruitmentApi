using Candidate.Domain.Entities.DataModel;
using Common.Domain.Entities.DataModel;
using Employee.Domain.Entities.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Job.Context.EfConnection
{
    public  class SqlServerContext: DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { set; get; }
        public DbSet<Companies> Companies { set; get; }
        public DbSet<Candidates> Candidates { set; get; }
        public DbSet<PasswordHistory> PasswordHistory { set; get; }
        public DbSet<Countries> Countries { set; get; }
        public DbSet<District> District { set; get; }
        public DbSet<Thana> Thana { set; get; }
        public DbSet<JobCategory> JobCategory { set; get; }
        public DbSet<JobSubCategory> JobSubCategory { set; get; }
        public DbSet<SkillCategories> SkillCategories { set; get; }
        public DbSet<Skills> Skills { set; get; }
        public DbSet<Degree> Degree { set; get; }
        public DbSet<DegreeLevel> DegreeLevel { set; get; }
        public DbSet<DegreeMapping> DegreeMapping { set; get; }
        public DbSet<QuestionCategory> QuestionCategory { set; get; }
        public DbSet<QuestionBank> QuestionBank { set; get; }
        public DbSet<QuestionDetails> QuestionDetails { set; get; }
        public DbSet<TemporaryJobFirstStage> TemporaryJobFirstStage { set; get; }
        public DbSet<TempJobSecondStage> TempJobSecondStage { set; get; }
        public DbSet<TempSkill> TempSkill { set; get; }
        public DbSet<TempDegree> TempDegree { set; get; }
        public DbSet<TempGender> TempGender { set; get; }
        public DbSet<TempQuestionScoring> TempQuestionScoring { set; get; }
        public DbSet<TempQuestion> TempQuestion { set; get; }
        public DbSet<Jobs> Jobs { set; get; }
        public DbSet<JobSkills> JobSkills { set; get; }
        public DbSet<Gender> Gender { set; get; }
        public DbSet<Qualifications> Qualifications { set; get; }
        public DbSet<GamificationQuestions> GamificationQuestions { set; get; }
        public DbSet<BookmarkJob> BookmarkJob { set; get; }
        public DbSet<AppliedJobs> AppliedJob { set; get; }
        public DbSet<AnswerSheet> AnswerSheet { set; get; }
        public DbSet<CandidateSkills> CandidateSkills { set; get; }
        public DbSet<EmploymentHistory> EmploymentHistory { set; get; }
        public DbSet<Status> Status { set; get; }
        public DbSet<Message> Message { set; get; }
        public DbSet<Project> Project { set; get; }
        public DbSet<Certification> Certification { set; get; }
        public DbSet<EducationalBackground> EducationalBackground { set; get; }
    }
}
