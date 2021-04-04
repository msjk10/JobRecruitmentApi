using Employee.Domain.Entities.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class JobSecondStageBodyModel
    {
        public int JobSecondStageId { get; set; }
        public int TempJobId { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public string PreferredLanguage { get; set; }
        public string PreferredInstitution { get; set; }
        public string ProfessionalCertification { get; set; }
        public IEnumerable<TempSkill> TempSkills { get; set; }
        public IEnumerable<TempDegree> TempDegrees { get; set; }
        public IEnumerable<TempGender> TempGenders { get; set; }
    }
}
