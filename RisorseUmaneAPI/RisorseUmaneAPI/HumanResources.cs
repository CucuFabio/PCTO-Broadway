namespace RisorseUmaneAPI
{
    public class HumanResources
    {
        public int BusinessEntityID { get; set; }
        public int NationalIDNumber_long { get; set; }
        public string LoginID { get; set; }
        public string OrganizationNode { get; set; }
        public int OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public int SalariadFlag { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }

        public HumanResources(int BusinessEntityID_, int NationalIDNumber_long_, string LoginID_, string OrganizationNode_, int OrganizationLevel_, string JobTitle_, DateTime BirthDate_, string MaritalStatus_, string Gender_, DateTime HireDate_, int SalariadFlag_, int VacationHours_, int SickLeaveHours_)
        {
            this.BusinessEntityID = BusinessEntityID_;
            this.NationalIDNumber_long = NationalIDNumber_long_;
            this.LoginID = LoginID_;
            this.OrganizationNode = OrganizationNode_;
            this.OrganizationLevel = OrganizationLevel_;
            this.JobTitle = JobTitle_;
            this.BirthDate = BirthDate_;
            this.MaritalStatus = MaritalStatus_;
            this.Gender = Gender_;
            this.HireDate = HireDate_;
            this.SalariadFlag = SalariadFlag_;
            this.VacationHours = VacationHours_;
            this.SickLeaveHours = SickLeaveHours_;
        }

        public HumanResources()
        {

        }
    }
}
