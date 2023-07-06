using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
namespace Exam_B
{
    public class Result
    {
        public List<ResultHeader> FullResult { get; set; }
    }
    public class ResultHeader
    {
        public string HN { get; set; }
        public string PrefixName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string LabNumber { get; set; }
        public string RequestRemark { get; set; }
        public string RequestUnit { get; set; }
        public IList<ResultList> ResultList { get; set; }
    }

    public class ResultList
    {
        public string BarcodeNumber { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public string ResultCode { get; set; }
        public string ResultName { get; set; }
        public string ResultStatus { get; set; }
        public string ResultType { get; set; }
        public string ResultValue { get; set; }
        public string ResultUnit { get; set; }
        public string ResultUnitID { get; set; }
        public string ResultFlag { get; set; }
        public string CriticalFlag { get; set; }
        public string ResultRepeatFlag { get; set; }
        public string ResultDilutionFlag { get; set; }
        public string ReferenceRange { get; set; }
        public string TestRemark { get; set; }
        public string ResultRemark { get; set; }
        public string CriticalRemark { get; set; }
        public string InformCriticalBy { get; set; }
        public string InformCriticalTo { get; set; }
        public string InformCriticalDateTime { get; set; }
        public string ReportResultBy { get; set; }
        public string ReportResultDateTime { get; set; }
        public string ApproveResultBy { get; set; }
        public string ApproveResultDateTime { get; set; }
        public string SpecimenCode { get; set; }
        public string SpecimenName { get; set; }
    }
}
